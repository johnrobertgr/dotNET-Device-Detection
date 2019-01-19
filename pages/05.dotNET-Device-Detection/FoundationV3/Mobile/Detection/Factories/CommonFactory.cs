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

using FiftyOne.Foundation.Mobile.Detection.Entities;
using System;
using System.IO;
using System.Linq;

namespace FiftyOne.Foundation.Mobile.Detection.Factories
{
    /// <summary>
    /// Extension methods used to load data into the data set entity.
    /// Used at the start of both memory and stream factories.
    /// Objects of this class should not be created directly as they 
    /// are part of the internal logic.
    /// </summary>
    internal static class CommonFactory
    {
        /// <summary>
        /// Loads the data set headers information.
        /// </summary>
        /// <param name="dataSet">The data set to be loaded</param>
        /// <param name="reader">Reader positioned at the beginning of the
        /// data source</param>
        internal static void LoadHeader(DataSet dataSet, BinaryReader reader)
        {
            // Check for an exception which would indicate the file is the 
            // wrong type for the API.
            try
            {
                dataSet.Version = new Version(
                    reader.ReadInt32(),
                    reader.ReadInt32(),
                    reader.ReadInt32(),
                    reader.ReadInt32());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new MobileException(String.Format(
                    "Data file is invalid. Check that the data file is " +
                    "decompressed and is version '{0}' format.",
                    String.Join(",", BinaryConstants.SupportedPatternFormatVersions.Select(i =>
                        i.Value.ToString()))), ex);
            }

            // Throw exception if the data file does not have the correct
            // version in formation.
            if (BinaryConstants.SupportedPatternFormatVersions.Any(i => i.Value.Equals(dataSet.Version)) == false)
            {
                throw new MobileException(String.Format(
                    "Version mismatch. Data is version '{0}' for '{1}' reader",
                    dataSet.Version,
                    String.Join(",", BinaryConstants.SupportedPatternFormatVersions.Select(i => 
                        i.Value.ToString()))));
            }

            // Set the enum format version value for easier if logic.
            dataSet.VersionEnum = BinaryConstants.SupportedPatternFormatVersions.FirstOrDefault(i => 
                i.Value.Equals(dataSet.Version)).Key;

            // Read the common header fields.
            dataSet.Tag = new Guid(reader.ReadBytes(16));
            switch(dataSet.VersionEnum)
            {
                case BinaryConstants.FormatVersions.PatternV32:
                    dataSet.Export = new Guid(reader.ReadBytes(16));
                    break;
            }
            dataSet.CopyrightOffset = reader.ReadInt32();
            dataSet.AgeAtPublication = new TimeSpan(reader.ReadInt16() * TimeSpan.TicksPerDay * 30);
            dataSet.MinUserAgentCount = reader.ReadInt32();
            dataSet.NameOffset = reader.ReadInt32();
            dataSet.FormatOffset = reader.ReadInt32();
            dataSet.Published = ReadDate(reader);
            dataSet.NextUpdate = ReadDate(reader);
            dataSet.DeviceCombinations = reader.ReadInt32();
            dataSet.MaxUserAgentLength = reader.ReadInt16();
            dataSet.MinUserAgentLength = reader.ReadInt16();
            dataSet.LowestCharacter = reader.ReadByte();
            dataSet.HighestCharacter = reader.ReadByte();
            dataSet.MaxSignatures = reader.ReadInt32();
            dataSet.SignatureProfilesCount = reader.ReadInt32();
            dataSet.SignatureNodesCount = reader.ReadInt32();
            dataSet.MaxValues = reader.ReadInt16();
            dataSet.CsvBufferLength = reader.ReadInt32();
            dataSet.JsonBufferLength = reader.ReadInt32();
            dataSet.XmlBufferLength = reader.ReadInt32();
            dataSet.MaxSignaturesClosest = reader.ReadInt32();

            // Read the V32 headers specifically.
            if (dataSet.VersionEnum == BinaryConstants.FormatVersions.PatternV32)
            {
                dataSet._maximumRank = reader.ReadInt32();
            }
        }

        /// <summary>
        /// Reads a date in year, month and day order from the reader.
        /// </summary>
        /// <param name="reader">Reader positioned at the start of the date
        /// </param>
        /// <returns>A date time with the year, month and day set from the
        /// reader</returns>
        private static DateTime ReadDate(BinaryReader reader)
        {
            return new DateTime(reader.ReadInt16(), reader.ReadByte(), reader.ReadByte());
        }
    }
}
