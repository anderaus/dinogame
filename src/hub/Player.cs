using System;
using System.Collections.Generic;

namespace DinoR
{
    public class Player
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; } = Direction.None;

        private static string[] _dinoTypes = new[] {
            "vita",
            "mort",
            "doux",
            "tard"
        };

        public void Move()
        {
            if (Direction == Direction.Up) Y--;
            else if (Direction == Direction.Right) X++;
            else if (Direction == Direction.Down) Y++;
            else if (Direction == Direction.Left) X--;

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
            var index = random.Next(0, _dinoTypes.Length);
            return _dinoTypes[index];
        }
    }

    public enum DinoType
    {
        Vita,
        Mort,
        Doux,
        Tard
    }
}