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

namespace FiftyOne.Foundation.Mobile.Detection.Entities
{
    public abstract class BaseDataSet : IDisposable
    {
        /// <summary>
        /// Set when the disposed method is called indicating the data
        /// set is no longer valid and can't be used.
        /// </summary>
        public bool Disposed { get; private set; }

        /// <summary>
        /// Constructs a new instance of <see cref="BasaDataSet"/>.
        /// </summary>
        protected BaseDataSet()
        {
        }

        #region Destructor

        /// <summary>
        /// Disposes of all the lists that form the dataset.
        /// </summary>
        ~BaseDataSet()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes of all the lists that form the dataset.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes of the readonly lists used by the dataset.
        /// </summary>
        /// <param name="disposing">
        /// True if the calling method is Dispose, false for the finaliser.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}