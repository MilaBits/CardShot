using System;

[Flags]
public enum EffectTarget
{
    None = 0,
    Self = 1,
    Opponent = 2,
    Area = 4
}
