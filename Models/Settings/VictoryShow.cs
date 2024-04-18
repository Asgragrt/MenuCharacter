using MenuCharacter.Models.Interfaces;
using UnityEngine;

namespace MenuCharacter.Models.Settings;

internal class VictoryShow : IShowSetting
{
    string IShowSetting.Property => "victoryShow";

    Vector3 IShowSetting.Scale { get; } = new(0.5f, 0.5f, 100f);
}