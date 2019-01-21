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
using System.Collections.Generic;

namespace FiftyOne.Foundation.Mobile.Detection
{
    /// <summary>
    /// Constants used to control major aspects of redirection.
    /// </summary>
    public static class Constants
    {
        #region Public Constants

        /// <summary>
        /// The prefix to apply to the cookie name when used in the client.
        /// </summary>
        public const string PropertyValueOverrideCookiePrefix = "51D_";

        /// <summary>
        /// Used to indicate if property value override is enabled.
        /// </summary>
        public const string PropertyValueOverrideFlag = "51D_PVO";

        /// <summary>
        /// The dafult name of the profile override cookie.
        /// </summary>
        public const string ProfileOverrideCookieName =
            PropertyValueOverrideCookiePrefix + "ProfileIds";

        /// <summary>
        /// The default path to use for the binary data file.
        /// </summary>
        public const string DefaultBinaryFilePath = "~/App_Data/51Degrees.dat";

        /// <summary>
        /// The location to create and manage temporary files.
        /// </summary>
        public const string TemporaryFilePath = "~/App_Data/51Degrees";

        /// <summary>
        /// The preferred name of the licence key file.
        /// </summary>
        public const string LicenceKeyFileName = "51Degrees.lic";

        /// <summary>
        /// The character used to seperate property values when concatenated as a single string.
        /// </summary>
        public const string ValueSeperator = "|";

        /// <summary>
        /// The character used to seperate profile integer values  in the device id.
        /// </summary>
        public const string ProfileSeperator = "-";

        /// <summary>
        /// The key used to identify the list of 51Degrees properties in the 
        /// capabilities collection of the HttpBrowserCapabilities class.
        /// </summary>
        public const string FiftyOneDegreesProperties = "51Degrees";

        /// <summary>
        /// The length of time taken to locate the device returned. This property is 
        /// set in the MobileCapabilities class and is not part of the Providers.
        /// </summary>
        public const string DetectionTimeProperty = "DetectionTime";

        /// <summary>
        /// The difference between the target and the result.
        /// </summary>
        public const string DifferenceProperty = "Difference";

        /// <summary>
        /// The name of the unique property key used to return the device id.
        /// </summary>
        public const string DeviceId = "Id";

        /// <summary>
        /// The name of the unique property key used to return the relevent characters
        /// from the target User-Agent string.
        /// </summary>
        public const string Nodes = "Nodes";

        /// <summary>
        /// The key in the context.Items collection to the <see cref="Match"/>
        /// object associated with the request.
        /// </summary>
        public const string MatchKey = "51D_Match";

        /// <summary>
        /// A regular expression used to valid licence key formats.
        /// </summary>
        public const string LicenceKeyValidationRegex = @"^[A-Z\d]+$";

        #endregion

        #region Internal Constants

#if !SQL_BUILD && !NETSTANDARD1_6
        /// <summary>
        /// The name of the category 
        /// <see cref="FiftyOne.Foundation.Mobile.Detection.Entities.Property.PropertyValueType.JavaScript"/>
        /// properties which should be used for
        /// <see cref="FiftyOne.Foundation.Mobile.Detection.Feature.PropertyValueOverride"/> 
        /// methods must be assigned.
        /// </summary>
        internal const string PropertyValueOverrideCategory = "Property Value Override";
#endif

        /// <summary>
        /// Used to split up a cookie string.
        /// </summary>
        internal static readonly char[] CookieSplitter = new char[] { ';' };

        /// <summary>
        /// Name of the cookie used by MVC to override browser details.
        /// </summary>
        internal const string MvcBrowserOverrideCookie = ".ASPXBrowserOverride";

        /// <summary>
        /// The copyright message to add to all javascript. This message can not 
        /// be altered by 3rd parties.
        /// </summary>
        internal const string ClientSidePropertyCopyright = "// Copyright 51 Degrees Mobile Experts Limited";

