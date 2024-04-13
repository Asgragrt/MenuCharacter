using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Resources;
using MenuCharacter.Managers;
using MenuCharacter.Utils;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;
using Object = UnityEngine.Object;

namespace MenuCharacter.Models;

internal abstract class GirlBaseClass(string name)
{
    private static readonly DBConfigCharacter DBConfigCharacter = Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>();

    private bool _parentSet;

    protected Transform ParentTransform;

    protected GameObject Girl { get; private set; }

    private static string GetAssetName()
    {
        Logger.Debug("Getting character info.");
        var charInfo = DBConfigCharacter.GetCharacterInfoByIndex(DataHelper.selectedRoleIndex);

        return SettingsManager.ShowIndex switch
        {
            Shows.Main => charInfo.mainShow,
            Shows.Victory => charInfo.victoryShow,
            _ => charInfo.failShow
        };
    }

    internal void CreateGirl()
    {
        if (!_parentSet)
        {
            Logger.Debug($"{name} doesn't have a parent.");
            return;
        }

        Logger.Debug($"{name}: Destroying girl!");
        Object.Destroy(Girl);

        Logger.Debug($"{name}: Instantiating girl!");

        Girl = ResourcesManager.instance
            .LoadFromName<GameObject>(GetAssetName())
            .FastInstantiate();

        Logger.Debug($"{name}: Setting girl parent!");
        SetGirlParent();

        if (Girl.TryGetComponent(out MeshRenderer mr)) mr.sortingOrder = 100;

        Logger.Debug($"{name}: Scaling girl!");
        Girl.name = name;
        SetGirlScale();
        Girl.transform.position = new Vector3(6.7f, -5f, 100f);
    }

    private void SetGirlScale()
    {
        Girl.transform.localScale = SettingsManager.ShowIndex switch
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
        _parentSet = true;
    }
}