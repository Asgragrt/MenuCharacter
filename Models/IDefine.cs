namespace MenuCharacter.Models;

internal interface IDefine
{
    string Default { get; }

    string IndexToString(int i);

    int StringToIndex(string s);
}