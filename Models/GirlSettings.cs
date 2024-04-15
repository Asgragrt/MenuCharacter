using Il2CppAssets.Scripts.Database;
using MelonLoader;
using MenuCharacter.Enums;
using MenuCharacter.Managers;
using MenuCharacter.Models.Defines;
using UnityEngine;

namespace MenuCharacter.Models;

internal class GirlSetting
{
    private readonly MelonPreferences_Category _category;

    private readonly MelonPreferences_Entry<bool> _flip;

    private readonly SettingsStringEntry _girl;

    private readonly SettingsStringEntry _girlShow;

    private readonly MelonPreferences_Entry<bool> _isEnabled;

    private readonly string _name;

    private readonly SettingsStringEntry _side;

    private int _settingChanged = (int)Setting.None;

    internal GirlSetting(string name, bool descEnable = true)
    {
        _name = name;

        _category = MelonPreferences.CreateCategory(_name);
        _category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _isEnabled = _category.CreateEntry("IsEnabled", true);
        _girlShow = new SettingsStringEntry(_category, "GirlShow", ModManager.ShowDefine, descEnable);
        _girl = new SettingsStringEntry(_category, _name, ModManager.CharacterDefine, descEnable);
        _flip = _category.CreateEntry("FlipGirl", true);
        _side = new SettingsStringEntry(_category, "ScreenSide", ModManager.SideDefine, descEnable);

        _girlShow.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (!_girlShow.SanitizedEqual(oldV, newV)) _settingChanged |= (int)Setting.GirlShow;
        });

        _girl.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (!_girl.SanitizedEqual(oldV, newV)) _settingChanged |= (int)Setting.Girl;
        });

        _flip.OnEntryValueChanged.Subscribe((_, _) => { _settingChanged |= (int)Setting.Flip; });

        _side.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (!_side.SanitizedEqual(oldV, newV)) _settingChanged |= (int)Setting.Side;
        });

        _isEnabled.OnEntryValueChanged.Subscribe((_, _) => { _settingChanged |= (int)Setting.Enabled; });
    }

    internal bool IsEnabled => _isEnabled.Value;

    internal int ShowIndex => _girlShow.Index;

    internal int FixedGirlIndex => _girl.Index;

    internal bool Flip => _flip.Value;

    internal int GirlIndex
    {
        get
        {
            return (Track)SettingsManager.Track.Index switch
            {
                Track.Selected => DataHelper.selectedRoleIndex,
                Track.Fixed => FixedGirlIndex,
                _ => DataHelper.selectedRoleIndex
            };
        }
    }

    internal string Property => ShowDefine.IndexToProperty(ShowIndex);

    internal Vector3 Scale => ShowDefine.IndexToScale(ShowIndex, Flip);

    internal Vector3 Position
    {
        get
        {
            var position = Positions.GetPosition(ShowIndex, GirlIndex);

            switch ((Side)_side.Index)
            {
                case Side.Right:
                    return position;
                case Side.Left:
                    position.x *= -1;
                    return position;
                default:
                    return position;
            }
        }
    }

    internal int GetSettingStatusAndReset()
    {
        var setting = _settingChanged;
        _settingChanged = (int)Setting.None;
        return setting;
    }
}