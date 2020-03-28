using System;

namespace DinoR
{
    public class Player
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; } = Direction.None;

        private static readonly string[] DinoTypes = new[]
        {
            "vita",
            "mort",
            "doux",
            "tard"
        };

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Right:
                    X++;
                    break;
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Left:
                    X--;
                    break;
            }

            if (X < -10)
            {
                X = -10;
                Direction = Direction.None;
            }

            if (X > 10)
            {
                X = 10;
                Direction = Direction.None;
            }

            if (Y > 10)
            {
                Y = 10;
                Direction = Direction.None;
            }

            if (Y < -10)
            {
                Y = -10;
                Direction = Direction.None;
            }
        }

        public static string GetRandomType()
        {
            var random = new Random();
            var index = random.Next(0, DinoTypes.Length);
            return DinoTypes[index];
        }
    }
}