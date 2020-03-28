using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace DinoR
{
    public class DinoHub : Hub
    {
        private readonly IGame _game;
        private readonly ILogger _logger;

        public DinoHub(IGame game, ILogger<DinoHub> logger)
        {
            _game = game;
            _logger = logger;
        }

        public string GetMyId()
        {
            return Context.ConnectionId;
        }

        public void KeyDown(int keyCode)
        {
            _game.KeyDown(Context.ConnectionId, keyCode);
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation($"New connection! Id = {Context.ConnectionId}");
            _game.AddNewPlayer(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _logger.LogInformation($"Disconnected! Id = {Context.ConnectionId}");
            // _logger.LogError($"Exception: {exception.Message}");
            _game.RemovePlayer(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}