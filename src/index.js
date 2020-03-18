Stage(function (stage) {
    stage.viewbox(500, 500);

    var dino = Stage
        .image('dino:stand')
        .appendTo(stage)
        .pin({
            align: 0.5,
            handle: 0.5,
            offsetX: 0,
            offsetY: 0
        });

    var dino2 = Stage
        .anim('dino:idle', fps = 10)
        .appendTo(stage)
        .pin({
            align: 0.5,
            handle: 0.5,
            offsetX: 48
        })
        .play();

    dino2offsetX = 48;
    dino2.on('click', function () {
        console.log('dino2 clicked');
        dino2offsetX += 24;
        this.tween(200)
            .pin({
                offsetX: dino2offsetX
            })
            .ease('quad-out');
    });
});

Stage({
    name: 'dino', // optional
    image: {
        src: './assets/DinoSprites - vita.png'
    },
    textures: {
        stand: { x: 0, y: 0, width: 24, height: 24 },
        idle: [
            { x: 0, y: 0, width: 24, height: 24 },
            { x: 24, y: 0, width: 24, height: 24 },
            { x: 48, y: 0, width: 24, height: 24 },
            { x: 72, y: 0, width: 24, height: 24 }
        ],
    }
});