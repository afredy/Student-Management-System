function ShowLoader() {
    //document.getElementById("").style.display = "block";
    if ($("#overlay").is(":hidden")){
        $("#overlay").fadeIn(10);
    }
}

function HideLoader() {
    //document.getElementById("loader_overlay").style.display = "none";
    if (!$("#overlay").is(":hidden")) {
        $("#overlay").fadeOut(1000);
    }
}