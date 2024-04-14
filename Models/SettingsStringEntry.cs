using MelonLoader;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class SettingsStringEntry
{
    private readonly IDefine _define;

    private readonly MelonPreferences_Entry<string> _entry;

    private readonly string _name;

    internal SettingsStringEntry(MelonPreferences_Category category, string name, IDefine define)
    {
        _name = name;
        _define = define;
        _entry = category.CreateEntry(name, define.Default);
        _entries.Add(this);
    }

    private static List<SettingsStringEntry> _entries { get; } = [];

    internal int Index { get; private set; }

    private string Value
    {
        get => _entry.Value;
        set => _entry.Value = value;
    }

    internal static void VerifyAll()
    {
        foreach (var entry in _entries) entry.Verify();
    }

    internal void Verify()
    {
        var currentVal = Value.Trim();

        Index = _define.StringToIndex(currentVal);
        Logger.Debug($"\"{_name}\" string to index: {Index} ");

        Value = _define.IndexToString(Index);
        Logger.Debug($"\"{_name}\" index to string: {Value} ");

        if (Value.InvEquals(currentVal)) return;

        Logger.Warning(
            $"\"{currentVal}\" is not a valid value for \"{_name}\", using default value: \"{_define.Default}\"");
    }
}