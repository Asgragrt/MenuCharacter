using System.Collections;
using Il2CppAssets.Scripts.UI.Panels;
using MelonLoader;
using MenuCharacter.Models;
using MenuCharacter.Models.Defines;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; } = new();

    internal static PreparationGirl PreparationGirl { get; } = new();

    internal static PnlStage PnlStage { get; set; }

    internal static ShowDefine ShowDefine { get; } = new();

    internal static GirlSourceDefine GirlSourceDefine { get; } = new();

    internal static void CreateGirls()
    {
        Logger.Debug("Updating girls...");

        StageGirl.CreateGirl();
        PreparationGirl.CreateGirl();

        Logger.Debug("Updated girls!");
    }

    internal static void CreateGirlsMelon()
    {
        // Leaving the girls update to a melon thread to avoid access violations
        MelonCoroutines.Start(CreateGirlsRoutine());
    }

    private static IEnumerator CreateGirlsRoutine()
    {
        yield return null;
        CreateGirls();
    }
}