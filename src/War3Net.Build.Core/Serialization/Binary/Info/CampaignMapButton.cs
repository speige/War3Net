﻿// ------------------------------------------------------------------------------
// <copyright file="CampaignMapButton.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.IO;

using War3Net.Common.Extensions;

namespace War3Net.Build.Info
{
    public sealed partial class CampaignMapButton
    {
        internal CampaignMapButton(BinaryReader reader, CampaignInfoFormatVersion formatVersion)
        {
            ReadFrom(reader, formatVersion);
        }

        internal void ReadFrom(BinaryReader reader, CampaignInfoFormatVersion formatVersion)
        {
            IsVisibleInitially = reader.ReadInt32();
            Chapter = reader.ReadChars();
            Title = reader.ReadChars();
            MapFilePath = reader.ReadChars();
        }

        internal void WriteTo(BinaryWriter writer, CampaignInfoFormatVersion formatVersion)
        {
            writer.Write(IsVisibleInitially);
            writer.WriteString(Chapter);
            writer.WriteString(Title);
            writer.WriteString(MapFilePath);
        }
    }
}