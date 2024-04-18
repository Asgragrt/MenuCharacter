using MenuCharacter.Models.Interfaces;
using UnityEngine;

namespace MenuCharacter.Models.Settings;

internal class MainShow : IShowSetting
{
    string IShowSetting.Property => "mainShow";

    Vector3 IShowSetting.Scale { get; } = new(50f, 50f, 100f);
}