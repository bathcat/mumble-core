namespace MC.Canvas.Core;

using System;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// Inspired by: https://stackoverflow.com/questions/7305785/does-c-sharp-have-an-unsigned-double
/// </remarks>
public readonly record struct UFloat
{
    public readonly float Value;

    public UFloat(float value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("value");
        }
        Value = value;
    }

    public static implicit operator float(UFloat uf)
        => uf.Value;

    public static implicit operator UFloat(float f)
        => new(f);

    public static bool operator <(UFloat a, UFloat b)
        => a.Value < b.Value;

    public static bool operator >(UFloat a, UFloat b)
        => a.Value > b.Value;

    public static bool operator <=(UFloat a, UFloat b)
        => a.Value <= b.Value;

    public static bool operator >=(UFloat a, UFloat b)
        => a.Value >= b.Value;

};