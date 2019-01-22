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
using FiftyOne.Foundation.Mobile.Detection.Factories;
using System.IO;
using FiftyOne.Foundation.Mobile.Detection;
using System.Collections.Generic;
using FiftyOne.Foundation.Mobile.Detection.Entities;

namespace FiftyOne.Tests.Integration.Performance
{
    [TestClass]
    public abstract class Array : Base
    {
        [TestInitialize()]
        public void CreateDataSet()
        {
            var start = DateTime.UtcNow;
            Utils.CheckFileExists(DataFile);
            _dataSet = StreamFactory.Create(File.ReadAllBytes(DataFile));
            _testInitializeTime = DateTime.UtcNow - start;
        }

        protected Utils.Results BadUserAgentsMulti(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        { 
            var results = base.UserAgentsMulti(
                UserAgentGenerator.GetBadUserAgents(), properties, maxDetectionTime); 
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) < 0.2, "Exact Method");
            assertCache(_dataSet);
            return results;
        }

        protected Utils.Results BadUserAgentsSingle(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        {
            var results = base.UserAgentsSingle(
                UserAgentGenerator.GetBadUserAgents(), properties, maxDetectionTime);
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) < 0.2, "Exact Method");
            assertCache(_dataSet);
            return results;
        }

        protected Utils.Results RandomUserAgentsMulti(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        {
            var results = base.UserAgentsMulti(
                UserAgentGenerator.GetRandomUserAgents(), properties, maxDetectionTime);
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) > 0.95, "Exact Method");
            assertCache(_dataSet);
            return results;
        }

        protected Utils.Results RandomUserAgentsSingle(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        {
            var results = base.UserAgentsSingle(
                UserAgentGenerator.GetRandomUserAgents(), properties, maxDetectionTime);
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) > 0.95, "Exact Method");
            assertCache(_dataSet);
            return results;
        }

        protected Utils.Results UniqueUserAgentsMulti(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        {
            var results = base.UserAgentsMulti(
                UserAgentGenerator.GetUniqueUserAgents(), properties, maxDetectionTime); 
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) > 0.95, "Exact Method");
            assertCache(_dataSet);
            return results;
        }

        protected Utils.Results UniqueUserAgentsSingle(IEnumerable<Property> properties, Asserts.AssertCache assertCache, int maxDetectionTime) 
        {
            var results = base.UserAgentsSingle(
                UserAgentGenerator.GetUniqueUserAgents(), properties, maxDetectionTime); 
            Assert.IsTrue(results.GetMethodPercentage(MatchMethods.Exact) > 0.95, "Exact Method");
            assertCache(_dataSet);
            return results;
        }
    }
}
