using MenuCharacter.Enums;
using MenuCharacter.Models.Interfaces;
using UnityEngine;

namespace MenuCharacter.Models.Settings;

internal class FailShow : IShowSetting
{
    string IShowSetting.Property => "failShow";

    Vector3 IShowSetting.Scale { get; } = new(0.75f, 0.75f, 100f);

    Vector3 IShowSetting.Position(int character)
    {
        switch ((Character)character)
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
}