using MelonLoader;
using MenuCharacter.Managers;

namespace MenuCharacter.Models;

internal class ShowSetting : SettingsStringEntry
{
    internal ShowSetting(MelonPreferences_Category category) : base(category, "ShowType", ModManager.ShowDefine) { }
}