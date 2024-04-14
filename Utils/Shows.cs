namespace MenuCharacter.Utils;

internal static class Shows
{
    internal const int Main = 0;

    internal const int Victory = 1;

    internal const int Fail = 2;

    internal static int ShowToIndex(string show)
    {
        return show switch
        {
            "Main" => Main,
            "Victory" => Victory,
            "Fail" => Fail,
            _ => Victory
        };
    }

    internal static string IndexToShow(int index)
    {
        return index switch
        {
            Main => "Main",
            Victory => "Victory",
            Fail => "Fail",
            _ => "Victory"
        };
    }

    internal static string IndexToProperty(int index)
    {
        return index switch
        {
            Main => "mainShow",
            Victory => "victoryShow",
            Fail => "failShow",
            _ => "victoryShow"
        };
    }
}