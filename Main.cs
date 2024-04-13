using MelonLoader;
using MenuCharacter.Managers;
using MenuCharacter.Properties;

namespace MenuCharacter;

public sealed class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.InitAndLoad();
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }

    public override void OnLateInitializeMelon()
    {
        WatcherManager.Init();
        WatcherManager.WatcherEvent += (_, _) =>
        {
            SettingsManager.Load();
            LoggerInstance.Msg($"{MelonBuildInfo.ModName} reloaded correctly!");
        };
    }
}