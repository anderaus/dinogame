function Game(ui, connection) {
    var myDinoId = -1;
    var dinos = [];

    this.start = function (id) {
        myDinoId = id;
    };

    document.addEventListener('keydown', function (event) {
        var myDino = dinos.find(d => d.id === myDinoId);
        // Update locally for immediate effect
        myDino.keyDown(event.keyCode);
        // ...as well as serverside to alert other clients
        connection.invoke('keyDown', myDino.id, event.keyCode);
    }, false);

    connection.on("StateUpdate", function (players) {
        var playersObj = JSON.parse(players);
        console.log("Received state list: ", playersObj);

        playersObj.forEach(po => {
            var matchingDino = dinos.find(d => d.id === po.Id);
            if (matchingDino) {
                // Existing dino found, update position
                matchingDino.x = po.X;
                matchingDino.y = po.Y;
                matchingDino.ui.update();
            }
            else {
                // New dino found in server state, add to client too
                var newDino = new Dino(ui, po.Id, po.Type, po.X, po.Y);
                newDino.ui.add();
                dinos.push(newDino);
            }
        });

        // Remove all dead dinos from client
        dinos.forEach(d => {
            if (!playersObj.some(po => po.Id == d.id)) {
                d.ui.remove();
            }
        });
    });
}