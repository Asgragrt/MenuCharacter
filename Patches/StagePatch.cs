using System.Runtime.CompilerServices;
using HarmonyLib;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.UI;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppPeroTools2.Resources;
using Il2CppSirenix.OdinInspector.Demos;
using MelonLoader;
using UnityEngine;
using ConfigManager = Il2CppAssets.Scripts.PeroTools.Managers.ConfigManager;
using Type = Il2CppSystem.Type;

namespace MenuCharacter.Patches;

[HarmonyPatch(typeof(PnlStage), nameof(PnlStage.Awake))]
internal static class StagePatch
{
    [HarmonyPostfix]
    internal static void Postfix(PnlStage __instance)
    {
        var a = Singleton<ConfigManager>.instance
            .GetConfigObject<DBConfigCharacter>()
            .GetCharacterInfoByIndex(DataHelper.selectedRoleIndex)
            .victoryShow;
        Melon<Main>.Logger.Msg(a);

        //__instance.gameObject.AddComponent<MuseShow>();

        var b = ResourcesManager.instance.LoadFromName<GameObject>(a).FastInstantiate(__instance.transform);
        b.transform.position = new Vector3(-6.7f, -5f, 1f);
        b.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        //b.AddComponent<MuseShow>().Init();
    }
}