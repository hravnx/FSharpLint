﻿namespace FSharpLint.Rules

module UnnecessaryNew =
    
    open Microsoft.FSharp.Compiler.Ast
    open Microsoft.FSharp.Compiler.SourceCodeServices
    open FSharpLint.Framework
    open FSharpLint.Framework.Analyser
    open FSharpLint.Framework.Ast
    open FSharpLint.Framework.Configuration

    [<Literal>]
    let AnalyserName = "UnnecessaryNew"

    let private implementsIDisposable (fsharpType:FSharpType) =
        if fsharpType.HasTypeDefinition then
            match fsharpType.TypeDefinition.TryFullName with
            | Some(fullName) -> fullName = typeof<System.IDisposable>.FullName
            | None -> false
        else
            false

    let private isRuleEnabled config ruleName =
        isRuleEnabled config AnalyserName ruleName |> Option.isSome

    let private doesNotImplementIDisposable (checkFile:FSharpCheckFileResults) (ident:LongIdentWithDots) = async {
        let names = ident.Lid |> List.map (fun x -> x.idText)
        let! symbol = checkFile.GetSymbolUseAtLocation(ident.Range.StartLine, ident.Range.EndColumn, "", names)

        return
            match symbol with
            | Some(symbol) -> 
                if symbol.Symbol :? FSharpMemberOrFunctionOrValue then
                    let ctor = symbol.Symbol :?> FSharpMemberOrFunctionOrValue
                    let ctorForType = ctor.EnclosingEntity
                    Seq.forall (implementsIDisposable >> not) ctorForType.AllInterfaces
                else 
                    false
            | None -> false }

    let analyser (args: AnalyserArgs) : unit = 
        let syntaxArray, skipArray = args.SyntaxArray, args.SkipArray

        let isSuppressed i ruleName =
            AbstractSyntaxArray.getSuppressMessageAttributes syntaxArray skipArray i 
            |> AbstractSyntaxArray.isRuleSuppressed AnalyserName ruleName
            
        match args.CheckFile with
        | Some(checker) ->
            for i = 0 to syntaxArray.Length - 1 do
                match syntaxArray.[i].Actual with
                | AstNode.Expression(SynExpr.New(_, synType, _, range)) ->
                    match synType with 
                    | SynType.LongIdent(identifier) -> 
                        let check = doesNotImplementIDisposable checker identifier
                        args.Info.Suggest
                            { Range = range; Message = "suggestion"; SuggestedFix = None; TypeChecks = [check] }
                    | _ -> ()
                | _ -> ()
        | None -> ()