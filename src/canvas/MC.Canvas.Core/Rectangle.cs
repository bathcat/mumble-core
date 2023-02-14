namespace MC.Canvas.Core;

using System;

public readonly record struct Rectangle
{
    public Point2D Origin { get; init; }
    public float Width { get; init; }
    public float Height { get; init; }
    public float Rotation { get; init; }

    Rectangle(Point2D origin, float width, float height, float rotation)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height));
        }

        this.Origin = origin;
        this.Width = width;
        this.Height = height;
        this.Rotation = rotation % 360;
    }

    public Rectangle Resize(Rectangle original, float factor) =>
        original with
        {
            Width = original.Width * factor,
            Height = original.Height * factor,
        };

};