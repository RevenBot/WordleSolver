function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}
function applyUnFlip() {
    var tiles = document.getElementsByClassName("inner");
    var tilesArray = Array.from(tiles);
    tilesArray.map(function (tile, i) {
        tile.classList.remove("flip")
        tile.classList.add("unflip")
        tile.style.setProperty('--loading-fill-from', "")
        tile.style.animationDelay = `${i * 100}ms`;
    });
    setTimeout(applyFlip, 4000);
}
function applyFlip() {
    var tiles = document.getElementsByClassName("inner");
    var tilesArray = Array.from(tiles);
    tilesArray.map(function (tile, i) {
        tile.classList.remove("unflip")
        var i = getRandomInt(4);
        if (i == 1) {
            tile.classList.add("flip")
            tile.style.setProperty('--loading-fill-from', "green")
        }
        else if (i == 2) {
            tile.classList.add("flip")
            tile.style.setProperty('--loading-fill-from', "yellow")
        } else {
            tile.classList.add("flip")
            tile.style.setProperty('--loading-fill-from', "grey")
        }
        tile.style.animationDelay = `${i * 100}ms`;
    });
    setTimeout(applyUnFlip, 4000);
}
window.AnimationJSFunctions = {
    start: () => {
        applyFlip();
    },
};
