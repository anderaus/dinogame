function Dino(name, offsetX, offsetY) {
    this.offsetX = offsetX;
    this.offsetY = offsetY;
    this.name = name;
    this.uiCreate(name);

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

Dino.prototype.uiCreate = function (name) {
    this.ui = Stage
        .anim('dino-' + name + ':idle', fps = 10)
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

    var dinos = [];
    var activeDino = 0;

    dinos.push(new Dino('vita', -24 * 5, -24 * 5));
    dinos.push(new Dino('mort', 24 * 5, -24 * 5));
    dinos.push(new Dino('doux', 24 * 5, 24 * 5));
    dinos.push(new Dino('tard', -24 * 5, 24 * 5));

    dinos.forEach(d => d.ui.appendTo(stage));

    document.addEventListener('keydown', function (event) {
        if (event.keyCode == 32) {
            activeDino++;
            if (activeDino >= dinos.length) activeDino = 0;
        }
        dinos[activeDino].keyDown(event);
    }, false);
});