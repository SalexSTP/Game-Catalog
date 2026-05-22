namespace Domain.Enums;

[Flags]
public enum GamePlatform
{
    None = 0,
    Pc = 1,
    PlayStation = 2,
    Xbox = 4,
    Switch = 8,
    Mobile = 16,
}