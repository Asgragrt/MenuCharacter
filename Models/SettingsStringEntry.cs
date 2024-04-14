using MelonLoader;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal abstract class SettingsStringEntry(MelonPreferences_Category category, string name, string defaultVal)
{
    private readonly MelonPreferences_Entry<string> _entry = category.CreateEntry(name, defaultVal);

    internal int Index { get; private set; }

    private string Value
    {
        get => _entry.Value;
        set => _entry.Value = value;
    }

    protected abstract string IndexToString(int i);

    protected abstract int StringToIndex(string s);

    internal void Verify()
    {
        var currentVal = Value.Trim();

        Index = StringToIndex(currentVal);
        Value = IndexToString(Index);

        if (Value.InvEquals(currentVal)) return;

        Logger.Warning($"\"{currentVal}\" is not a valid value for \"{name}\", using default value: \"{defaultVal}\"");
    }
}