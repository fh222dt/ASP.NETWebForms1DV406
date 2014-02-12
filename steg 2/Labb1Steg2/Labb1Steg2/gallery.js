

function init() {
    $(".thumbs").click(function () {
        $(this).addClass("marked");
    });
}

function fadeOut() {

    $(".success").fadeOut(5000, function () {
    });
}


window.onload = init;