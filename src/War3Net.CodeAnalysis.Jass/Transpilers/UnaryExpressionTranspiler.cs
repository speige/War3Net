﻿// ------------------------------------------------------------------------------
// <copyright file="UnaryExpressionTranspiler.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.Text;

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace War3Net.CodeAnalysis.Jass.Transpilers
{
    public static partial class JassToCSharpTranspiler
    {
        public static ExpressionSyntax Transpile(this Syntax.UnaryExpressionSyntax unaryExpressionNode)
        {
            _ = unaryExpressionNode ?? throw new ArgumentNullException(nameof(unaryExpressionNode));

            return SyntaxFactory.PrefixUnaryExpression(
                unaryExpressionNode.UnaryOperatorNode.Transpile(),
                unaryExpressionNode.ExpressionNode.Transpile());
        }

        public static ExpressionSyntax Transpile(this Syntax.UnaryExpressionSyntax unaryExpressionNode, out bool @const)
        {
            _ = unaryExpressionNode ?? throw new ArgumentNullException(nameof(unaryExpressionNode));

            return SyntaxFactory.PrefixUnaryExpression(
                unaryExpressionNode.UnaryOperatorNode.Transpile(),
                unaryExpressionNode.ExpressionNode.Transpile(out @const));
        }
    }

    public static partial class JassToLuaTranspiler
    {
        public static void Transpile(this Syntax.UnaryExpressionSyntax unaryExpressionNode, ref StringBuilder sb)
        {
            _ = unaryExpressionNode ?? throw new ArgumentNullException(nameof(unaryExpressionNode));

            unaryExpressionNode.UnaryOperatorNode.Transpile(ref sb);
            unaryExpressionNode.ExpressionNode.Transpile(ref sb);
        }
    }
}