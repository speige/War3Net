﻿// ------------------------------------------------------------------------------
// <copyright file="StreamReaderExtensions.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.IO;

using War3Net.Build.Script;

namespace War3Net.Build.Extensions
{
    public static class StreamReaderExtensions
    {
        public static TriggerStrings ReadTriggerStrings(this StreamReader reader, bool fromCampaign = false) => fromCampaign ? new CampaignTriggerStrings(reader) : new MapTriggerStrings(reader);

        public static MapTriggerString ReadTriggerString(this StreamReader reader) => new MapTriggerString(reader);
    }
}