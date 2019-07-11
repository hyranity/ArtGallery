﻿/*$(document).ready(function () {
    
});*/

$(document).ready(function () {

    $(".decrement").click(function () {
        var btnId = $(this).attr('id').replace("btnDecrement", "");
        var quantity = $("#quantity" + btnId).text().replace(" PCS", "");

        //$(this).attr('value', btnId);

        if (parseInt(quantity) > parseInt(0)) {
            $("#quantity" + btnId).text((parseInt(quantity) - parseInt(1)) + " PCS");
        }
    });

    $(".increment").click(function () {
        var btnId = $(this).attr('id').replace("btnIncrement", "");
        var quantity = $("#quantity" + btnId).text().replace(" PCS", "");

        $("#quantity" + btnId).text((parseInt(quantity) + parseInt(1)) + " PCS");
    });

});