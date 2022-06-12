﻿// ------------------------------------------------------------------------------
// <copyright file="VJassStaticIfScopedDeclarationSyntax.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;

using War3Net.CodeAnalysis.VJass.Extensions;

namespace War3Net.CodeAnalysis.VJass.Syntax
{
    public class VJassStaticIfScopedDeclarationSyntax : VJassScopedDeclarationSyntax
    {
        internal VJassStaticIfScopedDeclarationSyntax(
            VJassScopedDeclarationStaticIfClauseSyntax staticIfClause,
            ImmutableArray<VJassScopedDeclarationElseIfClauseSyntax> elseIfClauses,
            VJassScopedDeclarationElseClauseSyntax? elseClause,
            VJassSyntaxToken endIfToken)
        {
            StaticIfClause = staticIfClause;
            ElseIfClauses = elseIfClauses;
            ElseClause = elseClause;
            EndIfToken = endIfToken;
        }

        public VJassScopedDeclarationStaticIfClauseSyntax StaticIfClause { get; }

        public ImmutableArray<VJassScopedDeclarationElseIfClauseSyntax> ElseIfClauses { get; }

        public VJassScopedDeclarationElseClauseSyntax? ElseClause { get; }

        public VJassSyntaxToken EndIfToken { get; }

        public override bool IsEquivalentTo([NotNullWhen(true)] VJassSyntaxNode? other)
        {
            return other is VJassStaticIfScopedDeclarationSyntax staticIfScopedDeclaration
                && StaticIfClause.IsEquivalentTo(staticIfScopedDeclaration.StaticIfClause)
                && ElseIfClauses.IsEquivalentTo(staticIfScopedDeclaration.ElseIfClauses)
                && ElseClause.NullableEquivalentTo(staticIfScopedDeclaration.ElseClause);
        }

        public override void WriteTo(TextWriter writer)
        {
            StaticIfClause.WriteTo(writer);
            ElseIfClauses.WriteTo(writer);
            ElseClause?.WriteTo(writer);
            EndIfToken.WriteTo(writer);
        }

        public override string ToString() => StaticIfClause.ToString();

        public override VJassSyntaxToken GetFirstToken() => StaticIfClause.GetFirstToken();

        public override VJassSyntaxToken GetLastToken() => EndIfToken;

        protected internal override VJassStaticIfScopedDeclarationSyntax ReplaceFirstToken(VJassSyntaxToken newToken)
        {
            return new VJassStaticIfScopedDeclarationSyntax(
                StaticIfClause.ReplaceFirstToken(newToken),
                ElseIfClauses,
                ElseClause,
                EndIfToken);
        }

        protected internal override VJassStaticIfScopedDeclarationSyntax ReplaceLastToken(VJassSyntaxToken newToken)
        {
            return new VJassStaticIfScopedDeclarationSyntax(
                StaticIfClause,
                ElseIfClauses,
                ElseClause,
                newToken);
        }
    }
}