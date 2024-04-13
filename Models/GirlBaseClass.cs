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
    private static readonly DBConfigCharacter _dbConfigCharacter = Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>();

    private static readonly int _show = 0;

    protected Transform ParentTransform;

    protected GameObject Girl { get; private set; }

    private static string GetAssetName()
    {
        var charInfo = _dbConfigCharacter.GetCharacterInfoByIndex(DataHelper.selectedRoleIndex);

        return _show switch
        {
            Shows.Main => charInfo.mainShow,
            Shows.Victory => charInfo.victoryShow,
            _ => charInfo.failShow
        };
    }

    internal void CreateGirl()
    {
        Object.Destroy(Girl);

        Girl = ResourcesManager.instance
            .LoadFromName<GameObject>(GetAssetName())
            .FastInstantiate();

        SetGirlParent();

        //if (!Girl.TryGetComponent(out RectTransform _)) Girl.AddComponent<RectTransform>();
        if (Girl.TryGetComponent(out MeshRenderer mr)) mr.sortingOrder = 100;

        Girl.name = name;
        SetGirlScale();
        Girl.transform.position = new Vector3(6.7f, -5f, 100f);
    }

    private void SetGirlScale()
    {
        Girl.transform.localScale = _show switch
        {
            Shows.Main => new Vector3(-50f, 50f, 100f),
            Shows.Victory => new Vector3(-0.5f, 0.5f, 100f),
            _ => new Vector3(-0.75f, 0.75f, 100f)
        };
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