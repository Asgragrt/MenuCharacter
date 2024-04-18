using UnityEngine;

namespace MenuCharacter.Utils;

internal static class Extensions
{
    internal static void FlipX(this ref Vector3 v) => v.x *= -1;

    internal static bool InvEquals(this string s1, string s2) =>
        string.Equals(s1, s2, StringComparison.InvariantCultureIgnoreCase);

    internal static bool ToBool(this int val) => val is not 0;
}