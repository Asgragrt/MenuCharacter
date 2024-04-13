using MelonLoader;
using MelonLoader.Utils;
using MenuCharacter.Properties;
using MenuCharacter.Utils;

namespace MenuCharacter.Managers;

using static MelonEnvironment;

internal static class SettingsManager
{
    internal const string SettingsFileName = $"{MelonBuildInfo.ModName}.cfg";

    private const string SettingsPath = $"UserData/{SettingsFileName}";

    private static readonly MelonPreferences_Category
        Category = MelonPreferences.CreateCategory(MelonBuildInfo.ModName);

    private static readonly MelonPreferences_Entry<string> ShowEntry = Category.CreateEntry("ShowType", "Victory");

    private static readonly MelonPreferences_Entry<bool> DebugEntry = Category.CreateEntry("DebugLog", false);

    internal static int ShowIndex { get; private set; }

    internal static string Show
    {
        get => ShowEntry.Value;
        private set => ShowEntry.Value = value;
    }

    internal static bool Debug => DebugEntry.Value;

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

    internal static void Load()
    {
        try
        {
            Logger.Debug("Loading settings from file.");
            Category.LoadFromFile(false);
            Logger.Debug("Loaded settings from file.");

            // Clean input
            var currentShow = Show;
            ShowIndex = Shows.ShowToIndex(Show);
            Show = Shows.IndexToShow(ShowIndex);

            if (string.Equals(Show, currentShow)) return;
            Logger.Warning($"{currentShow} is not a valid value for Show, using default value: Victory");
        }
        catch (Exception e)
        {
            Logger.Error(e);
        }
    }

    internal static void InitAndLoad()
    {
        Init();
        Load();
    }
}