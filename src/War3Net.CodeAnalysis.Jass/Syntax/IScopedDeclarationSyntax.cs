﻿// ------------------------------------------------------------------------------
// <copyright file="IScopedDeclarationSyntax.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System;

namespace War3Net.CodeAnalysis.Jass.Syntax
{
    public interface IScopedDeclarationSyntax : IEquatable<IScopedDeclarationSyntax>, IJassSyntaxToken
    {
    }
}