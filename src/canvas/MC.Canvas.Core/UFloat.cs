namespace MC.Canvas.Core;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// Inspired by: https://stackoverflow.com/questions/7305785/does-c-sharp-have-an-unsigned-double
/// </remarks>
public readonly record struct UFloat : IFloatingPoint<UFloat>
{
    public readonly float Value;

    public static UFloat E
        => new(float.E);

    public static UFloat Pi
        => new(float.Pi);

    public static UFloat Tau
        => new(float.Tau);

    public static UFloat NegativeOne => throw new NotImplementedException();

    public static UFloat One
        => new(1);

    public static int Radix => throw new NotImplementedException();

    public static UFloat Zero
        => new(0);

    public static UFloat AdditiveIdentity
        => new(0);

    public static UFloat MultiplicativeIdentity
        => new(1);

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

    public static UFloat operator %(UFloat left, UFloat right)
        => new(left.Value % right.Value);

    public static UFloat operator +(UFloat left, UFloat right)
        => new(left.Value + right.Value);

    public static UFloat operator --(UFloat value)
        => throw new NotImplementedException();

    public static UFloat operator /(UFloat left, UFloat right)
        => new(left.Value / right.Value);

    public static UFloat operator ++(UFloat value)
        => throw new NotImplementedException();

    public static UFloat operator *(UFloat left, UFloat right)
        => new(left.Value * right.Value);
    public static UFloat operator -(UFloat left, UFloat right)
        => new(left.Value - right.Value);

    public static UFloat operator -(UFloat value)
        => throw new NotImplementedException();

    public static UFloat operator +(UFloat value)
        => value;

    public int GetExponentByteCount()
        => throw new NotImplementedException();

    public int GetExponentShortestBitLength()
        => throw new NotImplementedException();

    public int GetSignificandBitLength()
        => throw new NotImplementedException();

    public int GetSignificandByteCount()
        => throw new NotImplementedException();




    public int CompareTo(UFloat other)
        => this.Value.CompareTo(other.Value);

    public static UFloat Abs(UFloat value)
        => value;

    public static bool IsEvenInteger(UFloat value)
        => Single.IsEvenInteger(value.Value);


    public static bool IsFinite(UFloat value)
        => Single.IsFinite(value.Value);

    public int CompareTo(object? obj) => obj switch
    {
        UFloat objAsUFloat => this.Value.CompareTo(objAsUFloat.Value),
        _ => this.Value.CompareTo(obj)
    };

    public static bool IsInfinity(UFloat value)
        => Single.IsInfinity(value.Value);

    public static bool IsInteger(UFloat value)
        => Single.IsInteger(value.Value);

    public static bool IsNaN(UFloat value)
        => Single.IsNaN(value.Value);

    public static bool IsNegative(UFloat value)
        => false;

    public static bool IsNegativeInfinity(UFloat value)
        => false;

    public static bool IsNormal(UFloat value)
        => Single.IsNormal(value.Value);

    public static bool IsOddInteger(UFloat value)
        => Single.IsOddInteger(value.Value);
    public static bool IsPositive(UFloat value)
        => Single.IsPositive(value.Value);
    public static bool IsPositiveInfinity(UFloat value)
        => Single.IsPositiveInfinity(value.Value);
    public static bool IsRealNumber(UFloat value)
        => Single.IsRealNumber(value.Value);

    public static bool IsSubnormal(UFloat value)
        => Single.IsSubnormal(value.Value);
    public static bool IsZero(UFloat value)
        => value.Value == 0;

    public static UFloat MaxMagnitude(UFloat x, UFloat y)
        => new(Single.MaxMagnitude(x.Value, y.Value));

    public static UFloat MaxMagnitudeNumber(UFloat x, UFloat y)
        => new(Single.MaxMagnitudeNumber(x.Value, y.Value));

    public static UFloat MinMagnitude(UFloat x, UFloat y)
        => new(Single.MinMagnitude(x.Value, y.Value));

    public static UFloat MinMagnitudeNumber(UFloat x, UFloat y)
        => new(Single.MinMagnitudeNumber(x.Value, y.Value));

    public static UFloat Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        => new(Single.Parse(s, style, provider));

    public static UFloat Parse(string s, NumberStyles style, IFormatProvider? provider)
        => new(Single.Parse(s, style, provider));
    public string ToString(string? format, IFormatProvider? formatProvider)
        => this.Value.ToString(format, formatProvider);

    public static UFloat Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => new(Single.Parse(s, provider));

    public static UFloat Parse(string s, IFormatProvider? provider)
        => new(Single.Parse(s, provider));

    public static bool IsComplexNumber(UFloat value)
    => false;

    public static bool IsImaginaryNumber(UFloat value)
        => false;

    public static UFloat Round(UFloat x, int digits, MidpointRounding mode)
        => new(Single.Round(x.Value, digits, mode));

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UFloat result)
    {
        float value = 0;
        var success = Single.TryParse(s, style, provider, out value);
        result = new(value);
        return success;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out UFloat result)
    {
        float value = 0;
        var success = Single.TryParse(s, style, provider, out value);
        result = new(value);
        return success;
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => this.Value.TryFormat(destination, out charsWritten, format, provider);

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out UFloat result)
    {
        float value = 0;
        var success = Single.TryParse(s, provider, out value);
        result = new(value);
        return success;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out UFloat result)
    {
        float value = 0;
        var success = Single.TryParse(s, provider, out value);
        result = new(value);
        return success;
    }





    public bool TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    public bool TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    public bool TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    public bool TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten)
    {
        throw new NotImplementedException();
    }

    public static bool IsCanonical(UFloat value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UFloat>.TryConvertFromChecked<TOther>(TOther value, out UFloat result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UFloat>.TryConvertFromSaturating<TOther>(TOther value, out UFloat result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UFloat>.TryConvertFromTruncating<TOther>(TOther value, out UFloat result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<UFloat>.TryConvertToChecked<TOther>(UFloat value, out TOther result)
    {
        throw new NotImplementedException();
    }
    static bool INumberBase<UFloat>.TryConvertToSaturating<TOther>(UFloat value, out TOther result)
    {
        throw new NotImplementedException();
    }
    static bool INumberBase<UFloat>.TryConvertToTruncating<TOther>(UFloat value, out TOther result)
    {
        throw new NotImplementedException();
    }
}