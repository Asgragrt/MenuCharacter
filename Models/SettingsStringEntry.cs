using MelonLoader;
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

        Entries.Add(this);
    }

    internal MelonEvent<string, string> OnEntryValueChanged => _entry.OnEntryValueChanged;

    internal int Index { get; private set; }

    private string Description => $"\n{_name} options:\n{_define.Options()}";

    private static List<SettingsStringEntry> Entries { get; } = [];

    private string Value
    {
        get => _entry.Value;
        set => _entry.Value = value;
    }

    internal static void VerifyAll()
    {
        foreach (var entry in Entries) entry.Verify();
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