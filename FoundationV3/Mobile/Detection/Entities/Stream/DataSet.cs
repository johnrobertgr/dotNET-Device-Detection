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

namespace FiftyOne.Foundation.Mobile.Detection.Entities.Stream
{
    /// <summary>
    /// A data set returned from the stream factory which includes a pool of
    /// data readers that are used to fetch data from the source when
    /// the data set is used to retrieve data not already in memory.
    /// </summary>
    /// <para>
    /// Created by <see cref="FiftyOne.Foundation.Mobile.Detection.Factories.StreamFactory"/>. 
    /// Since stream works with file directly a pool of readers is maintained 
    /// until the dataset is closed. Class provides extra methods to check how 
    /// many readers were created and how many are currently free to use.
    /// </para>
    public class DataSet : IndirectDataSet, IStreamDataSet
    {
        #region Internal Properties

        /// <summary>
        /// Advises FindProfiles methods that the profiles associated with 
        /// a value should be referenced explicitly.
        /// </summary>
        internal override bool FindProfilesInitialiseValueProfiles
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new stream <see cref="DataSet"/> connected to the data
        /// file provided.
        /// </summary>
        /// <param name="fileName">
        /// Valid path to the uncompressed data set file.
        /// </param>
        /// <param name="lastModified">
        /// Date and time the source data was last modified.
        /// </param>
        /// <param name="mode">
        /// The mode of operation the data set will be using.
        /// </param>
        /// <param name="isTempFile">
        /// True if the file should be deleted when the source is disposed.
        /// </param>
        internal DataSet(string fileName, DateTime lastModified, Modes mode, bool isTempFile)
            : base(fileName, lastModified, mode, isTempFile)
        { }

        /// <summary>
        /// Creates a new stream data set connected to the byte array
        /// data source provided.
        /// </summary>
        /// <param name="data">
        /// Byte array containing uncompressed data set.
        /// </param>
        /// <param name="mode">
        /// The mode of operation the data set will be using.
        /// </param>
        internal DataSet(byte[] data, Modes mode)
            : base(data, mode)
        { }

        #endregion

        #region Destructor

        /// <summary>
        /// Disposes of the data set closing all readers and streams in 
        /// the pool. If a temporary data file is used then the file
        /// is also deleted if it's not being used by other processes.
        /// </summary>
        /// <param name="disposing">
        /// True if the calling method is Dispose, false for the finaliser.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            Source.Dispose();
            base.Dispose(disposing);
        }

        #endregion
        
    }
}