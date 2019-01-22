﻿/* *********************************************************************
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited.
 * Copyright (c) 2017 51Degrees Mobile Experts Limited, 5 Charlotte Close,
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
 * This Source Code Form is "Incompatible With Secondary Licenses", as
 * defined by the Mozilla Public License, v. 2.0.
 */

using FiftyOne.Foundation.Mobile.Detection.Entities;

namespace FiftyOne.Foundation.Mobile.Detection.Caching
{
    /// <summary>
    /// Class used to store implementations of caches that
    /// will be used for different entities
    /// </summary>
    internal class CacheMap
    {
        /// <summary>
        /// The cache used to store <see cref="Node"/> objects in memory 
        /// </summary>
        public ICache<int, Node> NodeCache { get; set; }

        /// <summary>
        /// The cache used to store <see cref="Signature"/> objects in memory 
        /// </summary>
        public ICache<int, Signature> SignatureCache { get; set; }

        /// <summary>
        /// The cache used to store <see cref="AsciiString"/> objects in memory 
        /// </summary>
        public ICache<int, AsciiString> StringCache { get; set; }

        /// <summary>
        /// The cache used to store <see cref="Value"/> objects in memory 
        /// </summary>
        public ICache<int, Value> ValueCache { get; set; }

        /// <summary>
        /// The cache used to store <see cref="Profile"/> objects in memory 
        /// </summary>
        public ICache<int, Profile> ProfileCache { get; set; }
    }
}
