﻿using MelonLoader;
using MenuCharacter.Models.Interfaces;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class SettingsStringEntry
{
    private readonly IDefine _define;

    private readonly MelonPreferences_Entry<string> _entry;

    private readonly string _name;

    internal SettingsStringEntry(MelonPreferences_Category category, string name, IDefine define, bool showDesc = true)
    {
        _name = name;
        _define = define;

        _entry = showDesc
            ? category.CreateEntry(name, define.Default, description: Description)
            : category.CreateEntry(name, define.Default);
    }

    internal MelonEvent<string, string> OnEntryValueChanged => _entry.OnEntryValueChanged;

    internal int Index => _define.StringToIndex(Value);

    private string Description => $"\n{_name} options:\n{_define.Options()}";

    private string Value
    {
        get => _entry.Value;
        set => _entry.Value = value;
    }

    internal bool SanitizedStringEqual(string s1, string s2) => SanitizeString(s1).InvEquals(SanitizeString(s2));

    internal string SanitizeString(string input) => _define.IndexToString(_define.StringToIndex(input.Trim()));

    internal void SanitizeValue()
    {
        var currentVal = Value.Trim();

        Value = SanitizeString(currentVal);
        Logger.Debug($"\"{_name}\" index to string: {Value} ");

        if (Value.InvEquals(currentVal)) return;

        Logger.Warning(
            $"\"{currentVal}\" is not a valid value for \"{_name}\", using default value: \"{_define.Default}\"");
    }
}