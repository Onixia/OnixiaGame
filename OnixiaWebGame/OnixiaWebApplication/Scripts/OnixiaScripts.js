function BuildShips(shipname, count) {
    var shipName = shipname;
    var orderCount = count;
    var actionName = "/Ships/Create";
    console.log("action name : " + actionName);
    console.log("Count" + orderCount);
    console.log("Ship:", shipName);
    $.ajax({
        type: "POST",
        url: actionName,
        data: {
            name: shipName,
            count: orderCount
        },
        dataType: "JSON"
    }).done(function (message) {
        alert("done!");
        console.log(message);
    });
}


$(document).ready(function () {
    //alert("kek");
    //console.log("Document ready");
    $('.ship-form').submit(function(event) {
        event.preventDefault();

        var ship = $(this).find("#shipName").val();
        var count = $(this).find('#shipsQuantity').val();
        BuildShips(ship, count);
    });
});