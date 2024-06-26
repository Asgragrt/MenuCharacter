﻿using System.Collections;
using Il2CppAssets.Scripts.UI.Panels;
using MelonLoader;
using MenuCharacter.Models.DerivedGirls;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

using static SettingsManager;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; private set; }

    internal static PreparationGirl PreparationGirl { get; private set; }

    internal static PnlStage PnlStage { get; set; }

    internal static void Init()
    {
        StageGirl = new StageGirl(StageGirlSettings);
        PreparationGirl = new PreparationGirl(PrepGirlSettings);
    }

    internal static void SetIndexChanged()
    {
        StageGirlSettings.SetIndexChanged();
        PrepGirlSettings.SetIndexChanged();
    }

    internal static void UpdateGirls()
    {
        Logger.Debug("Updating girls...");

        StageGirl.Update();

        PreparationGirl.Update();

        Logger.Debug("Updated girls!");
    }

    internal static void UpdateGirlsMelon()
    {
        // Leaving the girls update to a melon thread with small delay to avoid access violations
        MelonCoroutines.Start(UpdateGirlsRoutine());
    }

    private static IEnumerator UpdateGirlsRoutine()
    {
        yield return null;
        UpdateGirls();
    }
}