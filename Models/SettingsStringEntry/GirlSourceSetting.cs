using MelonLoader;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class GirlSourceSetting : SettingsStringEntry
{
    internal GirlSourceSetting(MelonPreferences_Category category) : base(category, "GirlSource", GirlSources.Default){}
    
    protected override int StringToIndex(string s) => GirlSources.StringToIndex(s);

    protected override string IndexToString(int i) => GirlSources.IndexToString(i);
}