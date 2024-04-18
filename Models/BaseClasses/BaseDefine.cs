using MenuCharacter.Models.Interfaces;

namespace MenuCharacter.Models.BaseClasses;

internal class BaseDefine<T>(T defVal) : IDefine where T : struct, Enum, IConvertible
{
    string IDefine.Default => defVal.ToString();

    string IDefine.IndexToString(int i) => Enum.GetName(typeof(T), i) ?? ((IDefine)this).Default;

    int IDefine.StringToIndex(string s) =>
        Enum.TryParse(s, true, out T result) ? result.ToInt32(null) : defVal.ToInt32(null);

    string IDefine.Options() => string.Join("\n", Enum.GetNames<T>());
}