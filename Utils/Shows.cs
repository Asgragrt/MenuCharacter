using UnityEngine;

namespace MenuCharacter.Utils;

internal static class Shows
{
    private static readonly Vector3 MainScale = new(-50f, 50f, 100f);

    private static readonly Vector3 VictoryScale = new(-0.5f, 0.5f, 100f);

    private static readonly Vector3 FailScale = new(-0.75f, 0.75f, 100f);

    internal static string Default => IndexToString((int)EShow.Victory);

    internal static string IndexToProperty(int index)
    {
        return (EShow)index switch
        {
            EShow.Main => "mainShow",
            EShow.Victory => "victoryShow",
            EShow.Fail => "failShow",
            _ => "victoryShow"
        };
    }

    internal static Vector3 IndexToScale(int index)
    {
        return (EShow)index switch
        {
            EShow.Main => MainScale,
            EShow.Victory => VictoryScale,
            EShow.Fail => FailScale,
            _ => VictoryScale
        };
    }

    internal static string IndexToString(int i) => Enum.GetName(typeof(EShow), i) ?? default(EShow).ToString();

    internal static int StringToIndex(string s)
    {
        if (Enum.TryParse(s, true, out EShow result)) return (int)result;

        return (int)default(EShow);
    }
    

    private enum EShow
    {
        Main = 0,

        Victory,

        Fail
    }
}