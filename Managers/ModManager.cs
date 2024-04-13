using Il2CppAssets.Scripts.UI.Panels;
using MenuCharacter.Models;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; } = new();

    internal static PreparationGirl PreparationGirl { get; } = new();

    internal static PnlStage PnlStage { get; set; }

    internal static void CreateGirls()
    {
        StageGirl.CreateGirl();
        PreparationGirl.CreateGirl();
    }
}