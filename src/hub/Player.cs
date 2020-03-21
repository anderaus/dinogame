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

        private static string[] _dinoTypes = new[] {
            "vita",
            "mort",
            "doux",
            "tard"
        };

        public void Move(Direction direction)
        {
            if (direction == Direction.Up) Y--;
            else if (direction == Direction.Right) X++;
            else if (direction == Direction.Down) Y++;
            else if (direction == Direction.Left) X--;
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