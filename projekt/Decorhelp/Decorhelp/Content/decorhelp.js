function hide() {
    $(".close-me").click(function () {
        $(".success").hide();
    });
}


window.onload = hide;