using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.UI.Specials;
using MenuCharacter.Managers;

namespace MenuCharacter.Patches;

[HarmonyPatch]
internal static class PreparationPatch
{
    [HarmonyPatch(typeof(PnlPreparation), nameof(PnlPreparation.Awake))]
    [HarmonyPostfix]
    internal static void AwakePostfix(PnlPreparation __instance)
    {
        ModManager.PnlPreparation = __instance;
    }
    
    [HarmonyPatch(typeof(AutoPushPopPanel), nameof(AutoPushPopPanel.OnPnlPreparationActiveChanged))]
    [HarmonyPrefix]
    internal static void OnEnablePostfix(bool active)
    {
        ModManager.UpdateGirlParent(active);
    }
}