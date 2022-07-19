$(".map-action").click(function () {
    if ($("#ContactSection").is(":visible")) {
        $("#ContactSection").animate({
            width: "hide"
        });
        $(".div-arrow").animate({
            width: "show"
        });

    } else {
        $("#ContactSection").animate({
            width: "show"
        });
    }
});
$(".div-arrow").click(function () {
    $(".div-arrow").hide();
    $("#ContactSection").animate({
        width: "show"
    });
});