$("#MainCategorySelect").change(function () {
    if ($("#MainCategorySelect option:selected").val() == 0) { } else {
        $("#Category").val($("#MainCategorySelect option:selected").val());
    }
});

$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});

$("#BtnAddSpider").click(function () {
    if ($("#Category").val() == null || $("#Category").val() == "" || $("#Title").val() == null || $("#Title").val() == "" || $("#Image").val() == null || $("#Image").val() == "" || $("#my-textarea").val() == null || $("#my-textarea").val() == "") {
        $("#BtnAddSpider").removeClass('btn-success');
        $("#BtnAddSpider").addClass('btn-danger');
        $("#BtnAddSpider").html("همه موارد اجباری میباشد");
    } else {

        var Title = $("#Title").val();
        var Description = $("#my-textarea").val();

        if (Title.includes("'") || Title.length > 30) {
            $("#BtnAddSpider").html("عنوان معتبر وارد کنید");
            $("#BtnAddSpider").removeClass("btn-success");
            $("#BtnAddSpider").addClass("btn-danger");
        } else {
            $("#BtnAddSpider").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#BtnAddSpider").addClass("btn-success");
            $("#BtnAddSpider").removeClass("btn-danger");

            if (Description.includes("&#39;") || Description.length > 5000) {
                $("#BtnAddSpider").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 5000 میباشد");
                $("#BtnAddSpider").removeClass("btn-success");
                $("#BtnAddSpider").addClass("btn-danger");
            }
            else {

                var data = new FormData();
                var files = $("#Image").get(0).files;

                if (files[0].size > 3000000) {

                    $("#BtnAddSpider").html("فایل بیش از اندازه بزرگ است");
                    $("#BtnAddSpider").removeClass("btn-success");
                    $("#BtnAddSpider").addClass("btn-danger");

                } else {

                    if (files.length > 0) {
                        data.append("UploadSpiderImage", files[0]);
                    }

                    $.ajax({
                        url: "/Admin/Upload/UploadSpiderImage",
                        type: "POST",
                        processData: false,
                        contentType: false,
                        data: data,
                        success: function (response) {

                            if (response == "0") {
                                $("#BtnAddSpider").html("فایل معتبر نیست");
                                $("#BtnAddSpider").removeClass("btn-success");
                                $("#BtnAddSpider").addClass("btn-danger");
                            } else {
                                $("#BtnAddSpider").html("<i class='fas fa-plus-circle'></i>افزودن");
                                $("#BtnAddSpider").addClass("btn-success");
                                $("#BtnAddSpider").removeClass("btn-danger");

                                var tags = [];

                                //Data

                                for (var i = 0; i < $(".tag").length; i++) {
                                    tags.push($(".tag")[i].innerText);
                                }
                                var Category = $("#Category").val();

                                var Image = response;
                                $(".loding").removeClass('d-none');
                                $.ajax({
                                    type: "POST",
                                    url: '/Admin/Management/SpiderCreate',
                                    data: { Category: Category, Title: Title, Description: Description, Image: Image, SeoTages: tags },
                                    success: function (result) {
                                        if (result == "true") {
                                            window.location.reload();
                                        } else {
                                            alert(result);
                                        }
                                    },
                                    dataType: "json",
                                    traditional: true
                                });


                            }

                        }
                    });

                }
            }
        }

    }
});

