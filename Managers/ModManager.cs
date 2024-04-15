﻿using System.Collections;
using Il2CppAssets.Scripts.UI.Panels;
using MelonLoader;
using MenuCharacter.Models;
using MenuCharacter.Models.Defines;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static StageGirl StageGirl { get; private set; }

    internal static PreparationGirl PreparationGirl { get; private set; }

    internal static PnlStage PnlStage { get; set; }

    internal static ShowDefine ShowDefine { get; } = new();

    internal static TrackDefine TrackDefine { get; } = new();

    internal static CharacterDefine CharacterDefine { get; } = new();

    internal static void CreateGirlsMelon()
    {
        // Leaving the girls update to a melon thread with small delay to avoid access violations
        MelonCoroutines.Start(CreateGirlsRoutine());
    }

    internal static void Init()
    {
        StageGirl = new StageGirl(SettingsManager.StageGirlSettings);
        PreparationGirl = new PreparationGirl(SettingsManager.PrepGirlSettings);
    }

    internal static void UpdateGirls()
    {
        Logger.Debug("Updating girls...");

        StageGirl.Update();

        PreparationGirl.Update();

        Logger.Debug("Updated girls!");
    }

    private static IEnumerator CreateGirlsRoutine()
    {
        yield return null;
        UpdateGirls();
    }
}