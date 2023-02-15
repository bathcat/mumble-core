using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MC.Canvas.Core.Tests;


[TestClass()]
public class RectangleTests
{
    [TestMethod()]
    public void ResizeShouldThrowOnNegativeFactor()
    {
        Rectangle original = new(new Point2D(0, 0), 1, 1, 0);
        var resized = original.Resize((float).10);

        Assert.Fail();
    }
}
