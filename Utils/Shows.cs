using UnityEngine;

namespace MenuCharacter.Utils;

internal static class Shows
{
    internal const int Main = 0;

    internal const int Victory = 1;

    internal const int Fail = 2;

    private static readonly Vector3 MainScale = new(-50f, 50f, 100f);

    private static readonly Vector3 VictoryScale = new(-0.5f, 0.5f, 100f);

    private static readonly Vector3 FailScale = new(-0.75f, 0.75f, 100f);

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

    internal static Vector3 IndexToScale(int index)
    {
        return index switch
        {
            Main => MainScale,
            Victory => VictoryScale,
            Fail => FailScale,
            _ => VictoryScale
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
}