(function () {
    // Add resize listener.
    window.addEventListener('resize', atChange);
})();

// Reading event, Get new data.
function timerEvent() {
    $.ajax({
        url: '/api/FlightDatas?from=' + this.idTrack + '&to=1000',
        type: "GET",
        dataType: 'json',
        success: function (data) {

            // Check if alert needed for empty respond.
            if (jQuery.isEmptyObject(data) && alertFinishedReading == "True") {
                clearInterval(refreshInterval);
                alert("Finished");
            }
            $.each(data, function (i, value) {
                mapUpdate(value.Id, convertXY(value.Lon, value.Lat));
            });
        },
        error: function (xhr) {
            clearInterval(refreshInterval);
            console.log("Got error");
        }
    });
}

// Convert lon , lat to x,y for mapping.
function convertXY(lon, lat) {
    var x = ((document.getElementById("myCanvas").width / 360.0) * (180 + (lon % 360)));
    var y = ((document.getElementById("myCanvas").height / 180.0) * (90 - (lat % 180)));
    return [x, y];
}

// Update map.
function mapUpdate(id, data) {

    var ctx = document.getElementById("myCanvas").getContext("2d");
    var ctx2 = document.getElementById("myCanvas2").getContext("2d");

    // Draw line, clear the airplane canvas, draw line.
    if (id > 1) {

        ctx2.clearRect(this.currentPlace[0] - (this.imageSize / 2),
            this.currentPlace[1] - (this.imageSize / 2), this.imageSize, this.imageSize);
        ctx.lineTo(data[0], data[1]);
        ctx.lineWidth = (this.window.innerWidth / 500);
        ctx.lineJoin = "round"
        ctx.strokeStyle = '#FF0000';
        ctx.stroke();
    }

    // Update canvas, current place, and draw airplane over again.
    ctx.moveTo(data[0], data[1]);
    this.currentPlace = data;
    ctx2.drawImage(document.getElementById("airplaneImage"), data[0] - (this.imageSize / 2),
        data[1] - (this.imageSize / 2), this.imageSize, this.imageSize);
    this.idTrack = id; // Set new id.
}

// If scroll\size change occure.
function atChange() {
    canvas1 = document.getElementById("myCanvas");
    canvas2 = document.getElementById("myCanvas2");

    ctx = canvas1.getContext("2d");
    ctx2 = canvas2.getContext("2d");
    this.imageSize = (this.window.innerWidth / 100) + 20;

    // Get all points over again and draw from the start.
    $.ajax({
        url: '/api/FlightDatas?from=0&to=1000',
        type: "GET",
        dataType: 'json',
        success: function (data) {
            ctx.clearRect(0, 0, canvas1.width, canvas1.height);
            ctx2.clearRect(0, 0, canvas2.width, canvas2.height);
            ctx.beginPath();
            firstElement = $(data).first();
            restore = convertXY(firstElement[0], firstElement[1]);
            ctx.moveTo(restore[0], restore[1]);
            $.each(data, function (i, value) {
                mapUpdate(value.Id, convertXY(value.Lon, value.Lat));
            });
        },
        error: function () {
            clearInterval(refreshInterval);
            console.log("Got error");
        }
    });
}