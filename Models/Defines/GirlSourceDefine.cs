using Il2CppAssets.Scripts.Database;
using MenuCharacter.Enums;
using MenuCharacter.Managers;

namespace MenuCharacter.Models.Defines;

internal class GirlSourceDefine() : BaseDefine<Source>(Source.Fixed)
{
    internal static int GetGirlIndex(int fixedIndex)
    {
        return (Source)SettingsManager.GirlSource.Index switch
        {
            Source.Selected => DataHelper.selectedRoleIndex,
            //Source.Fixed => SettingsManager.StageGirlEntry.Index,
            Source.Fixed => fixedIndex,
            _ => DataHelper.selectedRoleIndex
        };
    }
}