// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Style", 
    "IDE0016:Use 'throw' expression", 
    Justification = "AppVeyor doesn't like this suggestion", 
    Scope = "member", 
    Target = "~M:FunWithCastles.Settings.Adapters.ReadOnlyAdapter`1.#ctor(FunWithCastles.Settings.ISettingsAdapter{`0})")]