using Il2CppAssets.Scripts.Database;
using MenuCharacter.Enums;
using MenuCharacter.Managers;

namespace MenuCharacter.Models.Defines;

internal class GirlSourceDefine() : BaseDefine<Source>(Source.Fixed)
{
    internal static int GetGirlIndex()
    {
        return (Source)SettingsManager.GirlSource.Index switch
        {
            Source.Selected => DataHelper.selectedRoleIndex,
            Source.Fixed => SettingsManager.Character.Index,
            _ => DataHelper.selectedRoleIndex
        };
    }
}