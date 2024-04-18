using System.Collections;
using MelonLoader;
using MenuCharacter.Models.BaseClasses;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models.DerivedGirls;

internal class StageGirl : BaseGirlClass
{
    private object _routine;

    internal StageGirl(GirlSetting girlSetting) : base("MenuGirlObject", girlSetting) { }

    protected override void SetParent()
    {
        if (!Girl) return;
        var targetParent = ParentTransform.Find("StageUi")?.Find("Info").Find("Bottom");

        if (!targetParent)
        {
            Logger.Debug("Couldn't find Bottom transform.");
            return;
        }

        Girl.transform.SetParent(targetParent);
        Girl.transform.SetAsFirstSibling();
    }

    protected override void SetPosition()
    {
        try
        {
            MelonCoroutines.Stop(_routine);
        }
        catch
        {
            // Ignore coroutine error
        }

        _routine = MelonCoroutines.Start(SetPositionRoutine());
    }

    private IEnumerator SetPositionRoutine()
    {
        Logger.Debug("Start position coroutine.");
        Logger.Debug("Waiting for girl active.");
        while (Girl && !Girl.active) yield return null;

        Logger.Debug("Waiting for parent position to settle.");
        var pos = -10f;

        while (Girl && !Mathf.Approximately(pos, -5.4f))
        {
            yield return null;

            if (!Girl.transform.parent)
            {
                Logger.Debug("Parent not found on coroutine.");
                yield break;
            }

            pos = Girl.transform.parent.position.y;
        }

        if (!Girl)
        {
            Logger.Debug("Girl object destroyed while on coroutine.");
            yield break;
        }

        Logger.Debug("Setting girl position coroutine.");
        base.SetPosition();
        Logger.Debug("Finish position coroutine.");
    }
}