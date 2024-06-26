﻿using MelonLoader;
using MelonLoader.Utils;
using MenuCharacter.Models;
using MenuCharacter.Properties;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

using static MelonEnvironment;

internal static class SettingsManager
{
    internal const string SettingsFileName = $"{MelonBuildInfo.ModName}.cfg";

    internal const string SettingsPath = $"UserData/{SettingsFileName}";

    internal static readonly GirlSetting StageGirlSettings = new("StageGirl");

    internal static readonly GirlSetting PrepGirlSettings = new("PreparationGirl", false);

    private static readonly MelonPreferences_Category Category =
        MelonPreferences.CreateCategory(MelonBuildInfo.ModName);

    private static readonly MelonPreferences_Entry<bool> DebugEntry = Category.CreateEntry("DebugLog", false);

    internal static bool IsAnyGirlEnabled => StageGirlSettings.IsEnabled || PrepGirlSettings.IsEnabled;

    internal static bool Debug => DebugEntry.Value;

    internal static void InitAndLoad()
    {
        Init();
        Load();
    }

    internal static void Load()
    {
        try
        {
            Logger.Debug("Loading settings from file.");

            Category.LoadFromFile(false);

            Logger.Debug("Loaded settings from file.");
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }
    }

    private static void Init()
    {
        Category.SetFilePath(SettingsPath, false, false);

        var absolutePath = Path.Join(UserDataDirectory, SettingsFileName);

        try
        {
            Logger.Debug("Checking for config file existence.");

            if (File.Exists(absolutePath)) return;

            Logger.Debug("Creating config file.");
            MelonPreferences.Save();
            Logger.Debug("Created config file.");
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }
    }
}