using MenuCharacter.Models.Interfaces;
using UnityEngine;

namespace MenuCharacter.Models.Settings;

internal class FailShow : IShowSetting
{
    string IShowSetting.Property => "failShow";

    Vector3 IShowSetting.Scale { get; } = new(0.75f, 0.75f, 100f);
}