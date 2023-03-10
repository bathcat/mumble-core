using System;

namespace Acme.Core
{
    public class SnakeInfo
    {
        public Guid ID { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = String.Empty;
        public string Color { get; init; } = String.Empty;
        public int MeannessLevel { get; init; }

        //TODO: Replace this with a state pattern.
        public string PayGrade { get; init; } = String.Empty;
    }

    public class Snake
    {
        public Guid ID { get; init; } = Guid.NewGuid();
        public string Name { get; init; } = String.Empty;
        public string Color { get; init; } = String.Empty;
        public int MeannessLevel { get; init; }
    }
}

namespace Acme.Core.Extensions
{
    public static class SnakeExtensions
    {
        public static SnakeInfo ToSnakeInfo(this Snake snake, string paygrade) =>
            new SnakeInfo
            {
                ID = snake.ID,
                Name = snake.Name,
                Color = snake.Color,
                MeannessLevel = snake.MeannessLevel,
                PayGrade = paygrade,
            };
    }
}
