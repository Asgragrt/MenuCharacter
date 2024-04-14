namespace MenuCharacter.Utils;

internal static class Extensions
{
    internal static bool InvEquals(this string s1, string s2) =>
        string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);
}