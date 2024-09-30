using Il2CppAssets.Scripts.Database;
using MelonLoader;
using MenuCharacter.Enums;
using MenuCharacter.Managers;
using MenuCharacter.Models.Interfaces;
using MenuCharacter.Models.Settings;
using MenuCharacter.Utils;
using UnityEngine;
using Logger = MenuCharacter.Utils.Logger;

namespace MenuCharacter.Models;

internal class GirlSetting
{
    private static readonly IShowSetting FailShow = new FailShow();

    private static readonly IShowSetting MainShow = new MainShow();

    private static readonly IShowSetting VictoryShow = new VictoryShow();

    private readonly MelonPreferences_Entry<bool> _flip;

    private readonly SettingsStringEntry<Character> _girl;

    private readonly SettingsStringEntry<Show> _girlShow;

    private readonly MelonPreferences_Entry<bool> _isEnabled;

    private readonly SettingsStringEntry<Side> _side;

    private readonly SettingsStringEntry<Track> _track;

    private IShowSetting _currentShow;

    private int _settingChanged = (int)Setting.None;

    internal GirlSetting(string name, bool descEnable = true)
    {
        var category = MelonPreferences.CreateCategory(name);
        category.SetFilePath(SettingsManager.SettingsPath, false, false);

        _isEnabled = category.CreateEntry("IsEnabled", true);
        _track = new SettingsStringEntry<Track>(category, "TrackType", Track.Fixed, descEnable);
        _girlShow = new SettingsStringEntry<Show>(category, "GirlShow", Show.Victory, descEnable);
        _girl = new SettingsStringEntry<Character>(
            category,
            name,
            Character.MarijaLittleDevil,
            descEnable
        );
        _flip = category.CreateEntry("FlipGirl", true);
        _side = new SettingsStringEntry<Side>(category, "ScreenSide", Side.Right, descEnable);

        _track.OnEntryValueChanged.Subscribe(
            (oldV, newV) =>
            {
                Logger.Debug($"{_track} changed from {oldV} to {newV}");
                _settingChanged |= (int)Setting.Track;
            }
        );

        _girlShow.OnEntryValueChanged.Subscribe(
            (oldV, newV) =>
            {
                Logger.Debug($"{_girlShow} changed from {oldV} to {newV}");
                _settingChanged |= (int)Setting.GirlShow;
                SetShow();
            }
        );

        _girl.OnEntryValueChanged.Subscribe(
            (oldV, newV) =>
            {
                Logger.Debug($"{_girl} changed from {oldV} to {newV}");

                if (_track.Index is (int)Track.Selected)
                    return;
                _settingChanged |= (int)Setting.Girl;
            }
        );

        _flip.OnEntryValueChanged.Subscribe(
            (_, _) =>
            {
                _settingChanged |= (int)Setting.Flip;
            }
        );

        _side.OnEntryValueChanged.Subscribe(
            (oldV, newV) =>
            {
                Logger.Debug($"{_side} changed from {oldV} to {newV}");
                _settingChanged |= (int)Setting.Side;
            }
        );

        _isEnabled.OnEntryValueChanged.Subscribe(
            (_, _) =>
            {
                _settingChanged |= (int)Setting.Enabled;
            }
        );

        SetShow();
    }

    private enum Setting
    {
        None = 0,

        Girl = 1,

        GirlShow = 2,

        Flip = 4,

        Side = 8,

        PositionChange = Flip | Side,

        Track = 16,

        Enabled = 32,

        GirlChange = Girl | GirlShow | Track | Enabled
    }

    internal int FixedGirlIndex => _girl.Index;

    internal bool Flip => _flip.Value;

    internal int GirlIndex =>
        _track.EnumVal switch
        {
            Track.Selected => DataHelper.selectedRoleIndex,
            Track.Fixed => FixedGirlIndex,
            _ => DataHelper.selectedRoleIndex
        };

    internal bool IsEnabled => _isEnabled.Value;

    internal Vector3 Position => GetPosition();

    internal string Property => _currentShow.Property;

    internal Vector3 Scale => GetScale();

    internal int ShowIndex => _girlShow.Index;

    internal int TrackIndex => _track.Index;

    internal StatusChange GetSettingStatusAndReset()
    {
        var setting = _settingChanged;
        _settingChanged = (int)Setting.None;
        return new StatusChange(this, setting);
    }

    internal void SetIndexChanged()
    {
        // Set index changed only if it is selected
        if (_track.EnumVal is not Track.Selected)
            return;
        _settingChanged |= (int)Setting.Girl;
    }

    private Vector3 GetPosition()
    {
        var position = _currentShow.Position(GirlIndex);

        if (_side.EnumVal is Side.Left)
            position.FlipX();

        return position;
    }

    private Vector3 GetScale()
    {
        var scale = _currentShow.Scale;

        if (Flip)
            scale.FlipX();

        return scale;
    }

    private void SetShow()
    {
        _currentShow = _girlShow.EnumVal switch
        {
            Show.Main => MainShow,
            Show.Victory => VictoryShow,
            Show.Fail => FailShow,
            _ => VictoryShow
        };
    }

    internal readonly struct StatusChange(GirlSetting girlSetting, int val)
    {
        internal bool GirlNeedsRecreate => (val & (int)Setting.GirlChange).ToBool();

        internal bool GirlPositionChanged => (val & (int)Setting.PositionChange).ToBool();

        internal bool IsGirlDisabled => !girlSetting.IsEnabled;
    }
}
