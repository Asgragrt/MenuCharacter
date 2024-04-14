namespace MenuCharacter.Utils;

internal static class GirlSources
{
    internal const int Selected = 0;

    internal const int Fixed = 1;

    internal static string IndexToString(int index)
    {
        return index switch
        {
            Selected => "Selected",
            Fixed => "Fixed",
            _ => "Selected"
        };
    }

    internal static int StringToIndex(string s)
    {
        return s switch
        {
            "Selected" => Selected,
            "Fixed" => Fixed,
            _ => Selected
        };
    }

    internal static string Default => IndexToString(Selected);
}