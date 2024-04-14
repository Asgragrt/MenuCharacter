using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Resources;
using MenuCharacter.Models.Defines;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;
using Object = UnityEngine.Object;

namespace MenuCharacter.Models;

internal abstract class BaseGirlClass(string name)
{
    private static readonly DBConfigCharacter DBConfigCharacter = Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>();

    private int _girlIndex;

    private bool _parentSet;

    protected Transform ParentTransform;

    protected GameObject Girl { get; private set; }

    protected virtual void SetGirlParent()
    {
        Girl.transform.SetParent(ParentTransform);
    }

    protected virtual void SetGirlPosition()
    {
        Girl.transform.position = Positions.Position(_girlIndex);
    }

    internal void CreateGirl()
    {
        Logger.Debug($"{name}: Getting girl index!");
        _girlIndex = GirlSourceDefine.GetGirlIndex();

        if (!_parentSet)
        {
            Logger.Debug($"{name} doesn't have a parent.");
            return;
        }

        Logger.Debug($"{name}: Destroying girl!");
        Object.Destroy(Girl);

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
        SetGirlScale();
        SetGirlPosition();
    }

    internal void SetParent(Transform parentTransform)
    {
        ParentTransform = parentTransform;
        _parentSet = true;
    }

    private string GetAssetName()
    {
        Logger.Debug($"{name}: Getting character info.");
        var charInfo = DBConfigCharacter.GetCharacterInfoByIndex(_girlIndex);

        var assetName = typeof(CharacterInfo).GetProperty(ShowDefine.Property)
            ?.GetValue(charInfo, null)
            ?.ToString();

        Logger.Debug($"{name} asset name: {assetName}");

        return assetName;
    }

    private void SetGirlScale()
    {
        Girl.transform.localScale = ShowDefine.Scale;
    }
}