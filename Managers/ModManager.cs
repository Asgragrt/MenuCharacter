﻿using System.Collections;
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

    internal static CharacterDefine CharacterDefine { get; } = new();

    internal static void CreateGirlsMelon()
    {
        // Leaving the girls update to a melon thread with small delay to avoid access violations
        MelonCoroutines.Start(CreateGirlsRoutine());
    }

    internal static void UpdateGirls()
    {
        Logger.Debug("Updating girls...");

        if (SettingsManager.IsStageGirlEnabled)
        {
            StageGirl.CreateGirl();
            Logger.Debug("Updated stage girl.");
        }
        else
        {
            StageGirl.DestroyGirl();
            Logger.Debug("Destroyed stage girl.");
        }

        if (SettingsManager.IsPrepGirlEnabled)
        {
            PreparationGirl.CreateGirl();
            Logger.Debug("Updated preparation girl.");
        }
        else
        {
            PreparationGirl.DestroyGirl();
            Logger.Debug("Destroyed preparation girl.");
        }

        Logger.Debug("Updated girls!");
    }

    private static IEnumerator CreateGirlsRoutine()
    {
        yield return null;
        UpdateGirls();
    }
}