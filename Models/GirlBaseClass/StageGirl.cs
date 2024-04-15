using System.Collections;
using MelonLoader;
using MenuCharacter.Managers;
using MenuCharacter.Models.Defines;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class StageGirl : BaseGirlClass
{
    private object _routine;

    internal StageGirl() : base("MenuGirlObject") { }

    protected override int GetGirlIndex() => GirlSourceDefine.GetGirlIndex(SettingsManager.StageGirlEntry.Index);

    protected override void SetGirlParent()
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

    protected override void SetGirlPosition()
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

        if (!Girl) yield break;
        Logger.Debug("Waiting for parent position to settle.");
        var pos = Girl.transform.parent.position.y;

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
        base.SetGirlPosition();
        Logger.Debug("Finish position coroutine.");
    }
}