        /// <summary>
        /// The name of the 1x1 pixel empty gif image.
        /// </summary>
        internal const string EmptyImageResourceName = "FiftyOne.Foundation.Image.E.gif";

        /// <summary>
        /// The number of User-Agents to cache.
        /// </summary>
        internal const int UserAgentCacheSize = 1000;

        /// <summary>
        /// If premium data is being used with Foundation the licence key
        /// can be provided in the following constant or in a file with the
        /// extension .lic in the bin folder.
        /// </summary>
        internal const string PremiumLicenceKey = "";

        /// <summary>
        /// The URL to use to get the latest device data from if a Premium licence key is provided.
        /// </summary>
#if DEBUG
        internal const string AutoUpdateUrl = "https://distributor.51degrees.com/api/v2/download";
#else
        // NEVER CHANGE THE RELEASE URL LINK TO THE PRODUCTION DATA DISTRIBUTOR
        internal const string AutoUpdateUrl = "https://distributor.51degrees.com/api/v2/download";
#endif

        /// <summary>
        /// The length of time to wait before checking for a newer
        /// version of the device data file.
        /// </summary>
        internal static readonly TimeSpan AutoUpdateWait =
            new TimeSpan(1, 0, 0, 0);

        /// <summary>
        /// The length of time to wait before starting the auto update
        /// process. Set to zero to disable auto update.
        /// </summary>
        internal static readonly TimeSpan AutoUpdateDelayedStart =
            new TimeSpan(0, 0, 20);

        /// <summary>
        /// The length of time to sleep before checking for new device
        /// data again.
        /// </summary>
        internal static readonly TimeSpan AutoUpdateSleep =
            new TimeSpan(0, 6, 0, 0);

        /// <summary>
        /// The length of time to wait before setting the local data file
        /// check process.
        /// </summary>
        internal static readonly TimeSpan FileUpdateDelayedStart =
            new TimeSpan(0, 0, 2, 0);

        /// <summary>
        /// The length of time between local data file checks.
        /// </summary>
        internal static readonly TimeSpan FileUpdateSleep =
            new TimeSpan(0, 1, 0, 0);

        /// <summary>
        /// Length of time in ms the new devices thread should wait for a response from the
        /// web server used to record new device information.
        /// </summary>
        internal const int NewUrlTimeOut = 10000;

        /// <summary>
        /// The maximum number of continous timeouts that are allowed
        /// before the new device function is disabled.
        /// </summary>
        internal const int NewUrlMaxTimeouts = 10;

        /// <summary>
        /// Array of HTTP headers that represent the useragent string of the
        /// device rather than the browser.
        /// </summary>
        [Obsolete("Replaced with embedded Http Headers in V3.2 data file.")]
        internal static readonly string[] DeviceUserAgentHeaders = new string[]
            {
                "Device-Stock-UA",
                "x-Device-User-Agent",
                "X-Device-User-Agent",
                "X-OperaMini-Phone-UA",
#pragma warning disable 618
                UserAgentHeader
#pragma warning restore 618
            };

        /// <summary>
        /// The Http header field that contains the User-Agent.
        /// </summary>
        [Obsolete("Replaced with embedded Http Headers in V3.2 data file.")]
        internal const string UserAgentHeader = "User-Agent";

        /// <summary>
        /// The URL usage sharing information should be sent to.
        /// </summary>
        internal const string NewDevicesUrl = "https://devices.51degrees.com/new.ashx";
        
        /// <summary>
        /// The detail that should be provided relating to new devices.
        /// </summary>
        internal const NewDeviceDetails NewDeviceDetail = NewDeviceDetails.Maximum;

        /// <summary>
        /// The number of requests that should be held in the queue before
        /// transmission.
        /// </summary>
        internal const int NewDeviceQueueLength = 50;
               
        /// <summary>
        /// The number of minutes to store request stats for before
        /// they are disgarded. Used by the bandwidth feature.
        /// </summary>
        internal const int RequestStatsValidityPeriod = 5;

        #endregion
    }
}