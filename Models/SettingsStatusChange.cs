using MenuCharacter.Enums;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal readonly struct SettingsStatusChange(GirlSetting girlSetting, int val)
{
    internal bool IsGirlDisabled => !girlSetting.IsEnabled;
    internal bool GirlNeedsRecreate => (val & (int)Setting.GirlChange).ToBool();
    internal bool GirlPositionChanged => (val & (int)Setting.PositionChange).ToBool();
}