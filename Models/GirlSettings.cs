using Il2CppAssets.Scripts.Database;
using MelonLoader;
using MenuCharacter.Enums;
using MenuCharacter.Managers;
using MenuCharacter.Models.Interfaces;
using MenuCharacter.Models.Settings;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class GirlSetting
{
    private static readonly IShowSetting MainShow = new MainShow();

    private static readonly IShowSetting VictoryShow = new VictoryShow();

    private static readonly IShowSetting FailShow = new FailShow();

    private readonly MelonPreferences_Entry<bool> _flip;

    private readonly SettingsStringEntry _girl;

    private readonly SettingsStringEntry _girlShow;

    private readonly MelonPreferences_Entry<bool> _isEnabled;

    private readonly SettingsStringEntry _side;

    private readonly SettingsStringEntry _track;

    private IShowSetting _currentShow;

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
            if (_girlShow.SanitizedStringEqual(oldV, newV)) return;

            _settingChanged |= (int)Setting.GirlShow;

            SetShow();
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

    internal string Property => _currentShow.Property;

    internal Vector3 Scale => GetScale();

    internal Vector3 Position => GetPosition();

    internal SettingsStatusChange GetSettingStatusAndReset()
    {
        var setting = _settingChanged;
        _settingChanged = (int)Setting.None;
        return new SettingsStatusChange(this, setting);
    }

    internal void Load()
    {
        _track.SanitizeValue();
        _girlShow.SanitizeValue();
        _girl.SanitizeValue();
        _side.SanitizeValue();

        SetShow();
    }

    internal void SetIndexChanged()
    {
        // Set index changed only if it is selected
        if (TrackIndex is not (int)Track.Selected) return;
        _settingChanged |= (int)Setting.Girl;
    }

    private Vector3 GetPosition()
    {
        var position = _currentShow.Position(GirlIndex);

        if ((Side)_side.Index is Side.Left) position.x *= -1;

        return position;
    }

    private Vector3 GetScale()
    {
        var scale = _currentShow.Scale;

        if (Flip) scale.x *= -1;

        return scale;
    }

    private void SetShow()
    {
        _currentShow = (Show)_girlShow.Index switch
        {
            Show.Main => MainShow,
            Show.Victory => VictoryShow,
            Show.Fail => FailShow,
            _ => VictoryShow
        };
    }
}