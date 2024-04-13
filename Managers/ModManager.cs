using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppPeroTools2.Resources;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static GameObject MenuGirl { get; set; }

    internal static void CreateGirl(PnlStage stage)
    {
        Object.Destroy(MenuGirl);

        var assetName = Singleton<ConfigManager>.instance
            .GetConfigObject<DBConfigCharacter>()
            .GetCharacterInfoByIndex(DataHelper.selectedRoleIndex)
            .victoryShow;

        MenuGirl = ResourcesManager.instance.LoadFromName<GameObject>(assetName).FastInstantiate(stage.transform);
        MenuGirl.transform.position = new Vector3(-6.7f, -5f, 1f);
        MenuGirl.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    }
}