using System.Collections.Concurrent;

namespace DinoR
{
    public class Game : IGame
    {
        public PlayerList _playerList;
        public ConcurrentDictionary<string, Direction> _nextMoves;

        public Game()
        {
            _playerList = new PlayerList();
            _nextMoves = new ConcurrentDictionary<string, Direction>();
        }

        public bool IsGameInProgress()
        {
            return true;
        }

        public void Tick()
        {
            // Update each players direction
            foreach (var move in _nextMoves)
            {
                _playerList.SetPlayerDirection(move.Key, move.Value);
            }
            _nextMoves.Clear();

            // Perform player moves
            _playerList.MoveAll();
        }

        public string GetStateJson()
        {
            return _playerList.GetPlayersJson();
        }

        public void AddNewPlayer(string id)
        {
            _playerList.AddNewPlayer(id);
        }

        public void RemovePlayer(string id)
        {
            _playerList.RemovePlayer(id);
        }

        public void KeyDown(string id, int keyCode)
        {
            var direction = Direction.None;
            if (keyCode == 39)
            {
                direction = Direction.Right;
            }
            else if (keyCode == 37)
            {
                direction = Direction.Left;
            }
            else if (keyCode == 40)
            {
                direction = Direction.Down;
            }
            else if (keyCode == 38)
            {
                direction = Direction.Up;
            }

            var player = _playerList.GetPlayer(id);
            if (player != null)
            {
                if (_nextMoves.ContainsKey(id))
                {
                    _nextMoves[id] = direction;
                }
                else
                {
                    _nextMoves.TryAdd(id, direction);
                }
            }
        }
    }

    public interface IGame
    {
        bool IsGameInProgress();
        void Tick();
        string GetStateJson();
        void AddNewPlayer(string id);
        void RemovePlayer(string id);
        void KeyDown(string id, int keyCode);
    }
}