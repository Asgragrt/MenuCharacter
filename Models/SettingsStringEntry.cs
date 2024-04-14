using MelonLoader;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal abstract class SettingsStringEntry(MelonPreferences_Category category, string name, IDefine define)
{
    private readonly MelonPreferences_Entry<string> _entry = category.CreateEntry(name, define.Default);

    internal int Index { get; private set; }

    private string Value
    {
        get => _entry.Value;
        set => _entry.Value = value;
    }

    internal void Verify()
    {
        var currentVal = Value.Trim();

        Index = define.StringToIndex(currentVal);
        Logger.Debug($"\"{name}\" string to index: {Index} ");

        Value = define.IndexToString(Index);
        Logger.Debug($"\"{name}\" index to string: {Value} ");

        if (Value.InvEquals(currentVal)) return;

        Logger.Warning(
            $"\"{currentVal}\" is not a valid value for \"{name}\", using default value: \"{define.Default}\"");
    }
}