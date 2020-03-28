using System.Collections.Concurrent;
using Newtonsoft.Json;

namespace DinoR
{
    public class PlayerList
    {
        private ConcurrentDictionary<string, Player> Players { get; set; }

        public PlayerList()
        {
            Players = new ConcurrentDictionary<string, Player>();
        }

        public void AddNewPlayer(string id)
        {
            Players.TryAdd(id, new Player
            {
                Id = id,
                Type = Player.GetRandomType()
            });
        }

        public Player GetPlayer(string id)
        {
            Players.TryGetValue(id, out Player player);
            return player;
        }

        public void RemovePlayer(string id)
        {
            Players.TryRemove(id, out Player player);
        }

        public void SetPlayerDirection(string id, Direction direction)
        {
            if (Players.TryGetValue(id, out var player))
            {
                player.Direction = direction;
            }
        }

        public void MoveAll()
        {
            foreach (var player in Players.Values)
            {
                player.Move();
            }
        }

        public string GetPlayersJson()
        {
            return JsonConvert.SerializeObject(Players.Values);
        }
    }
}