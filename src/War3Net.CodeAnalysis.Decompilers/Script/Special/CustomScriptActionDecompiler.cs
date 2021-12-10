﻿using War3Net.Build.Script;
using War3Net.CodeAnalysis.Jass.Syntax;

namespace War3Net.CodeAnalysis.Decompilers
{
    public partial class JassScriptDecompiler
    {
        private TriggerFunction DecompileCustomScriptAction(ICustomScriptAction customScriptAction)
        {
            return new TriggerFunction
            {
                Type = TriggerFunctionType.Action,
                IsEnabled = true,
                Name = "CustomScriptCode",
                Parameters = new()
                {
                    new TriggerFunctionParameter
                    {
                        Type = TriggerFunctionParameterType.String,
                        Value = customScriptAction.ToString(),
                    },
                },
            };
        }
    }
}