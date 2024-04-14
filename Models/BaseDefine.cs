namespace MenuCharacter.Models;

internal abstract class BaseDefine<T> : IDefine where T : struct, Enum, IConvertible
{
    string IDefine.Default => default(T).ToString();

    string IDefine.IndexToString(int i) => Enum.GetName(typeof(T), i) ?? ((IDefine)this).Default;

    int IDefine.StringToIndex(string s) =>
        Enum.TryParse(s, true, out T result) ? result.ToInt32(null) : default(T).ToInt32(null);
}