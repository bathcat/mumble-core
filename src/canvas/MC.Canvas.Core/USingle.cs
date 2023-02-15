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
public readonly record struct USingle : IFloatingPoint<USingle>
{
    public readonly Single Value;

    public static USingle E
        => new(Single.E);

    public static USingle Pi
        => new(Single.Pi);

    public static USingle Tau
        => new(Single.Tau);

    public static USingle NegativeOne
        => throw new NotImplementedException();

    public static USingle One
        => new(1);

    public static int Radix => throw new NotImplementedException();

    public static USingle Zero
        => new(0);

    public static USingle AdditiveIdentity
        => new(0);

    public static USingle MultiplicativeIdentity
        => new(1);

    public USingle(float value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("value");
        }
        Value = value;
    }

    public static implicit operator float(USingle uf)
        => uf.Value;

    public static implicit operator USingle(float f)
        => new(f);

    public static bool operator <(USingle a, USingle b)
        => a.Value < b.Value;

    public static bool operator >(USingle a, USingle b)
        => a.Value > b.Value;

    public static bool operator <=(USingle a, USingle b)
        => a.Value <= b.Value;

    public static bool operator >=(USingle a, USingle b)
        => a.Value >= b.Value;

    public static USingle operator %(USingle left, USingle right)
        => new(left.Value % right.Value);

    public static USingle operator +(USingle left, USingle right)
        => new(left.Value + right.Value);

    public static USingle operator --(USingle value)
        => throw new NotImplementedException();

    public static USingle operator /(USingle left, USingle right)
        => new(left.Value / right.Value);

    public static USingle operator ++(USingle value)
        => throw new NotImplementedException();

    public static USingle operator *(USingle left, USingle right)
        => new(left.Value * right.Value);
    public static USingle operator -(USingle left, USingle right)
        => new(left.Value - right.Value);

    public static USingle operator -(USingle value)
        => throw new NotImplementedException();

    public static USingle operator +(USingle value)
        => value;

    public int CompareTo(USingle other)
        => this.Value.CompareTo(other.Value);

    public static USingle Abs(USingle value)
        => value;

    public static bool IsEvenInteger(USingle value)
        => Single.IsEvenInteger(value.Value);

    public static bool IsFinite(USingle value)
        => Single.IsFinite(value.Value);

    public int CompareTo(object? obj) => obj switch
    {
        USingle objAsUSingle => this.Value.CompareTo(objAsUSingle.Value),
        _ => this.Value.CompareTo(obj),
    };

    public static bool IsInfinity(USingle value)
        => Single.IsInfinity(value.Value);

    public static bool IsInteger(USingle value)
        => Single.IsInteger(value.Value);

    public static bool IsNaN(USingle value)
        => Single.IsNaN(value.Value);

    public static bool IsNegative(USingle value)
        => false;

    public static bool IsNegativeInfinity(USingle value)
        => false;

    public static bool IsNormal(USingle value)
        => Single.IsNormal(value.Value);

    public static bool IsOddInteger(USingle value)
        => Single.IsOddInteger(value.Value);
    public static bool IsPositive(USingle value)
        => Single.IsPositive(value.Value);
    public static bool IsPositiveInfinity(USingle value)
        => Single.IsPositiveInfinity(value.Value);
    public static bool IsRealNumber(USingle value)
        => Single.IsRealNumber(value.Value);

    public static bool IsSubnormal(USingle value)
        => Single.IsSubnormal(value.Value);
    public static bool IsZero(USingle value)
        => value.Value == 0;

    public static USingle MaxMagnitude(USingle x, USingle y)
        => new(Single.MaxMagnitude(x.Value, y.Value));

    public static USingle MaxMagnitudeNumber(USingle x, USingle y)
        => new(Single.MaxMagnitudeNumber(x.Value, y.Value));

    public static USingle MinMagnitude(USingle x, USingle y)
        => new(Single.MinMagnitude(x.Value, y.Value));

    public static USingle MinMagnitudeNumber(USingle x, USingle y)
        => new(Single.MinMagnitudeNumber(x.Value, y.Value));

    public static USingle Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        => new(Single.Parse(s, style, provider));

    public static USingle Parse(string s, NumberStyles style, IFormatProvider? provider)
        => new(Single.Parse(s, style, provider));
    public string ToString(string? format, IFormatProvider? formatProvider)
        => this.Value.ToString(format, formatProvider);

    public static USingle Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        => new(Single.Parse(s, provider));

    public static USingle Parse(string s, IFormatProvider? provider)
        => new(Single.Parse(s, provider));

    public static bool IsComplexNumber(USingle value)
    => false;

    public static bool IsImaginaryNumber(USingle value)
        => false;

    public static USingle Round(USingle x, int digits, MidpointRounding mode)
        => new(Single.Round(x.Value, digits, mode));

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out USingle result)
    {
        float value = 0;
        var success = Single.TryParse(s, style, provider, out value);
        result = new(value);
        return success;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out USingle result)
    {
        float value = 0;
        var success = Single.TryParse(s, style, provider, out value);
        result = new(value);
        return success;
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => this.Value.TryFormat(destination, out charsWritten, format, provider);

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out USingle result)
    {
        float value = 0;
        var success = Single.TryParse(s, provider, out value);
        result = new(value);
        return success;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out USingle result)
    {
        float value = 0;
        var success = Single.TryParse(s, provider, out value);
        result = new(value);
        return success;
    }




    public int GetExponentByteCount()
        => throw new NotImplementedException();

    public int GetExponentShortestBitLength()
        => throw new NotImplementedException();

    public int GetSignificandBitLength()
        => throw new NotImplementedException();

    public int GetSignificandByteCount()
        => throw new NotImplementedException();

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

    public static bool IsCanonical(USingle value)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<USingle>.TryConvertFromChecked<TOther>(TOther value, out USingle result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<USingle>.TryConvertFromSaturating<TOther>(TOther value, out USingle result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<USingle>.TryConvertFromTruncating<TOther>(TOther value, out USingle result)
    {
        throw new NotImplementedException();
    }

    static bool INumberBase<USingle>.TryConvertToChecked<TOther>(USingle value, out TOther result)
    {
        throw new NotImplementedException();
    }
    static bool INumberBase<USingle>.TryConvertToSaturating<TOther>(USingle value, out TOther result)
    {
        throw new NotImplementedException();
    }
    static bool INumberBase<USingle>.TryConvertToTruncating<TOther>(USingle value, out TOther result)
    {
        throw new NotImplementedException();
    }
}