$(window).ready(function () {

    var NameList = {
        Brand: "Model",
        Model: "Generation",
        Generation: "Body",
        Body: "Motor"
    };

    $.each(NameList, function (key, Name) {
            var select = $("#" + NameList[key] + "Id");
            ResetSelect(select);
    });


    $("#Conveniences_Value").attr("hidden", ""); 
    $("#Failure_Value").attr("hidden", "");
    $("#Maintenance_Value").attr("hidden", "");

    $(".starRating span").click(function () {
        var val = Number($(this).attr("value"));
        var element = $(this).parent().parent().children().first().find("option:selected").removeAttr("selected");
        var index = 1;
        element = element.parent().children();
        $.each(element, function (id, option) {
            if(index == val)
            {
                $(option).attr("selected", "selected");
            }
            index++;
        });
        index = 1;
        var spans = $(this).parent().children();
        $.each(spans, function (id,span) {
            if (index <= val) $(span).attr("class", "hoverChosen");
            else $(span).removeAttr("class");
            index++;
        });
    });

    $("select.select-to-change").on('change', function() {
        var Id = Number($(this).find("option:selected").val());
        var NameModel = $(this).attr('id').slice(0, -2);
        if(Id != 0)
        {
            $.ajax({
                type: "GET",
                url: "/Home/Collection/?NameModel=" + NameModel + "&Id=" + Id,
                data: JSON.stringify({ NameModel: NameModel, Id: Id }),
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                processData: false,
                contentType: false,
                cache: false
            }).done(function (result) {
                var select = $("#" + NameList[NameModel] + "Id");
                ResetSelect(select);
                AddOptions(select, result, NameModel);
            });
        } else {
            var isSelected = false;
            $.each(NameList, function (key, Name) {
                if (isSelected || key == NameModel) {
                    isSelected = true;
                    var select = $("#" + NameList[key] + "Id");
                    ResetSelect(select);
                    $("#" + NameList[key] + "Id").attr("disabled", "");
                }
            });
        }
    });

    function AddOptions(element,items,name)
    {
        if (Object.keys(items).length == 0) {
            var isSelected = false;
            $.each(NameList, function (key, Name) {
                if (isSelected || Name == NameList[name]) {
                    isSelected = true;
                    $("#" + Name + "Id").removeAttr("disabled");
                }
            });
        } else {
            var isSelected = false;
            $.each(NameList, function (key, Name) {
                if (isSelected || Name == NameList[name]) {
                    isSelected = true;
                    if (Name == NameList[name]) {
                        $.each(items, function (key, item) {
                            $(element).append('<option value="' + item.Id + '">' + item.Name + '</option>');
                        });
                        $(element).removeAttr("disabled");
                    } else {
                        $("#" + NameList[Name] + "Id").attr("disabled", "");
                    }
                }
            });
        }
    }

    function ResetSelect(element)
    {
        var test = $(element).children().first().text();
        $(element).children().remove();
        $(element).append('<option value="-1">' + test + '</option>');
    }
});