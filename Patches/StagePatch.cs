using HarmonyLib;
using Il2CppAssets.Scripts.UI.Panels;
using MenuCharacter.Managers;

namespace MenuCharacter.Patches;

[HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
internal static class StagePatch
{
    [HarmonyPostfix]
    internal static void Postfix(PnlStage __instance)
    {
        ModManager.StageGirl.SetParent(__instance.transform);
        ModManager.StageGirl.CreateGirl();
    }
}