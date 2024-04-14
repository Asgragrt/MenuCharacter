using MenuCharacter.Enums;
using MenuCharacter.Managers;
using UnityEngine;

namespace MenuCharacter.Models;

internal static class Positions
{
    internal static Vector3 GetFailPosition(Character c)
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
                return new Vector3(6.7f, -3.8f, 100f);

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

    internal static Vector3 GetPosition(int show, int character)
    {
        return (Show)show switch
        {
            Show.Victory => GetVictoryPosition((Character)character),
            _ => new Vector3(6.7f, -5f, 100f)
        };
    }

    internal static Vector3 GetVictoryPosition(Character c)
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

    internal static Vector3 Position(int character) => GetPosition(SettingsManager.Show.Index, character);
}