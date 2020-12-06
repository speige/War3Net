﻿// ------------------------------------------------------------------------------
// <copyright file="ArgumentListTranspiler.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CSharpLua.LuaAst;

using War3Net.CodeAnalysis.Jass.Syntax;

namespace War3Net.CodeAnalysis.Transpilers
{
    public static partial class JassToLuaTranspiler
    {
        [Obsolete]
        public static void Transpile(this ArgumentListSyntax argumentListNode, ref StringBuilder sb)
        {
            _ = argumentListNode ?? throw new ArgumentNullException(nameof(argumentListNode));

            var firstArgument = true;
            foreach (var argumentNode in argumentListNode)
            {
                if (firstArgument)
                {
                    firstArgument = false;
                }
                else
                {
                    sb.Append(", ");
                }

                argumentNode.Transpile(ref sb);
            }
        }

        public static IEnumerable<LuaExpressionSyntax> TranspileToLua(this ArgumentListSyntax argumentListNode)
        {
            _ = argumentListNode ?? throw new ArgumentNullException(nameof(argumentListNode));

            return argumentListNode.Select(argument => argument.TranspileToLua());
        }
    }
}