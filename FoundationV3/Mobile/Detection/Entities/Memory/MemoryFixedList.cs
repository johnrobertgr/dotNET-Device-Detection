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

using FiftyOne.Foundation.Mobile.Detection.Factories;
using FiftyOne.Foundation.Mobile.Detection.Readers;

namespace FiftyOne.Foundation.Mobile.Detection.Entities.Memory
{
    /// <summary>
    /// A readonly list of fixed length entity types held in memory.
    /// </summary>
    /// <para>
    /// Entities in the underlying data structure are either fixed length where 
    /// the data that represents them always contains the same number of bytes, 
    /// or variable length where the number of bytes to represent the entity 
    /// varies.
    /// </para>
    /// <para>
    /// This class uses the index of the entity in the accessor. The list is 
    /// typically used by entities that need to be found quickly using a divide 
    /// and conquer algorithm.
    /// </para>
    /// <remarks>
    /// The constructor will read the header information about the underlying 
    /// data structure and the entities are added to the list when the Read 
    /// method is called.
    /// </remarks>
    /// <remarks>
    /// The class supports source stream that doesn't support seeking.
    /// </remarks>
    /// <remarks>Not intended to be used directly by 3rd parties.</remarks>
    /// <typeparam name="T">
    /// The type of item the list will contain.
    /// </typeparam>
    /// <typeparam name="D">
    /// The type of the shared data set the item is contained within.
    /// </typeparam>
    public class MemoryFixedList<T, D> : MemoryBaseList<T, D>, IReadonlyList<T>
    {
        #region Constructor

        /// <summary>
        /// Constructs a new instance of <see cref="MemoryFixedList{T,D}"/>.
        /// </summary>
        /// <param name="dataSet">
        /// The <see cref="DataSet"/> being created.
        /// </param>
        /// <param name="reader">
        /// Reader connected to the source data structure and positioned to 
        /// start reading.
        /// </param>
        /// <param name="entityFactory">
        /// Used to create new instances of the entity.
        /// </param>
        public MemoryFixedList(D dataSet, Reader reader, BaseEntityFactory<T, D> entityFactory)
            : base(dataSet, reader, entityFactory)
        {
        }

        #endregion

        #region Overridden Methods

        /// <summary>
        /// Reads the list into memory.
        /// </summary>
        /// <param name="reader">
        /// Reader connected to the source data structure and positioned to 
        /// start reading.
        /// </param>
        public override void Read(Reader reader)
        {
            for (int index = 0; index < Header.Count; index++)
            {
                _array[index] = (T)EntityFactory.Create(_dataSet, index, reader);
            }
        }

        #endregion

        #region Accessor

        /// <summary>
        /// Accessor for the fixed list.
        /// </summary>
        /// <param name="index">
        /// The index of the entity to be returned from the list.
        /// </param>
        /// <returns>
        /// Entity at the index requested.
        /// </returns>
        public T this[int index]
        {
            get { return _array[index]; }
        }

        /// <summary>
        /// An enumeration for the underlying array.
        /// </summary>
        /// <returns>
        /// An enumeration for the underlying array.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
        
        #endregion
    }
}
