using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace DinoR
{
    public class DinoHub : Hub
    {
        private readonly IGameEngine _engine;
        private readonly ILogger _logger;

        public DinoHub(IGameEngine engine, ILogger<DinoHub> logger)
        {
            _engine = engine;
            _logger = logger;
        }

        public string GetMyId()
        {
            return Context.ConnectionId;
        }

        public async Task KeyDown(string id, int keyCode)
        {
            var direction = Direction.None;
            switch (keyCode)
            {
                case 39:
                    direction = Direction.Right;
                    break;
                case 37:
                    direction = Direction.Left;
                    break;
                case 40:
                    direction = Direction.Down;
                    break;
                case 38:
                    direction = Direction.Up;
                    break;
            }

            var player = _engine.GetPlayer(id);
            if (player != null)
            {
                player.Move(direction);
                await UpdateClients();
            }
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"New connection! Id = {Context.ConnectionId}");
            _engine.AddPlayer(new Player
            {
                Id = Context.ConnectionId,
                Type = Player.GetRandomType()
            });
            await UpdateClients();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Disconnected! Id = {Context.ConnectionId}");
            // _logger.LogError($"Exception: {exception.Message}");

            _engine.RemovePlayer(Context.ConnectionId);
            await UpdateClients();
            await base.OnDisconnectedAsync(exception);
        }

        private async Task UpdateClients()
        {
            var state = JsonConvert.SerializeObject(_engine.GetPlayers());
            await Clients.All.SendAsync("StateUpdate", state);
        }
    }
}