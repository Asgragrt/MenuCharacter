using System.Collections;
using MelonLoader;
using MenuCharacter.Managers;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class PreparationGirl : GirlBaseClass
{
    private object _routine;

    internal PreparationGirl() : base("PreparationGirlObject") { }

    protected override void SetGirlParent()
    {
        if (!Girl) return;
        Girl.transform.SetParent(ParentTransform);
        ParentTransform.Find("Start")?.SetAsLastSibling();
    }


    internal void WaitToEnable()
    {
        try
        {
            MelonCoroutines.Stop(_routine);
        }
        catch
        {
            // ignored if _routine is not a valid coroutine
        }

        _routine = MelonCoroutines.Start(WaitToEnableCoroutine());
    }

    private IEnumerator WaitToEnableCoroutine()
    {
        if (!Girl) yield break;

        Girl.SetActive(false);

        if (!ModManager.PnlStage)
        {
            Logger.Debug("There's no PnlStage");
            yield break;
        }

        var stageUi = ModManager.PnlStage.transform.Find("StageUi")?.gameObject;

        if (!stageUi)
        {
            Logger.Debug("Couldn't find StageUi game object.");
            yield break;
        }

        while (stageUi != null && stageUi.active)
        {
            if (!Girl) yield break;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        if (!Girl) yield break;
        Girl.SetActive(true);
    }
}