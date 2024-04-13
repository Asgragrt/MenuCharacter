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

    internal static int ShowIndex;

    internal static string Show
    {
        get => ShowEntry.Value;
        private set => ShowEntry.Value = value;
    }

    private static void Init()
    {
        Category.SetFilePath(SettingsPath, false, false);

        var absolutePath = Path.Join(UserDataDirectory, SettingsFileName);
        if (!File.Exists(absolutePath)) MelonPreferences.Save();
    }

    internal static void Load()
    {
        Category.LoadFromFile(false);

        // Clean input
        var currentShow = Show;
        ShowIndex = Shows.ShowToIndex(Show);
        Show = Shows.IndexToShow(ShowIndex);

        if (string.Equals(Show, currentShow)) return;
        Melon<Main>.Logger.Warning($"{currentShow} is not a valid value for Show, using default value: Victory");
    }

    internal static void InitAndLoad()
    {
        Init();
        Load();
    }
}