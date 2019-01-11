$(document).ready(function () {
    $("#contentdiv").hide();
    $("#contentdiv").load("logs/logfile.log", function (response) {

        $("#contentdiv").html(response.split("\n").slice(-5).join("\n"));
        $("#contentdiv").show();

    });
})