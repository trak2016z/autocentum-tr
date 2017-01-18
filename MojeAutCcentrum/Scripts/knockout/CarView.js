$(window).ready(function () {
    var AddDescription = {
        BrandId: $("#Brand_Id").val(),
        ModelId: $("#Model_Id").val(),
        GenerationId: $("#Generation_Id").val(),
        BodyId: $("#Body_Id").val(),
        MotorId: $("#Motor_Id").val(),
    };

    $("#add-description").click(function () {
        var descripton = $("#new-description").val();
        AddDescription.Descripton = descripton;
        $.ajax({
            type: "POST",
            url: "/Home/AddDescription",
            data: JSON.stringify(AddDescription),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            processData: false,
        }).done(function (email) {
            AddElement(descripton, email)
        });
    });

    function AddElement(descripton, email)
    {
        $.ajax({
            type: "POST",
            url: "/Home/LoadAvatar",
            data: JSON.stringify({ email: email }),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            processData: false,
        }).done(function (image) {
            if (image == "null") image = $("#neutral-avatar").attr("src");
            var html = '<div class="jumbotron">';
            html += '<div class="row">';
            html += '<div class="col-md-4">';
            html += '<img src="' + image + '" class="img-circle" height="200" width="200" />';
            html += '</div>';
            html += '<div class="col-md-8">';
            html += '<h4>' + email + '</h4>';
            html += '<hr>';
            html += '<p>' + descripton + '</p>';
            html += '</div>';
            html += '</div>';
            html += '</div>';
            $("#description-box-list").append(html);
        });
    }
});