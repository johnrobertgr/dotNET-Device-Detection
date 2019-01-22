﻿/* *********************************************************************
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited. 
 * Copyright © 2017 51Degrees Mobile Experts Limited, 5 Charlotte Close,
 * Caversham, Reading, Berkshire, United Kingdom RG4 7BY
 * 
 * This Source Code Form is the subject of the following patents and patent 
 * applications, owned by 51Degrees Mobile Experts Limited of 5 Charlotte
 * Close, Caversham, Reading, Berkshire, United Kingdom RG4 7BY: 
 * European Patent No. 2871816;
 * European Patent Application No. 17184134.9;
 * United States Patent Nos. 9,332,086 and 9,350,823; and
 * United States Patent Application No. 15/686,066.
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0.
 * 
 * If a copy of the MPL was not distributed with this file, You can obtain
 * one at http://mozilla.org/MPL/2.0/.
 * 
 * This Source Code Form is “Incompatible With Secondary Licenses”, as
 * defined by the Mozilla Public License, v. 2.0.
 * ********************************************************************* */

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using FiftyOne.Foundation.Properties;
using FiftyOne.Foundation.Bases;
using System.Xml;

namespace FiftyOne.Foundation.Licence
{
    /// <summary>
    /// Encapsulates a licence key.
    /// </summary>
    public class Key
    {
        #region Constants

        // Base date used to calculate the actual date from ushort offsets.
        private static readonly DateTime BASE_DATE = new DateTime(2010, 11, 1);

        #endregion

        #region Public Fields

        /// <summary>
        /// The unique integer Id of the licence associated with the key.
        /// </summary>
        public int LicenceId { get; protected set; }

        #endregion

        #region Internal, Protected and Private Fields

        private readonly string _encodedText;
        private readonly bool _isValid;

        /// <summary>
        /// List of products the key can be used with.
        /// </summary>
        protected readonly List<Product> _products = new List<Product>();

        /// <summary>
        /// The offset for the date the licence is valid from.
        /// </summary>
        protected ushort _startDateOffset;

        /// <summary>
        /// The offset for the date the licence is valid until.
        /// </summary>
        protected ushort _endDateOffset;
        
        #endregion

        #region Constructors

        /// <summary>
        /// Used by any subclasses to construct a new <see cref="Key"/> 
        /// instance. 
        /// </summary>
        protected Key() { }

        /// <summary>
        /// Constructs a new <see cref="Key"/> instance.
        /// </summary>
        /// <param name="encodedText">The encoded Licence text.</param>
        public Key(String encodedText)
        {
            _encodedText = encodedText;
            try
            {
                using (BinaryReader reader = new BinaryReader(
                    new MemoryStream(Base32.Decode(encodedText))))
                {
                    // Get the Licence data from the reader.
                    LicenceId = reader.ReadInt32();
                    _startDateOffset = reader.ReadUInt16();
                    _endDateOffset = reader.ReadUInt16();
                    byte productCount = reader.ReadByte();
                    for (int i = 0; i < productCount; i++)
                    {
                        _products.Add(new Product(reader));
                    }

                    // Validate the signature that follows the Licence data.
                    _isValid = DSAVerifyHash(
                        new SHA1CryptoServiceProvider().ComputeHash(ToArray()),
                        reader.ReadBytes(reader.ReadByte()),
                        LicenceConstants.PublicKey, "SHA1");
                }
            }
            catch
            {
                _isValid = false;
            }
        }

        #endregion

        #region Public Properties
        
        /// <summary>
        /// An enumeration of the products the licence key can be used with.
        /// </summary>
        public IEnumerable<Product> Products
        {
            get { return _products; }
        }

        /// <summary>
        /// Returns true if the Licence is valid with this Assembly at this time.
        /// </summary>
        public bool IsValid
        {
            get
            {
                return (_isValid == true &&
                        _products.Any(i => i.IsValid));
            }
        }

        /// <summary>
        /// Returns true if the Licence is valid and is also an evaluation
        /// Licence type.
        /// </summary>
        public bool IsTrial
        {
            get
            {
                return _products != null && 
                    _products.Any(i => i.IsTrial);
            }
        }

        /// <summary>
        /// Gets the start date of the Licence.
        /// </summary>
        public DateTime StartDate
        {
            get { return BASE_DATE.AddDays(_startDateOffset); }
        }

        /// <summary>
        /// Gets the end date of the Licence.
        /// </summary>
        public DateTime EndDate
        {
            get { return BASE_DATE.AddDays(_endDateOffset); }
        }

        /// <summary>
        /// Gets the number of days remaining on the Licence.
        /// </summary>
        public int DaysRemaining
        {
            get { return _endDateOffset - ConvertDate(DateTime.UtcNow.Date); }
        }

        /// <summary>
        /// Returns the largest date the Licence can store.
        /// </summary>
        public static DateTime MaxDate
        {
            get { return BASE_DATE.Date.AddDays(ushort.MaxValue).Date; }
        }
        
