

// Init the canvas, width & height fit screen 

(function () {
    var dimension = [4 * window.outerWidth, 4 * window.outerHeight];
    setCanvasScreen("myCanvas", dimension);
    setCanvasScreen("myCanvas2", dimension);

    function setCanvasScreen(name, dimension) {
        cx = document.getElementById(name);
        cx.width = dimension[0];
        cx.height = dimension[1];
        cx.minWidth = dimension[0];
        cx.minHeight = dimension[1];
    }
})();