function EditSpiderUp(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#my-textarea").val() == null || $("#my-textarea").val() == "") {
        $("#BtnEditSpider").removeClass('btn-success');
        $("#BtnEditSpider").addClass('btn-danger');
        $("#BtnEditSpider").html("همه موارد اجباری میباشد");
    } else {

        var Title = $("#Title").val();
        var Description = $("#my-textarea").val();

        if (Title.includes("'") || Title.length > 30) {
            $("#BtnEditSpider").html("عنوان معتبر وارد کنید");
            $("#BtnEditSpider").removeClass("btn-success");
            $("#BtnEditSpider").addClass("btn-danger");
        } else {
            $("#BtnEditSpider").addClass('btn-success');
            $("#BtnEditSpider").removeClass('btn-danger');
            $("#BtnEditSpider").html("<i class='fas fa-edit'></i>ویرایش");

            if (Description.includes("&#39;") || Description.length > 5000) {
                $("#BtnEditSpider").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 5000 میباشد");
                $("#BtnEditSpider").removeClass("btn-success");
                $("#BtnEditSpider").addClass("btn-danger");
            }
            else {


                if ($("#Image").val() == null || $("#Image").val() == "") {

                    var tags = [];

                    //Data

                    for (var i = 0; i < $(".tag").length; i++) {
                        tags.push($(".tag")[i].innerText);
                    }
                    var Category = $("#Category").val();
                    var Title = $("#Title").val();
                    var Description = $("#my-textarea").val();
                    $(".loding").removeClass('d-none');
                    $.ajax({
                        type: "POST",
                        url: '/Admin/Management/SpiderEdit',
                        data: { ID: ID, Category: Category, Title: Title, Description: Description, Image: null, SeoTages: tags },
                        success: function (result) {
                            if (result == "true") {
                                window.location.reload();
                            } else {
                                alert(result);
                            }
                        },
                        dataType: "json",
                        traditional: true
                    });


                }
                else {


                    var data = new FormData();
                    var files = $("#Image").get(0).files;


                    if (files[0].size > 3000000) {

                        $("#BtnEditSpider").html("فایل بیش از اندازه بزرگ است");
                        $("#BtnEditSpider").removeClass("btn-success");
                        $("#BtnEditSpider").addClass("btn-danger");

                    } else {

                        if (files.length > 0) {
                            data.append("UploadSpiderImage", files[0]);
                        }

                        $.ajax({
                            url: "/Admin/Upload/UploadSpiderImage",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {
                                if (response == "0") {
                                    $("#BtnEditSpider").html("فایل نامعتبر است");
                                    $("#BtnEditSpider").removeClass("btn-success");
                                    $("#BtnEditSpider").addClass("btn-danger");
                                } else {
                                    var tags = [];

                                    //Data

                                    for (var i = 0; i < $(".tag").length; i++) {
                                        tags.push($(".tag")[i].innerText);
                                    }
                                    var Category = $("#Category").val();
                                    var Title = $("#Title").val();
                                    var Description = $("#my-textarea").val();
                                    var Image = response;
                                    $(".loding").removeClass('d-none');
                                    $.ajax({
                                        type: "POST",
                                        url: '/Admin/Management/SpiderEdit',
                                        data: { ID: ID, Category: Category, Title: Title, Description: Description, Image: Image, SeoTages: tags },
                                        success: function (result) {
                                            if (result == "true") {
                                                $.get("/Admin/Management/P_Spider", function (result) {
                                                    window.location.reload();
                                                });
                                            } else {
                                                alert(result);
                                            }
                                        },
                                        dataType: "json",
                                        traditional: true
                                    });
                                }
                            }
                        });

                    }


                }


            }

        }

    }
}

$("#BtnAddSpiderCategory").click(function () {

    var Title = $("#Title").val();


    if (Title.length > 30) {
        $("#BtnAddSpiderCategory").html("<i class='fas fa-plus-circle'></i>افزودن");
        $("#BtnAddSpiderCategory").addClass('btn-danger');
        $("#BtnAddSpiderCategory").removeClass('btn-success');
    } else {

        $("#BtnAddSpiderCategory").html("عنوان مناسب وارد کنید");
        $("#BtnAddSpiderCategory").addClass('btn-danger');
        $("#BtnAddSpiderCategory").removeClass('btn-success');

        $(".loding").removeClass('d-none');


        $.get("/Admin/Management/SpiderCategoryCreate?Title=" + Title, function (result) {
            if (result == "true") {
                $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                window.location.reload();
            } else {
                alert(result);
            }
        });
    }
});