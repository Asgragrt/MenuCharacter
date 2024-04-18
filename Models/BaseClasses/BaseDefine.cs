using MenuCharacter.Models.Interfaces;

namespace MenuCharacter.Models.BaseClasses;

internal class BaseDefine<T>(T defVal) : IDefine where T : struct, Enum, IConvertible
{
    public string Default => defVal.ToString();

    public string IndexToString(int i) => Enum.GetName(typeof(T), i) ?? Default;

    public int StringToIndex(string s) =>
        Enum.TryParse(s, true, out T result) ? result.ToInt32(null) : defVal.ToInt32(null);

    public string Options() => string.Join("\n", Enum.GetNames<T>());

    public int SanitizeIndex(int i) => StringToIndex(IndexToString(i));

    public string SanitizeString(string s) => IndexToString(StringToIndex(s));
}