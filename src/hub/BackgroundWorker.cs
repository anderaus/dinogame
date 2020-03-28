using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DinoR
{
    public class BackgroundWorker : BackgroundService
    {
        private readonly IGame _game;
        private readonly IHubContext<DinoHub> _hubContext;
        private readonly ILogger _logger;

        public BackgroundWorker(IGame game, IHubContext<DinoHub> hubContext, ILogger<BackgroundWorker> logger)
        {
            _game = game;
            _hubContext = hubContext;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var watch = Stopwatch.StartNew();
                _logger.LogDebug("BackgroundWorker iteration");
                if (_game.IsGameInProgress())
                {
                    _game.Tick();

                    await _hubContext.Clients.All.SendAsync("StateUpdate", _game.GetStateJson());
                }

                watch.Stop();
                await Task.Delay(400 - (int)watch.ElapsedMilliseconds);
            }

            _logger.LogError("WHAT TRIGGERED THE CANCELLATION TOKEN?!");
        }
    }
}