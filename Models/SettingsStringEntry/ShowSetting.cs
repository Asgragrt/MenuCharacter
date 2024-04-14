using MelonLoader;
using MenuCharacter.Utils;

namespace MenuCharacter.Models;

internal class ShowSetting : SettingsStringEntry
{
    internal ShowSetting(MelonPreferences_Category category) : base(category, "ShowType", Shows.Default) { }

    protected override string IndexToString(int i) => Shows.IndexToString(i);

    protected override int StringToIndex(string s) => Shows.StringToIndex(s);
}