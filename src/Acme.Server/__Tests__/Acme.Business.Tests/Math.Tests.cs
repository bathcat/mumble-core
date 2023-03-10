using NUnit.Framework;

namespace Acme.Business.Tests;

public class Math_Tests
{
    [Test]
    public void IsPrime_2_Should_Be_True()
    {
        const bool expected = true;
        var actual = Math.IsPrime(2);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void IsPrime_3_Should_Be_True()
    {
        const bool expected = true;
        var actual = Math.IsPrime(3);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void IsPrime_4_Should_Be_False()
    {
        const bool expected = false;
        var actual = Math.IsPrime(4);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