        #endregion

        #region Private Methods

        /// <summary>
        /// Validates the signature that follows the Licence data
        /// </summary>
        /// <param name="hashValue">Hash value</param>
        /// <param name="signedHashValue">Signed hash value</param>
        /// <param name="xmlKeyInfo">Public Key</param>
        /// <param name="hashAlg">Hash Algorithm</param>
        /// <returns>True if signature is valid</returns>
        private static bool DSAVerifyHash(byte[] hashValue, byte[] signedHashValue, string xmlKeyInfo, string hashAlg)
        {
            DSACryptoServiceProvider.UseMachineKeyStore = false;
            using (DSACryptoServiceProvider DSA = new DSACryptoServiceProvider())
            {
                DSA.ImportParameters(FromXmlString(xmlKeyInfo));
                DSASignatureDeformatter DSAFormatter = new DSASignatureDeformatter(DSA);
                DSAFormatter.SetHashAlgorithm(hashAlg);
                return DSAFormatter.VerifySignature(hashValue, signedHashValue);
            }
        }

        private static DSAParameters FromXmlString(String xmlString)
        {
            if (xmlString == null) throw new ArgumentNullException("xmlString");

            DSAParameters dsaParams = new DSAParameters();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            // P is always present
            String pString = xmlDoc.GetElementsByTagName("P")[0].InnerText;
            if (pString == null)
            {
                throw new CryptographicException("Element P missing");
            }
            dsaParams.P = Convert.FromBase64String(pString);

            // Q is always present
            String qString = xmlDoc.GetElementsByTagName("Q")[0].InnerText;
            if (qString == null)
            {
                throw new CryptographicException("Element Q missing");
            }
            dsaParams.Q = Convert.FromBase64String(qString);

            // G is always present
            String gString = xmlDoc.GetElementsByTagName("G")[0].InnerText;
            if (gString == null)
            {
                throw new CryptographicException("Element G missing");
            }
            dsaParams.G = Convert.FromBase64String(gString);

            // Y is always present
            String yString = xmlDoc.GetElementsByTagName("Y")[0].InnerText;
            if (yString == null)
            {
                throw new CryptographicException("Element Y missing");
            }
            dsaParams.Y = Convert.FromBase64String(yString);

            // J is optional
            String jString = xmlDoc.GetElementsByTagName("J")[0].InnerText;
            if (jString != null) dsaParams.J = Convert.FromBase64String(jString);

            // X is optional -- private key if present
            try
            {
                String xString = xmlDoc.GetElementsByTagName("X").Item(0).InnerText;
                if (xString != null) dsaParams.X = Convert.FromBase64String(xString);
            }
            catch { }

            // Seed and PgenCounter are optional as a unit -- both present or both absent
            String seedString = xmlDoc.GetElementsByTagName("Seed")[0].InnerText;
            String pgenCounterString = xmlDoc.GetElementsByTagName("PgenCounter")[0].InnerText;
            if ((seedString != null) && (pgenCounterString != null))
            {
                dsaParams.Seed = Convert.FromBase64String(seedString);
                dsaParams.Counter = ConvertByteArrayToInt(Convert.FromBase64String(pgenCounterString));
            }
            else if ((seedString != null) || (pgenCounterString != null))
            {
                if (seedString == null)
                {
                    throw new CryptographicException("Seed missing");
                }
                else
                {
                    throw new CryptographicException("PgenCounter missing");
                }
            }

            return dsaParams;
        }

        internal static int ConvertByteArrayToInt(byte[] input)
        {
            // Input to this routine is always big endian
            int dwOutput = 0;
            for (int i = 0; i < input.Length; i++)
            {
                dwOutput *= 256;
                dwOutput += input[i];
            }
            return (dwOutput);
        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Converts a date for internal storage as a ushort.
        /// </summary>
        /// <param name="date">Date to be converted.</param>
        /// <returns>The ushort value that represents the date internally.</returns>
        protected static ushort ConvertDate(DateTime date)
        {
            if (date > MaxDate)
                throw new ArgumentOutOfRangeException("date",
                    String.Format("Can not be greater then {0}.",
                    MaxDate));

            return (ushort)(date.Date - BASE_DATE).Days;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the encoded text for the licence key.
        /// </summary>
        /// <returns>Encoded text for the licence key.</returns>
        public override string ToString()
        {
            return _encodedText;
        }

        /// <summary>
        /// Persists data about the Licence.        
        /// Writer attached to an output stream for data storage.
        /// </summary>
        public byte[] ToArray()
        {
            using (BinaryWriter writer = new BinaryWriter(new MemoryStream()))
            {
                writer.Write(LicenceId);
                writer.Write(_startDateOffset);
                writer.Write(_endDateOffset);
                writer.Write((byte)_products.Count);
                foreach (Product product in _products)
                {
                    product.Write(writer);
                }
                return ((MemoryStream)writer.BaseStream).ToArray();
            }
        }

        #endregion
    }
}
