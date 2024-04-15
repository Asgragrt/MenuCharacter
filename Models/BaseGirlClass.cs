using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Resources;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;
using Object = UnityEngine.Object;

namespace MenuCharacter.Models;

internal abstract class BaseGirlClass(string name, GirlSetting girlSetting)
{
    private static readonly DBConfigCharacter DBConfigCharacter = Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>();

    private bool _parentSet;

    protected Transform ParentTransform;

    protected GameObject Girl { get; private set; }

    protected virtual void SetGirlParent()
    {
        Girl.transform.SetParent(ParentTransform);
    }

    protected virtual void SetGirlPosition()
    {
        Girl.transform.position = girlSetting.Position;
    }

    internal void CreateGirl()
    {
        if (!_parentSet)
        {
            Logger.Debug($"{name} doesn't have a parent.");
            return;
        }

        Logger.Debug($"{name}: Destroying girl!");
        DestroyGirl();

        Logger.Debug($"{name}: Instantiating girl!");

        try
        {
            Girl = ResourcesManager.instance
                .LoadFromName<GameObject>(GetAssetName())
                .FastInstantiate();
        }
        catch (Exception e)
        {
            Logger.Error(e);
            return;
        }

        Logger.Debug($"{name}: Setting girl parent!");
        SetGirlParent();

        if (Girl.TryGetComponent(out MeshRenderer mr)) mr.sortingOrder = 100;

        Logger.Debug($"{name}: Scaling girl!");
        Girl.name = name;
        Girl.transform.localScale = girlSetting.Scale;
        SetGirlPosition();
    }

    internal void DestroyGirl()
    {
        Object.Destroy(Girl);
    }

    internal void SetParent(Transform parentTransform)
    {
        ParentTransform = parentTransform;
        _parentSet = true;
    }

    private string GetAssetName()
    {
        Logger.Debug($"{name}: Getting character info.");
        var charInfo = DBConfigCharacter.GetCharacterInfoByIndex(girlSetting.GirlIndex);

        var assetName = typeof(CharacterInfo).GetProperty(girlSetting.Property)
            ?.GetValue(charInfo, null)
            ?.ToString();

        Logger.Debug($"{name} asset name: {assetName}");

        return assetName;
    }
}