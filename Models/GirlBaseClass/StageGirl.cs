using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class StageGirl : BaseGirlClass
{
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
}