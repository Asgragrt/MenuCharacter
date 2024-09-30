/* cSpell:disable */
using MenuCharacter.Enums;
using MenuCharacter.Models.Interfaces;
using UnityEngine;

namespace MenuCharacter.Models.Settings;

internal class VictoryShow : IShowSetting
{
    string IShowSetting.Property => "victoryShow";

    Vector3 IShowSetting.Scale { get; } = new(0.5f, 0.5f, 100f);

    static Vector3 Position(Character character) =>
        character switch
        {
            Character.RinBassist => new Vector3(6.7f, -5f, 100f),
            Character.RinBadGirl => new Vector3(6.7f, -4.2f, 100f),
            Character.RinSleepwalkerGirl => new Vector3(6.7f, -3.2f, 100f),
            Character.RinBunnyGirl => new Vector3(6.7f, -5f, 100f),
            Character.BuroPilot => new Vector3(6.7f, -4.9f, 100f),
            Character.BuroIdol => new Vector3(6.7f, -5f, 100f),
            Character.BuroZombieGirl => new Vector3(6.7f, -5f, 100f),
            Character.BuroJoker => new Vector3(6.7f, -5f, 100f),
            Character.MarijaViolinist => new Vector3(6.7f, -4.2f, 100f),
            Character.MarijaMaid => new Vector3(6.7f, -4.1f, 100f),
            Character.MarijaMagicalGirl => new Vector3(6.7f, -4.2f, 100f),
            Character.MarijaLittleDevil => new Vector3(6.7f, -4.5f, 100f),
            Character.MarijaTheGirlInBlack => new Vector3(6.7f, -4.7f, 100f),
            Character.RinChristmasGift => new Vector3(6.7f, -4.5f, 100f),
            Character.BuroSailorSuit => new Vector3(6.7f, -5.6f, 100f),
            Character.Yume => new Vector3(6.7f, -5f, 100f),
            Character.Neko => new Vector3(6.7f, -4f, 100f),
            Character.RinPartTimeWarrior => new Vector3(6.7f, -5.2f, 100f),
            Character.HakureiReimu => new Vector3(6.7f, -4f, 100f),
            Character.ElClear => new Vector3(6.7f, -5f, 100f),
            Character.MarijaSister => new Vector3(6.7f, -4.2f, 100f),
            Character.KirisameMarisa => new Vector3(6.7f, -5.6f, 100f),
            Character.Amiya => new Vector3(6.7f, -4.2f, 100f),
            Character.OlaBoxer => new Vector3(6.7f, -5f, 100f),
            Character.BuroExorcistMaster => new Vector3(6.7f, -4.2f, 100f),
            Character.HatsuneMiku => new Vector3(6.7f, -3.9f, 100f),
            Character.KagamineRinLen => new Vector3(6.7f, -5.4f, 100f),
            Character.RinRacer => new Vector3(5.5f, -5.8f, 100f),
            Character.MarijaDancer => new Vector3(6.7f, -6.5f, 100f),
            _ => new Vector3(6.7f, -5f, 100f)
        };

    Vector3 IShowSetting.Position(int character) => Position((Character)character);
}
