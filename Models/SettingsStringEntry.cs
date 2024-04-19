using MelonLoader;
using MelonLoader.Preferences;
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

        var validator = new StringValidator(this, define);

        _entry = showDesc
            ? category.CreateEntry(name, define.Default, description: Description, validator: validator)
            : category.CreateEntry(name, define.Default, validator: validator);
    }

    internal MelonEvent<string, string> OnEntryValueChanged => _entry.OnEntryValueChanged;

    internal int Index => _define.StringToIndex(Value);

    private string Description => $"\n{_name} options:\n{_define.Options()}";

    private string Value => _entry.Value;

    public override string ToString() => _name;

    private sealed class StringValidator(SettingsStringEntry stringEntry, IDefine define) : ValueValidator
    {
        public override object EnsureValid(object value)
        {
            var currentVal = ((string)value).Trim();

            Logger.Debug($"\'{stringEntry}\' received: \"{currentVal}\"");
            Logger.Debug($"\'{stringEntry}\': \"{currentVal}\" as index {define.StringToIndex(currentVal)}");

            value = define.SanitizeString(currentVal);

            Logger.Debug(
                $"\'{stringEntry}\': Sanitized value: \"{(string)value}\" as index {define.StringToIndex((string)value)}");

            if (!currentVal.InvEquals((string)value))
            {
                Logger.Warning(
                    $"\"{currentVal}\" is not a valid value for \'{stringEntry}\', using default value: \"{define.Default}\"");
            }

            return value;
        }

        public override bool IsValid(object value) => true;
    }
}