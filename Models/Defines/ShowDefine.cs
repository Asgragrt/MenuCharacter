using MenuCharacter.Enums;
using MenuCharacter.Managers;
using UnityEngine;

namespace MenuCharacter.Models.Defines;

internal class ShowDefine() : BaseDefine<Show>(Show.Victory)
{
    internal static string Property => IndexToProperty(SettingsManager.Show.Index);

    internal static Vector3 Scale => IndexToScale(SettingsManager.Show.Index);

    private static string IndexToProperty(int index)
    {
        return (Show)index switch
        {
            Show.Main => "mainShow",
            Show.Victory => "victoryShow",
            Show.Fail => "failShow",
            _ => "victoryShow"
        };
    }

    private static Vector3 IndexToScale(int index)
    {
        var flip = SettingsManager.Flip ? -1 : 1;

        return (Show)index switch
        {
            Show.Main => new Vector3(50f * flip, 50f, 100f),
            Show.Victory => new Vector3(0.5f * flip, 0.5f, 100f),
            Show.Fail => new Vector3(0.75f * flip, 0.75f, 100f),
            _ => new Vector3(50f * flip, 50f, 100f)
        };
    }
}