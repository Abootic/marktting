import { routting } from "./routting.js";
$(function () {
    $("#toggler").click(function () {
      
        
            $(".list-container").toggleClass("list-toggler");
 });
});

$(document).ready(function () {
    $(document).on("click",".route", function (e) {
        e.stopImmediatePropagation();
        let value = $(this).attr("value");
        console.log("value is " + value);
        routting(value, false);
    });

});
$(document).ready(function () {
    $("#rotee").on("click", function () {

        let value = $(this).attr("value");
        console.log("value is " + value);
        routting(value, false);
    });

});
//// note
$(document).on("click", "#note", function () {
    //  $(this).attr("value");
    $("#p-note").show();

    $("#note-letter").val($(this).attr("value"));
    $("#note-title").html(" الملاحظة ");
});
$(document).on("click", "#resone", function () {
    //  $(this).attr("value");

    $("#p-note").show();

    $("#note-letter").val($(this).attr("value"));
    $("#note-title").html("السبب من الزيارة");
});
       ////////////