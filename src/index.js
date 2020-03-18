function Dino(name, offsetX, offsetY) {
    this.offsetX = offsetX;
    this.offsetY = offsetY;
    this.name = name;
    this.uiCreate();

    var that = this;
    this.keyDown = function (event) {
        if (event.keyCode == 39) {
            that.offsetX += 24;
        }
        else if (event.keyCode == 37) {
            that.offsetX -= 24;
        }
        else if (event.keyCode == 40) {
            that.offsetY += 24;
        }
        else if (event.keyCode == 38) {
            that.offsetY -= 24;
        }

        that.ui
            .tween(200)
            .offset(that.offsetX, that.offsetY)
            .ease('quad-out');
    };
}

Dino.prototype.uiCreate = function () {
    this.ui = Stage
        .anim('dino:idle', fps = 10)
        .pin({
            align: 0.5,
            handle: 0.5,
            offsetX: this.offsetX,
            offsetY: this.offsetY
        })
        .play();
};

Stage(function (stage) {
    stage.background('#DDDDDD');
    stage.viewbox(500, 500);

    var myDino = new Dino('Blekkulf', 0, 0);
    myDino.ui.appendTo(stage);

    var myDino2 = new Dino('Blekkulf', 24 * 5, 0);
    myDino2.ui.appendTo(stage);

    var dino1IsActive = true;

    document.addEventListener('keydown', function (event) {
        console.log(event.keyCode);
        if (event.keyCode == 32) {
            dino1IsActive = !dino1IsActive;
        }
        if (dino1IsActive) myDino.keyDown(event);
        else myDino2.keyDown(event);
    }, false);
});