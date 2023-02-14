namespace MC.Canvas.Core;
public readonly record struct Point2D(float X, float Y)
{

    public static Point2D Translate(Point2D original, float horizontal, float vertical) =>
        original with
        {
            X = original.X + horizontal,
            Y = original.Y + vertical,
        };
};