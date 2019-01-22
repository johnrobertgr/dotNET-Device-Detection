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

namespace FiftyOne.Tests.Integration.Performance.Lite
{
    [TestClass]
    public class V31Memory : Memory
    {
        protected override int MaxInitializeTime
        {
            get { return 10000; }
        }

        protected override string DataFile
        {
            get { return Utils.GetDataFile(Constants.LITE_PATTERN_V31); }
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_InitializeTime()
        {
            base.InitializeTime();
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_BadUserAgentsMulti()
        {
            base.BadUserAgentsMulti(null, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_BadUserAgentsSingle()
        {
            base.BadUserAgentsSingle(null, 2);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_UniqueUserAgentsMulti()
        {
            base.UniqueUserAgentsMulti(null, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_UniqueUserAgentsSingle()
        {
            base.UniqueUserAgentsSingle(null, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_RandomUserAgentsMulti()
        {
            base.RandomUserAgentsMulti(null, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_RandomUserAgentsSingle()
        {
            base.RandomUserAgentsSingle(null, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_BadUserAgentsMultiAll()
        {
            base.BadUserAgentsMulti(_dataSet.Properties, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_BadUserAgentsSingleAll()
        {
            base.BadUserAgentsSingle(_dataSet.Properties, 2);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_UniqueUserAgentsMultiAll()
        {
            base.UniqueUserAgentsMulti(_dataSet.Properties, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_UniqueUserAgentsSingleAll()
        {
            base.UniqueUserAgentsSingle(_dataSet.Properties, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_RandomUserAgentsMultiAll()
        {
            base.RandomUserAgentsMulti(_dataSet.Properties, 1);
        }

        [TestMethod]
        [TestCategory("Performance"), TestCategory("Memory"), TestCategory("Lite")]
        public void LiteV31Memory_Performance_RandomUserAgentsSingleAll()
        {
            base.RandomUserAgentsSingle(_dataSet.Properties, 1);
        }
    }
}
