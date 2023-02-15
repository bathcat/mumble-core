namespace MC.Canvas.Core;
public readonly record struct Rectangle(Point2D Origin, USingle Width, USingle Height, float Rotation)
{
    public Rectangle Resize(float factor) =>
        this with
        {
            Width = this.Width * factor,
            Height = this.Height * factor,
        };
};