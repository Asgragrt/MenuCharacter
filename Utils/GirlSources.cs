namespace MenuCharacter.Utils;

internal static class GirlSources
{
    internal static string Default => IndexToString((int)Sources.Selected);

    internal static string IndexToString(int index) => ((Sources)index).ToString();

    internal static int StringToIndex(string s)
    {
        if (Enum.TryParse(s, true, out Sources result)) return (int)result;

        return (int)Sources.Selected;
    }

    private enum Sources
    {
        Selected = 0,

        Fixed
    }
}