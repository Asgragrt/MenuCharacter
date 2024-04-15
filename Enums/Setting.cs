namespace MenuCharacter.Models;

internal enum Setting
{
    None = 0,

    Girl = 1,

    GirlShow = 2,

    GirlChange = Girl | GirlShow,

    Flip = 4,

    Side = 8,

    PositionChange = Flip | Side,
    
    Enabled = 16,
}