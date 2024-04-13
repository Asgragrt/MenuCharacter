using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Resources;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MenuCharacter.Models;

internal abstract class GirlBaseClass(string name)
{
    private static readonly Vector3 ScaleVector = new(-0.5f, 0.5f, 1f);

    protected Transform ParentTransform;

    protected GameObject Girl { get; private set; }

    private static string GetAssetName() => Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>()
        .GetCharacterInfoByIndex(DataHelper.selectedRoleIndex)
        .victoryShow;

    internal void CreateGirl()
    {
        Object.Destroy(Girl);

        Girl = ResourcesManager.instance
            .LoadFromName<GameObject>(GetAssetName())
            .FastInstantiate();

        SetGirlParent();

        Girl.name = name;
        Girl.transform.localScale = ScaleVector;
        Girl.transform.position = new Vector3(6.7f, -5f, 1f);
    }

    protected virtual void SetGirlParent()
    {
        Girl.transform.SetParent(ParentTransform);
    }

    internal void SetParent(Transform parentTransform)
    {
        ParentTransform = parentTransform;
    }
}