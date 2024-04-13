using System.Collections;
using Il2CppAssets.Scripts.UI.Panels;
using MelonLoader;
using MenuCharacter.Models;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; } = new();

    internal static PreparationGirl PreparationGirl { get; } = new();

    internal static PnlStage PnlStage { get; set; }

    internal static void CreateGirls()
    {
        Logger.Debug("Before updating girls.");

        try
        {
            StageGirl.CreateGirl();
            PreparationGirl.CreateGirl();
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }

        Logger.Debug("After updating girls.");
    }

    private static IEnumerator CreateGirlsRoutine()
    {
        CreateGirls();
        yield return null;
    }

    internal static void CreateGirlsMelon()
    {
        // Leaving the girls update to a melon thread to avoid access violations
        MelonCoroutines.Start(CreateGirlsRoutine());
    }
}