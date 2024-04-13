using HarmonyLib;
using Il2Cpp;
using MenuCharacter.Managers;

namespace MenuCharacter.Patches;

[HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
internal static class PreparationPatch
{
    internal static void Postfix(PnlPreparation __instance)
    {
        ModManager.PreparationGirl.SetParent(__instance.transform);
        ModManager.PreparationGirl.CreateGirl();
    }
}