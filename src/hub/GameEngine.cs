using System.Collections.Generic;
using System.Linq;

namespace DinoR
{
    public class GameEngine : IGameEngine
    {
        private List<Player> Players { get; set; }

        public GameEngine()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public Player GetPlayer(string id)
        {
            return Players.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePlayer(string id)
        {
            var player = Players.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                Players.Remove(player);
            }
        }

        public List<Player> GetPlayers()
        {
            return Players;
        }
    }

    public interface IGameEngine
    {
        void AddPlayer(Player player);
        void RemovePlayer(string id);
        Player GetPlayer(string id);
        List<Player> GetPlayers();
    }
}