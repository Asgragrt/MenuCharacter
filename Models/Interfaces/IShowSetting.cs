using UnityEngine;

namespace MenuCharacter.Models.Interfaces;

internal interface IShowSetting
{
    string Property { get; }
    
    Vector3 Scale { get; }
}