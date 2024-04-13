using HarmonyLib;
using Il2Cpp;
using MenuCharacter.Managers;

namespace MenuCharacter.Patches;

[HarmonyPatch(typeof(PnlPreparation))]
internal static class PreparationPatch
{
    [HarmonyPatch(nameof(PnlPreparation.Awake))]
    [HarmonyPostfix]
    internal static void AwakePostfix(PnlPreparation __instance)
    {
        ModManager.PreparationGirl.SetParent(__instance.transform);
        ModManager.PreparationGirl.CreateGirl();
    }
    
    [HarmonyPatch(nameof(PnlPreparation.OnEnable))]
    [HarmonyPostfix]
    internal static void OnEnablePostfix()
    {
        ModManager.PreparationGirl.WaitToEnable();
    }
}