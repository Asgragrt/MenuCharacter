using MelonLoader;
using MenuCharacter.Managers;
using MenuCharacter.Properties;
using MenuCharacter.Utils;

namespace MenuCharacter;

public sealed class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        SettingsManager.InitAndLoad();
        ModManager.Init();
        Logger.Msg($"{MelonBuildInfo.ModName} loaded correctly!");
    }

    public override void OnLateInitializeMelon()
    {
        WatcherManager.Init();

        WatcherManager.WatcherEvent += (_, _) =>
        {
            SettingsManager.Load();
            
            // Leaving the girls update to a melon thread to avoid access violations
            ModManager.UpdateGirlsMelon();

            Logger.Msg($"{MelonBuildInfo.ModName} reloaded correctly!");
        };
    }
}