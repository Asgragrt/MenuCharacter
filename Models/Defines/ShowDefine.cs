using MenuCharacter.Enums;
using UnityEngine;

namespace MenuCharacter.Models.Defines;

internal class ShowDefine : BaseDefine<Show>
{
    private static readonly Vector3 MainScale = new(-50f, 50f, 100f);

    private static readonly Vector3 VictoryScale = new(-0.5f, 0.5f, 100f);

    private static readonly Vector3 FailScale = new(-0.75f, 0.75f, 100f);

    internal static string IndexToProperty(int index)
    {
        return (Show)index switch
        {
            Show.Main => "mainShow",
            Show.Victory => "victoryShow",
            Show.Fail => "failShow",
            _ => "victoryShow"
        };
    }

    internal static Vector3 IndexToScale(int index)
    {
        return (Show)index switch
        {
            Show.Main => MainScale,
            Show.Victory => VictoryScale,
            Show.Fail => FailScale,
            _ => VictoryScale
        };
    }
}