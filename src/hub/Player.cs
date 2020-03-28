using System;

namespace DinoR
{
    public class Player
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private static readonly string[] _dinoTypes = new[] {
            "vita",
            "mort",
            "doux",
            "tard"
        };

        public void Move(Direction direction)
        {
            switch (direction)
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
        }

        public static string GetRandomType()
        {
            var random = new Random();
            var index = random.Next(0, _dinoTypes.Length);
            return _dinoTypes[index];
        }
    }
}