﻿// ------------------------------------------------------------------------------
// <copyright file="GlobalConstantDeclarationTranspiler.cs" company="Drake53">
// Copyright (c) 2019 Drake53. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// ------------------------------------------------------------------------------

#pragma warning disable SA1649 // File name should match first type name

using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using War3Net.CodeAnalysis.CSharp.Attributes;

namespace War3Net.CodeAnalysis.Jass.Transpilers
{
    public static partial class JassToCSharpTranspiler
    {
        public static MemberDeclarationSyntax Transpile(this Syntax.GlobalConstantDeclarationSyntax globalConstantDeclarationNode)
        {
            _ = globalConstantDeclarationNode ?? throw new ArgumentNullException(nameof(globalConstantDeclarationNode));

            var identifier = SyntaxFactory.Identifier(
                SyntaxTriviaList.Empty,
                SyntaxKind.IdentifierToken,
                globalConstantDeclarationNode.IdentifierNameNode.TranspileIdentifier(),
                globalConstantDeclarationNode.IdentifierNameNode.ValueText,
                SyntaxTriviaList.Empty);

            var globalConstantDeclaration = SyntaxFactory.FieldDeclaration(
                SyntaxFactory.VariableDeclaration(globalConstantDeclarationNode.TypeNameNode.Transpile())
                .AddVariables(
                    SyntaxFactory.VariableDeclarator(
                        identifier,
                        null,
                        globalConstantDeclarationNode.EqualsValueClause.Transpile(out var isConstantExpression))));

            var isAddedToEnum = false;
            var expr = globalConstantDeclarationNode.EqualsValueClause.ValueNode.Expression;
            if (expr.FunctionCall != null)
            {
                var convertFunctionName = expr.FunctionCall.IdentifierNameNode.ValueText;
                if (TranspileToEnumHandler.IsFunctionEnumConverter(convertFunctionName, out var enumTypeName))
                {
                    var enumMember = SyntaxFactory.EnumMemberDeclaration(
                        new SyntaxList<AttributeListSyntax>(
                            SyntaxFactory.AttributeList(
                                default(SeparatedSyntaxList<AttributeSyntax>).Add(SyntaxFactory.Attribute(
                                    SyntaxFactory.ParseName(nameof(EnumMemberConstantDeclarationAttribute)),
                                    SyntaxFactory.ParseAttributeArgumentList($"(nameof({identifier.Text}))"))))),
                        identifier,
                        SyntaxFactory.EqualsValueClause(expr.FunctionCall.ArgumentListNode.FirstArgument.Transpile()));

                    TranspileToEnumHandler.AddEnumMember(enumMember, convertFunctionName);
                    isAddedToEnum = true;
                }
            }

            return isConstantExpression
                ? globalConstantDeclaration.WithModifiers(
                    new SyntaxTokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                        SyntaxFactory.Token(SyntaxKind.ConstKeyword)))
                : globalConstantDeclaration.WithModifiers(
                    new SyntaxTokenList(
                        SyntaxFactory.Token(isAddedToEnum
                            ? TranspileToEnumHandler.EnumMemberDeclarationAccessModifier
                            : SyntaxKind.PublicKeyword),
                        SyntaxFactory.Token(SyntaxKind.StaticKeyword),
                        SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword)));
        }
    }
}