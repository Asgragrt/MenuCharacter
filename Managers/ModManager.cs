using MenuCharacter.Models;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; set; } = new();

    internal static PreparationGirl PreparationGirl { get; set; } = new();
}