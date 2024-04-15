namespace MenuCharacter.Models;

internal interface IDefine
{
    string Default { get; }

    string IndexToString(int i);

    string Options();

    int StringToIndex(string s);
}