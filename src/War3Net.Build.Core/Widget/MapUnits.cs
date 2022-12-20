﻿// ------------------------------------------------------------------------------
// <copyright file="MapUnits.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Collections.Generic;

using War3Net.Common.Extensions;

namespace War3Net.Build.Widget
{
    public sealed partial class MapUnits
    {
        public const string FileName = "war3mapUnits.doo";

        public static readonly int FileFormatSignature = "W3do".FromRawcode();

        /// <summary>
        /// Initializes a new instance of the <see cref="MapUnits"/> class.
        /// </summary>
        /// <param name="formatVersion"></param>
        /// <param name="subVersion"></param>
        /// <param name="useNewFormat"></param>
        public MapUnits(MapWidgetsFormatVersion formatVersion, MapWidgetsSubVersion subVersion, bool useNewFormat)
        {
            FormatVersion = formatVersion;
            SubVersion = subVersion;
            UseNewFormat = useNewFormat;
        }

        public MapWidgetsFormatVersion FormatVersion { get; set; }

        public MapWidgetsSubVersion SubVersion { get; set; }

        public bool UseNewFormat { get; set; }

        public List<UnitData> Units { get; init; } = new();

        public override string ToString() => FileName;
    }
}