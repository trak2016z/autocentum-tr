/// <reference path="knockout-3.4.0.debug.js" />
$(document).ready(function () {
    $("#file").on('change', function postinput() {
        var form = $('#Form')[0];
        $.ajax({
            type: "POST",
            url: "/Manage/ConvertImage",
            data: new FormData(form),
            processData: false,
            contentType: false,
            cache: false
        }).done(function (data) {
            $('#NewImage').attr('src', "data:image/jpeg;base64," + data);
        });

    });
});







