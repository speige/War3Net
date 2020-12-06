﻿// ------------------------------------------------------------------------------
// <copyright file="TypeDefinitionTranspiler.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.Text;

using War3Net.CodeAnalysis.Jass.Syntax;

namespace War3Net.CodeAnalysis.Transpilers
{
    public static partial class JassToLuaTranspiler
    {
        [Obsolete]
        public static void Transpile(this TypeDefinitionSyntax typeDefinitionNode, ref StringBuilder sb)
        {
            // _ = typeDefinitionNode ?? throw new ArgumentNullException(nameof(typeDefinitionNode));

            throw new NotSupportedException();
        }

        public static void TranspileToLua(this TypeDefinitionSyntax typeDefinitionNode)
        {
            // _ = typeDefinitionNode ?? throw new ArgumentNullException(nameof(typeDefinitionNode));

            throw new NotSupportedException();
        }
    }
}