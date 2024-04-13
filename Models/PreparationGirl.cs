namespace MenuCharacter.Models;

internal class PreparationGirl : GirlBaseClass
{
    internal PreparationGirl() : base("PreparationGirlObject") { }

    protected override void SetGirlParent()
    {
        if (!Girl) return;
        Girl.transform.SetParent(ParentTransform);
        ParentTransform.Find("Start")?.SetAsLastSibling();
    }
}