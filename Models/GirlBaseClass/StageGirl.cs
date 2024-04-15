using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class StageGirl : BaseGirlClass
{
    private bool _first = true;

    internal StageGirl() : base("MenuGirlObject") { }

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
        base.SetGirlPosition();

        // TODO fix this :D
        if (Girl.active || _first)
        {
            _first = false;
            return;
        }

        Girl.transform.position += new Vector3(0, -2.8f, 0);
    }
}