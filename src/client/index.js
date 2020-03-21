var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/dinoHub")
    .configureLogging(signalR.LogLevel.Debug)
    .build();

Stage(function (stage) {
    stage.background('#DDDDDD');
    stage.viewbox(500, 500);

    var game = new Game({
        buildDino: function (dino) {
            var img = Stage
                .anim('dino-' + dino.type + ':idle', fps = 10)
                .pin({
                    align: 0.5,
                    handle: 0.5,
                    offsetX: dino.x * 24,
                    offsetY: dino.y * 24
                })
                .play();

            return {
                add: function () {
                    img.appendTo(stage);
                },
                update: function () {
                    img.tween(200)
                        .ease('quad-out')
                        .offset(dino.x * 24, dino.y * 24);
                },
                remove: function () {
                    img.tween(250).alpha(0).remove();
                }
            };
        }
    }, connection);

    // Hook up to hub, fetch id and run!
    connection.start().then(function () {
        console.log("connection started", connection);
        connection.invoke("GetMyId").then(function (id) {
            console.log("my id seems to be: " + id);
            game.start(id);
        }).catch(function (err) {
            return console.error(err.toString());
        });
    });
});