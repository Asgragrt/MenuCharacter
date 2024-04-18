using UnityEngine;

namespace MenuCharacter.Models.Interfaces;

internal interface IShowSetting
{
    string Property { get; }

    Vector3 Scale { get; }

    Vector3 Position(int character);
}