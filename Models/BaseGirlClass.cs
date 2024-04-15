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
        Girl.transform.position = GirlSetting.Position;
    }

    internal void Create()
    {
        if (!GirlSetting.IsEnabled) return;

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

    internal void Destroy()
    {
        Object.Destroy(Girl);
    }

    internal void SetParent(Transform parentTransform)
    {
        ParentTransform = parentTransform;
        _parentSet = true;
    }

    internal void Update()
    {
        if (!GirlSetting.IsEnabled)
        {
            Destroy();
            Logger.Debug($"Destroyed {name} girl.");
            return;
        }

        var setting = GirlSetting.GetSettingStatusAndReset();

        if ((setting & (int)Setting.GirlChange) != 0 // If girl changed
            || GirlSetting.IsEnabled && (setting & (int)Setting.Enabled) != 0) // Or if it went from disabled to enabled
        {
            Create();
            Logger.Debug($"Updated {name} girl.");
            return;
        }

        if ((setting & (int)Setting.PositionChange) == 0) return;
        SetScale();
        SetPosition();
        Logger.Debug($"Updated {name} girl position/scale.");
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

    private void SetScale() => Girl.transform.localScale = GirlSetting.Scale;
}