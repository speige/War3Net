﻿// ------------------------------------------------------------------------------
// <copyright file="JassHexadecimalLiteralExpressionSyntax.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;

namespace War3Net.CodeAnalysis.Jass.Syntax
{
    public class JassHexadecimalLiteralExpressionSyntax : IExpressionSyntax, IJassSyntaxToken
    {
        public JassHexadecimalLiteralExpressionSyntax(int value)
        {
            Value = value;
        }

        public int Value { get; init; }

        public bool Equals(IExpressionSyntax? other)
        {
            return other is JassHexadecimalLiteralExpressionSyntax hexadecimalLiteralExpression
                && Value == hexadecimalLiteralExpression.Value;
        }

        public override string ToString() => $"{JassSymbol.Zero}{JassSymbol.X}" + Convert.ToString(Value, 16).ToUpperInvariant();
    }
}