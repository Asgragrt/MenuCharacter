using HarmonyLib;
using Il2CppAssets.Scripts.Database;
using MenuCharacter.Enums;
using MenuCharacter.Managers;

namespace MenuCharacter.Patches;

[HarmonyPatch(typeof(DataHelper), nameof(DataHelper.selectedRoleIndex), MethodType.Setter)]
internal static class CharacterChangePatch
{
    internal static void Postfix()
    {
        if (!SettingsManager.IsAnyGirlEnabled || SettingsManager.GirlSource.Index != (int)Source.Selected) return;
        ModManager.UpdateGirls();
    }
}