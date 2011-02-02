﻿/* *********************************************************************
 * The contents of this file are subject to the Mozilla Public License 
 * Version 1.1 (the "License"); you may not use this file except in 
 * compliance with the License. You may obtain a copy of the License at 
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS" 
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
 * See the License for the specific language governing rights and 
 * limitations under the License.
 *
 * The Original Code is named .NET Mobile API, first released under 
 * this licence on 11th March 2009.
 * 
 * The Initial Developer of the Original Code is owned by 
 * 51 Degrees Mobile Experts Limited. Portions created by 51 Degrees 
 * Mobile Experts Limited are Copyright (C) 2009 - 2011. All Rights Reserved.
 * 
 * Contributor(s):
 *     James Rosewell <james@51degrees.mobi>
 * 
 * ********************************************************************* */

namespace FiftyOne.Foundation.Mobile.Detection.Wurfl.Handlers
{
    internal class PalmHandler : EditDistanceHandler
    {
        // This handler will only handle specific strings used by Palm devices
        // and will therefore be more accurate than more general handlers.
        private const int CONFIDENCE = 7;

        internal override byte Confidence
        {
            get { return CONFIDENCE; }
        }

        // Checks given UA starts with "Palm" and "webOS"
        protected internal override bool CanHandle(string userAgent)
        {
            return (userAgent.Contains("Palm") && userAgent.Contains("webOS")) ||
                userAgent.Contains("PalmSource") || userAgent.Contains("Palmsource");
        }
    }
}