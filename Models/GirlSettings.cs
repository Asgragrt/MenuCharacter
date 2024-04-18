using Il2CppAssets.Scripts.Database;
using MelonLoader;
using MenuCharacter.Enums;
using MenuCharacter.Managers;
using MenuCharacter.Models.Defines;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class GirlSetting
{
    private readonly MelonPreferences_Entry<bool> _flip;

    private readonly SettingsStringEntry _girl;

    private readonly SettingsStringEntry _girlShow;

    private readonly MelonPreferences_Entry<bool> _isEnabled;

    private readonly SettingsStringEntry _side;

    private readonly SettingsStringEntry _track;

    private int _settingChanged = (int)Setting.None;

    internal GirlSetting(string name, bool descEnable = true)
    {
        var category = MelonPreferences.CreateCategory(name);
        category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _isEnabled = category.CreateEntry("IsEnabled", true);
        _track = new SettingsStringEntry(category, "TrackType", ModManager.TrackDefine, descEnable);
        _girlShow = new SettingsStringEntry(category, "GirlShow", ModManager.ShowDefine, descEnable);
        _girl = new SettingsStringEntry(category, name, ModManager.CharacterDefine, descEnable);
        _flip = category.CreateEntry("FlipGirl", true);
        _side = new SettingsStringEntry(category, "ScreenSide", ModManager.SideDefine, descEnable);

        _track.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            Logger.Debug($"TrackType changed to {newV}");
            if (!_track.SanitizedStringEqual(oldV, newV)) _settingChanged |= (int)Setting.Track;
        });

        _girlShow.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (!_girlShow.SanitizedStringEqual(oldV, newV)) _settingChanged |= (int)Setting.GirlShow;
        });

        _girl.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (_track.Index is (int)Track.Selected) return;
            if (!_girl.SanitizedStringEqual(oldV, newV)) _settingChanged |= (int)Setting.Girl;
        });

        _flip.OnEntryValueChanged.Subscribe((_, _) => { _settingChanged |= (int)Setting.Flip; });

        _side.OnEntryValueChanged.Subscribe((oldV, newV) =>
        {
            if (!_side.SanitizedStringEqual(oldV, newV)) _settingChanged |= (int)Setting.Side;
        });

        _isEnabled.OnEntryValueChanged.Subscribe((_, _) => { _settingChanged |= (int)Setting.Enabled; });
    }

    internal bool IsEnabled => _isEnabled.Value;

    internal int ShowIndex => _girlShow.Index;

    internal int FixedGirlIndex => _girl.Index;

    internal int TrackIndex => _track.Index;

    internal bool Flip => _flip.Value;

    internal int GirlIndex => (Track)TrackIndex switch
    {
        Track.Selected => DataHelper.selectedRoleIndex,
        Track.Fixed => FixedGirlIndex,
        _ => DataHelper.selectedRoleIndex
    };


    internal string Property => ShowDefine.IndexToProperty(ShowIndex);

    internal Vector3 Scale => ShowDefine.IndexToScale(ShowIndex, Flip);

    internal Vector3 Position => GetPosition();

    internal SettingsStatusChange GetSettingStatusAndReset()
    {
        var setting = _settingChanged;
        _settingChanged = (int)Setting.None;
        return new SettingsStatusChange(this, setting);
    }

    internal void SetIndexChanged()
    {
        // Set index changed only if it is selected
        if (TrackIndex is not (int)Track.Selected) return;
        _settingChanged |= (int)Setting.Girl;
    }

    private Vector3 GetPosition()
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