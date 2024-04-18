namespace MenuCharacter.Enums;

internal enum Setting
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