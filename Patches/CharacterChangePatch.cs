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
        if (!SettingsManager.IsAnyGirlEnabled || (Track)SettingsManager.Track.Index != Track.Selected) return;
        ModManager.UpdateGirls();
    }
}