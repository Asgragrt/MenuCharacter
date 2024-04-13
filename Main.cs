using MelonLoader;
using MenuCharacter.Properties;

namespace MenuCharacter;

public class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"{MelonBuildInfo.ModName} has loaded correctly!");
    }
}