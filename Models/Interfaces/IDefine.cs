namespace MenuCharacter.Models.Interfaces;

internal interface IDefine
{
    string Default { get; }

    string IndexToString(int i);

    string Options();

    int SanitizeIndex(int i);

    string SanitizeString(string s);

    int StringToIndex(string s);
}