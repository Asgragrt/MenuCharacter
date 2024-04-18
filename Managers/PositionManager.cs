using MenuCharacter.Enums;
using UnityEngine;

namespace MenuCharacter.Managers;

internal static class PositionManager
{
    internal static Vector3 GetPosition(int show, int charIdx)
    {
        var character = (Character)charIdx;

        return (Show)show switch
        {
            Show.Main => GetMainPosition(character),
            Show.Victory => GetVictoryPosition(character),
            Show.Fail => GetFailPosition(character),
            _ => new Vector3(6.7f, -5f, 100f)
        };
    }

    private static Vector3 GetFailPosition(Character c)
    {
        switch (c)
        {
            case Character.RinBassist:
            case Character.RinBadGirl:
            case Character.RinBunnyGirl:
                return new Vector3(6.7f, -4.7f, 100f);

            case Character.RinSleepwalkerGirl:
                return new Vector3(6.7f, -4f, 100f);

            case Character.BuroPilot:
            case Character.BuroIdol:
            case Character.BuroZombieGirl:
            case Character.BuroJoker:
            case Character.BuroSailorSuit:
                return new Vector3(6.7f, -4f, 100f);

            case Character.MarijaViolinist:
            case Character.MarijaMaid:
            case Character.MarijaMagicalGirl:
            case Character.MarijaLittleDevil:
            case Character.MarijaTheGirlInBlack:
                return new Vector3(6.7f, -4.4f, 100f);

            case Character.RinChristmasGift:
                return new Vector3(6.7f, -3.8f, 100f);

            case Character.Yume:
                return new Vector3(6.7f, -3.8f, 100f);

            case Character.Neko:
                return new Vector3(6.7f, -4.3f, 100f);

            case Character.RinPartTimeWarrior:
                return new Vector3(6.7f, -4.3f, 100f);

            case Character.HakureiReimu:
                return new Vector3(6.7f, -3.8f, 100f);

            case Character.ElClear:
                return new Vector3(6.7f, -3.8f, 100f);

            case Character.MarijaSister:
                return new Vector3(6.7f, -3.9f, 100f);

            case Character.KirisameMarisa:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.Amiya:
                return new Vector3(6.7f, -3.9f, 100f);

            case Character.OlaBoxer:
                return new Vector3(6.7f, -4f, 100f);

            case Character.BuroExorcistMaster:
                return new Vector3(5f, -4.2f, 100f);

            case Character.HatsuneMiku:
                return new Vector3(6.7f, -3.8f, 100f);

            case Character.KagamineRinLen:
                return new Vector3(6.7f, -4.6f, 100f);

            default:
                return new Vector3(6.7f, -4f, 100f);
        }
    }

    private static Vector3 GetMainPosition(Character c)
    {
        switch (c)
        {
            case Character.RinBassist:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.RinBadGirl:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.RinSleepwalkerGirl:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.RinBunnyGirl:
                return new Vector3(6.7f, -4.8f, 100f);

            case Character.BuroPilot:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.BuroIdol:
                return new Vector3(6.7f, -4.6f, 100f);

            case Character.BuroZombieGirl:
                return new Vector3(6.7f, -5.1f, 100f);

            case Character.BuroJoker:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.MarijaViolinist:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.MarijaMaid:
                return new Vector3(6.7f, -5.2f, 100f);

            case Character.MarijaMagicalGirl:
                return new Vector3(6.7f, -5.2f, 100f);

            case Character.MarijaLittleDevil:
                return new Vector3(6.7f, -4.1f, 100f);

            case Character.MarijaTheGirlInBlack:
                return new Vector3(5.6f, -5.4f, 100f);

            case Character.RinChristmasGift:
                return new Vector3(6.7f, -5.7f, 100f);

            case Character.BuroSailorSuit:
                return new Vector3(6.7f, -5.4f, 100f);

            case Character.Yume:
                return new Vector3(6.7f, -5.2f, 100f);

            case Character.Neko:
                return new Vector3(6.7f, -5f, 100f);

            case Character.RinPartTimeWarrior:
                return new Vector3(6.7f, -5f, 100f);

            case Character.HakureiReimu:
                return new Vector3(6.3f, -4.8f, 100f);

            case Character.ElClear:
                return new Vector3(6.7f, -5f, 100f);

            case Character.MarijaSister:
                return new Vector3(6.7f, -5.5f, 100f);

            case Character.KirisameMarisa:
                return new Vector3(6.7f, -4.5f, 100f);

            case Character.Amiya:
                return new Vector3(6.7f, -4.4f, 100f);

            case Character.OlaBoxer:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.BuroExorcistMaster:
                return new Vector3(6.7f, -5f, 100f);

            case Character.HatsuneMiku:
                return new Vector3(6.7f, -4f, 100f);

            case Character.KagamineRinLen:
                return new Vector3(6.7f, -3.5f, 100f);

            default:
                return new Vector3(6.7f, -5f, 100f);
        }
    }

    private static Vector3 GetVictoryPosition(Character c)
    {
        switch (c)
        {
            case Character.RinBassist:
                return new Vector3(6.7f, -5f, 100f);

            case Character.RinBadGirl:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.RinSleepwalkerGirl:
                return new Vector3(6.7f, -3.2f, 100f);

            case Character.RinBunnyGirl:
                return new Vector3(6.7f, -5f, 100f);

            case Character.BuroPilot:
                return new Vector3(6.7f, -4.9f, 100f);

            case Character.BuroIdol:
                return new Vector3(6.7f, -5f, 100f);

            case Character.BuroZombieGirl:
                return new Vector3(6.7f, -5f, 100f);

            case Character.BuroJoker:
                return new Vector3(6.7f, -5f, 100f);

            case Character.MarijaViolinist:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.MarijaMaid:
                return new Vector3(6.7f, -4.1f, 100f);

            case Character.MarijaMagicalGirl:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.MarijaLittleDevil:
                return new Vector3(6.7f, -4.5f, 100f);

            case Character.MarijaTheGirlInBlack:
                return new Vector3(6.7f, -4.7f, 100f);

            case Character.RinChristmasGift:
                return new Vector3(6.7f, -4.5f, 100f);

            case Character.BuroSailorSuit:
                return new Vector3(6.7f, -5.6f, 100f);

            case Character.Yume:
                return new Vector3(6.7f, -5f, 100f);

            case Character.Neko:
                return new Vector3(6.7f, -4f, 100f);

            case Character.RinPartTimeWarrior:
                return new Vector3(6.7f, -5.2f, 100f);

            case Character.HakureiReimu:
                return new Vector3(6.7f, -4f, 100f);

            case Character.ElClear:
                return new Vector3(6.7f, -5f, 100f);

            case Character.MarijaSister:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.KirisameMarisa:
                return new Vector3(6.7f, -5.6f, 100f);

            case Character.Amiya:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.OlaBoxer:
                return new Vector3(6.7f, -5f, 100f);

            case Character.BuroExorcistMaster:
                return new Vector3(6.7f, -4.2f, 100f);

            case Character.HatsuneMiku:
                return new Vector3(6.7f, -3.9f, 100f);

            case Character.KagamineRinLen:
                return new Vector3(6.7f, -5.4f, 100f);

            default:
                return new Vector3(6.7f, -5f, 100f);
        }
    }
}