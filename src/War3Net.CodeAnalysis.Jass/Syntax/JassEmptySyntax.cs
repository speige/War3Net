﻿// ------------------------------------------------------------------------------
// <copyright file="JassEmptySyntax.cs" company="Drake53">
// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.
// </copyright>
// ------------------------------------------------------------------------------

namespace War3Net.CodeAnalysis.Jass.Syntax
{
    public class JassEmptySyntax : ITopLevelDeclarationSyntax, IScopedDeclarationSyntax, IGlobalDeclarationSyntax, IScopedGlobalDeclarationSyntax, IMemberDeclarationSyntax, IStatementSyntax, IDeclarationLineSyntax, IGlobalLineSyntax, IStatementLineSyntax, IJassSyntaxToken
    {
        public static readonly JassEmptySyntax Value = new JassEmptySyntax();

        private JassEmptySyntax()
        {
        }

        public bool Equals(ITopLevelDeclarationSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IScopedDeclarationSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IGlobalDeclarationSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IScopedGlobalDeclarationSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IMemberDeclarationSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IStatementSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IDeclarationLineSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IGlobalLineSyntax? other) => other is JassEmptySyntax;

        public bool Equals(IStatementLineSyntax? other) => other is JassEmptySyntax;

        public override string ToString() => string.Empty;
    }
}