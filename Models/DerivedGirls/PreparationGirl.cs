using MenuCharacter.Enums;
using MenuCharacter.Models.BaseClasses;
using UnityEngine;

namespace MenuCharacter.Models.DerivedGirls;

internal class PreparationGirl : BaseGirlClass
{
    internal PreparationGirl(GirlSetting girlSetting) : base("PreparationGirlObject", girlSetting) { }

    protected override void SetParent()
    {
        if (!Girl) return;
        Girl.transform.SetParent(ParentTransform);
        ParentTransform.Find("Start")?.SetAsLastSibling();
    }

    protected override void SetPosition()
    {
        base.SetPosition();
        if (!Girl || !Girl.active) return;
        if (GirlSetting.ShowIndex == (int)Show.Main) return;
        Girl.transform.position += new Vector3(0, 0.2f, 0);
    }
}