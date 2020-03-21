function Dino(ui, id, type, x, y) {
    this.type = type;
    this.id = id;
    this.x = x;
    this.y = y;
    this.ui = ui.buildDino(this);
}

Dino.prototype.keyDown = function (keyCode) {
    if (keyCode == 39) {
        this.x += 1;
        this.ui.update();
    }
    else if (keyCode == 37) {
        this.x -= 1;
        this.ui.update();
    }
    else if (keyCode == 40) {
        this.y += 1;
        this.ui.update();
    }
    else if (keyCode == 38) {
        this.y -= 1;
        this.ui.update();
    }
    else if (keyCode == 8) {
        this.ui.remove();
    }
};