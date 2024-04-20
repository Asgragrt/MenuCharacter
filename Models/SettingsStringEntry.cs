using MelonLoader;
using MelonLoader.Preferences;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class SettingsStringEntry<T> where T : struct, Enum, IConvertible
{
    private readonly BaseDefine<T> _define;

    private readonly MelonPreferences_Entry<string> _entry;

    private readonly string _name;

    internal SettingsStringEntry(MelonPreferences_Category category, string name, T defaultVal, bool showDesc = true)
    {
        _name = name;
        _define = new BaseDefine<T>(defaultVal);

        var validator = new StringValidator(ToString(), _define);

        _entry = showDesc
            ? category.CreateEntry(name, _define.Default, description: Description, validator: validator)
            : category.CreateEntry(name, _define.Default, validator: validator);
    }

    internal MelonEvent<string, string> OnEntryValueChanged => _entry.OnEntryValueChanged;

    internal int Index => _define.StringToIndex(Value);

    private string Description => $"\n{_name} options:\n{_define.Options()}";

    private string Value => _entry.Value;

    public override sealed string ToString() => _name;

    private interface IDefine
    {
        string Default { get; }

        string IndexToString(int i);

        string Options();

        int SanitizeIndex(int i);

        string SanitizeString(string s);

        int StringToIndex(string s);
    }

    private sealed class BaseDefine<TEnum>(TEnum defVal) : IDefine where TEnum : struct, Enum, IConvertible
    {
        public string Default => defVal.ToString();

        public string IndexToString(int i) => Enum.GetName(typeof(TEnum), i) ?? Default;

        public int StringToIndex(string s) =>
            Enum.TryParse(s, true, out TEnum result) ? result.ToInt32(null) : defVal.ToInt32(null);

        public string Options() => string.Join("\n", Enum.GetNames<TEnum>());

        public int SanitizeIndex(int i) => StringToIndex(IndexToString(i));

        public string SanitizeString(string s) => IndexToString(StringToIndex(s));
    }

    private sealed class StringValidator(string stringEntry, IDefine define) : ValueValidator
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