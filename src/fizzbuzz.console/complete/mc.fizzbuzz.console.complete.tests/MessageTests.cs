
namespace MumbleCore.FizzBuzz.Console.Complete.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass()]
public class MessageTests
{
    [TestMethod()]
    public void FromIndexShouldReturnFizzFor33()
    {
        var actual = Message.FromIndex(33);
        Assert.AreEqual("Fizz", actual);
    }

    [TestMethod()]
    public void FromIndexShouldReturnBuzzFor35()
    {
        var actual = Message.FromIndex(35);
        Assert.AreEqual("Buzz", actual);
    }

    [TestMethod()]
    public void FromIndexShouldReturn44For44()
    {
        var actual = Message.FromIndex(44);
        Assert.AreEqual("44", actual);
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void FromIndexShouldThrowOnZero()
    {
        Message.FromIndex(0);
    }

    [TestMethod()]
    [ExpectedException(typeof(ArgumentException))]
    public void FromIndexShouldThrowOn101()
    {
        Message.FromIndex(101);
    }

}
