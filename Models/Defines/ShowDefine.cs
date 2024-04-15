using MenuCharacter.Enums;
using UnityEngine;

namespace MenuCharacter.Models.Defines;

internal class ShowDefine() : BaseDefine<Show>(Show.Victory)
{
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

    internal static Vector3 IndexToScale(int index, bool flip)
    {
        var sign = flip ? -1 : 1;

        return (Show)index switch
        {
            Show.Main => new Vector3(50f * sign, 50f, 100f),
            Show.Victory => new Vector3(0.5f * sign, 0.5f, 100f),
            Show.Fail => new Vector3(0.75f * sign, 0.75f, 100f),
            _ => new Vector3(50f * sign, 50f, 100f)
        };
    }
}