Stage({
    name: 'dino',
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