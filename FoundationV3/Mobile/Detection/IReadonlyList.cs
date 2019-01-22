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

using System.Collections.Generic;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using System;

namespace FiftyOne.Foundation.Mobile.Detection
{
    /// <summary>
    /// A list which only provides those features needed to read items from
    /// the list.
    /// </summary>
    /// <typeparam name="T">The type of item the list will contain</typeparam>
    public interface IReadonlyList<T> : IDisposable, IEnumerable<T>
    {
        /// <summary>
        /// Accessor for the list.
        /// </summary>
        /// <param name="key">Index or offset of the entity required</param>
        /// <returns></returns>
        T this[int key] { get; }

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        int Count { get; }
    }
}
