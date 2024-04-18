using Il2Cpp;
using Il2CppAssets.Scripts.Database;
using Il2CppAssets.Scripts.PeroTools.Commons;
using Il2CppAssets.Scripts.PeroTools.Managers;
using Il2CppPeroTools2.Resources;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;
using Object = UnityEngine.Object;

namespace MenuCharacter.Models.BaseClasses;

internal abstract class BaseGirlClass(string name, GirlSetting girlSetting)
{
    private static readonly DBConfigCharacter DBConfigCharacter = Singleton<ConfigManager>.instance
        .GetConfigObject<DBConfigCharacter>();

    protected readonly GirlSetting GirlSetting = girlSetting;

    protected Transform ParentTransform;

    private bool _parentSet;

    protected GameObject Girl { get; private set; }

    protected virtual void SetParent()
    {
        Girl.transform.SetParent(ParentTransform);
    }

    protected virtual void SetPosition()
    {
        if (!Girl)
        {
            Logger.Debug("Tried to set girl position when girl doesn't exist!");
            return;
        }

        Girl.transform.position = GirlSetting.Position;
    }

    internal void Create()
    {
        if (!GirlSetting.IsEnabled) return;
        Logger.Debug($"Creating {name} girl.");

        if (!_parentSet)
        {
            Logger.Debug($"{name} doesn't have a parent.");
            return;
        }

        Logger.Debug($"{name}: Destroying girl!");
        Destroy();


        if (!ParentTransform)
        {
            Logger.Debug($"{name}: Parent doesn't exist!");
            return;
        }

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
        SetParent();

        if (Girl.TryGetComponent(out MeshRenderer mr)) mr.sortingOrder = 100;

        Logger.Debug($"{name}: Scaling girl!");
        Girl.name = name;
        SetScale();
        SetPosition();
    }

    internal void SetParent(Transform parentTransform)
    {
        ParentTransform = parentTransform;
        _parentSet = true;
    }

    internal void Update()
    {
        Logger.Debug($"Updating {name} girl...");

        switch (GirlSetting.GetSettingStatusAndReset())
        {
            case { IsGirlDisabled: true }:
                Destroy();
                return;

            case { GirlNeedsRecreate: true }:
                Create();
                return;

            case { GirlPositionChanged: true }:
                SetScale();
                SetPosition();
                return;
        }
    }

    private void Destroy()
    {
        Object.Destroy(Girl);
        Logger.Debug($"Destroyed {name} girl.");
    }

    private string GetAssetName()
    {
        Logger.Debug($"{name}: Getting character info.");
        var charInfo = DBConfigCharacter.GetCharacterInfoByIndex(GirlSetting.GirlIndex);

        var assetName = typeof(CharacterInfo).GetProperty(GirlSetting.Property)
            ?.GetValue(charInfo, null)
            ?.ToString();

        Logger.Debug($"{name} asset name: {assetName}");

        return assetName;
    }

    private void SetScale()
    {
        if (!Girl)
        {
            Logger.Debug("Tried to set girl local scale when girl doesn't exist!");
            return;
        }

        Girl.transform.localScale = GirlSetting.Scale;
    }
}