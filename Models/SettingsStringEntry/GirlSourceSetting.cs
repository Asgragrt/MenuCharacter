using MelonLoader;
using MenuCharacter.Managers;

namespace MenuCharacter.Models;

internal class GirlSourceSetting : SettingsStringEntry
{
    internal GirlSourceSetting(MelonPreferences_Category category) :
        base(category, "GirlSource", ModManager.GirlSourceDefine) { }
}