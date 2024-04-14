namespace MenuCharacter.Utils;

internal static class GirlSources
{
    internal const int Selected = 0;

    internal const int Fixed = 1;

    internal static string Default => IndexToString(Selected);

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
            not null when s.InvEquals("Selected") => Selected,
            not null when s.InvEquals("Fixed") => Fixed,
            _ => Selected
        };
    }
}