using System.Collections;
using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppAssets.Scripts.UI.Panels;
using Il2CppPeroTools2.Resources;
using MelonLoader;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MenuCharacter.Managers;

internal static class ModManager
{
    internal static GameObject MenuGirl { get; set; }

    internal static PnlStage PnlStage { get; set; }
    
    internal static PnlPreparation PnlPreparation { get; set; }

    internal static void CreateGirl()
    {
        Object.Destroy(MenuGirl);

        if (!PnlStage) return;

        var assetName = Singleton<ConfigManager>.instance
            .GetConfigObject<DBConfigCharacter>()
            .GetCharacterInfoByIndex(DataHelper.selectedRoleIndex)
            .victoryShow;

        MenuGirl = ResourcesManager.instance
            .LoadFromName<GameObject>(assetName)
            .FastInstantiate(PnlStage.transform);

        SetGirlStageParent();

        MenuGirl.name = "MenuGirlObject";
        MenuGirl.transform.position = new Vector3(6.7f, -5f, 1f);
        MenuGirl.transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
    }

    internal static void UpdateGirlParent(bool isActive)
    {
        MelonLoader.Melon<Main>.Logger.Msg("Updating...");
        if (!PnlPreparation || !MenuGirl) return;

        if (isActive)
        {
            MenuGirl.transform.SetParent(PnlPreparation.transform);
            PnlPreparation.transform.Find("Start").SetAsLastSibling();
            return;
        }

        MelonCoroutines.Start(SetGirlStageParentCoroutine());
    }

    private static void SetGirlStageParent()
    {
        //MenuGirl.transform.SetParent(PnlStage.transform.Find("StageUi").Find("Info"));
        MenuGirl.transform.SetParent(PnlStage.transform);
    }

    private static IEnumerator SetGirlStageParentCoroutine()
    {
        yield return null;
        SetGirlStageParent();
    }
}