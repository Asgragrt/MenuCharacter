namespace MenuCharacter.Models;

internal class StageGirl : GirlBaseClass
{
    internal StageGirl() : base("MenuGirlObject") { }

    protected override void SetGirlParent()
    {
        if (!Girl) return;
        var targetParent = ParentTransform.Find("StageUi")?.Find("Info").Find("Bottom");
        if (!targetParent) return; // Maybe add log error here
        Girl.transform.SetParent(targetParent);
        Girl.transform.SetAsFirstSibling();
    }
}