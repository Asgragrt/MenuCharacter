using UnityEngine;

namespace MenuCharacter.Models;

internal class PreparationGirl : BaseGirlClass
{
    internal PreparationGirl(GirlSetting girlSetting) : base("PreparationGirlObject", girlSetting) { }

    protected override void SetGirlParent()
    {
        if (!Girl) return;
        Girl.transform.SetParent(ParentTransform);
        ParentTransform.Find("Start")?.SetAsLastSibling();
    }

    protected override void SetGirlPosition()
    {
        base.SetGirlPosition();
        Girl.transform.position += new Vector3(0, 0.2f, 0);
    }
}