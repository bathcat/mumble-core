namespace MC.Canvas.Core;
public readonly record struct Rectangle(Point2D Origin, float Width, float Height, float Rotation)
{
    //public required Point2D Origin { get; init; }
    //public required float Width { get; init; }
    //public required float Height { get; init; }
    //public required float Rotation { get; init; }


    //public Rectangle(Point2D origin, float width, float height, float rotation)
    //{
    //    if (width <= 0)
    //    {
    //        throw new ArgumentOutOfRangeException(nameof(width));
    //    }

    //    if (height <= 0)
    //    {
    //        throw new ArgumentOutOfRangeException(nameof(height));
    //    }

    //    this.Origin = origin;
    //    this.Width = width;
    //    this.Height = height;
    //    this.Rotation = rotation % 360;
    //}

    public Rectangle Resize(float factor) =>
        this with
        {
            Width = this.Width * factor,
            Height = this.Height * factor,
        };

};