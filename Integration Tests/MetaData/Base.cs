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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiftyOne.Foundation.Mobile.Detection.Entities;
using FiftyOne.Foundation.Mobile.Detection.Factories;
using System.IO;
using FiftyOne.Foundation.Mobile.Detection;

namespace FiftyOne.Tests.Integration.MetaData
{
    [TestClass]
    public abstract class Base : IDisposable
    {
        protected DataSet _dataSet;

        protected abstract string DataFile { get; }

        protected void RetrieveComponents()
        {
            foreach (var component in _dataSet.Components)
            {
                Console.WriteLine("Testing Component '{0}", component);
                Console.WriteLine("Default Profile '{0}'", component.DefaultProfile);
                foreach(var property in component.Properties)
                {
                    Console.WriteLine("\tProperty '{0}'", property);
                }
                foreach(var profile in component.Profiles)
                {
                    Console.WriteLine("\tProfile '{0}'", profile);
                }
            }
        }

        protected void ValidatePropertiesHaveDescription()
        {
            foreach (Property prop in _dataSet.Properties)
            {
                Assert.IsNotNull(prop.Description);
            }
        }

        protected void RetrieveProperties()
        {
            foreach(var property in _dataSet.Properties)
            {
                Console.WriteLine("Testing Property '{0}'", property);
                Console.WriteLine("Category '{0}'", property.Category);
                Console.WriteLine("Component '{0}'", property.Component);
                Console.WriteLine("Default Value '{0}'", property.DefaultValue);                
                Console.WriteLine("Description '{0}'", property.Description);
                Console.WriteLine("Display Order '{0}'", property.DisplayOrder);
                Console.WriteLine("IsList '{0}'", property.IsList);
                Console.WriteLine("IsMandatory '{0}'", property.IsMandatory);
                Console.WriteLine("IsObsolete '{0}'", property.IsObsolete);
                Console.WriteLine("JavaScriptName '{0}'", property.JavaScriptName);
                Console.WriteLine("Maps '{0}'", String.Join(", ", property.Maps));
                Console.WriteLine("Show '{0}'", property.Show);
                Console.WriteLine("ShowValues '{0}'", property.ShowValues);
                Console.WriteLine("Url '{0}'", property.Url);
                Console.WriteLine("Property Type '{0}'", property.ValueType);

                foreach(var value in property.Values)
                {
                    Console.WriteLine("\t{0}", value);
                }
            }
        }

        protected void CheckPropertyCount(int expectedCount)
        {
            Assert.IsTrue(_dataSet.Properties.Count >= expectedCount, String.Format(
                "Property count lower than '{0}'.", expectedCount));
        }

        protected void RetrieveValues()
        {
            foreach(var value in _dataSet.Values)
            {
                Console.WriteLine("Testing Value '{0}", value);
                Console.WriteLine("Property Name '{0}'", value.Property);
                Console.WriteLine("IsDefault '{0}'", value.IsDefault);
            }
        }

        [TestCleanup]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_dataSet != null)
            {
                _dataSet.Dispose();
            }
        }
    }
}
