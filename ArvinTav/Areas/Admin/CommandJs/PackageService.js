$("#AddPackageService").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Price").val() == null || $("#my-textarea").val() == null || $("#my-textarea").val() == "" || $("#Price").val() == "" || $("#Image").val() == null || $("#Image").val() == "" || $("#Category").val() == null || $("#Category").val() == "") {
        $("#AddPackageService").removeClass('btn-success');
        $("#AddPackageService").addClass('btn-danger');
        $("#AddPackageService").html("تمامی موارد اجباری است");
    } else {

        var Title = $("#Title").val();
        var Description = $("#my-textarea").val();
        var Price = $("#Price").val();
        if (Title.includes("'") || Title.length > 100) {
            $("#AddPackageService").html("عنوان معتبر وارد کنید");
            $("#AddPackageService").removeClass("btn-success");
            $("#AddPackageService").addClass("btn-danger");
        } else {
            $("#AddPackageService").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#AddPackageService").addClass("btn-success");
            $("#AddPackageService").removeClass("btn-danger");

            if (Description.includes("&#39;") || Description.length > 1500) {
                $("#AddPackageService").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                $("#AddPackageService").removeClass("btn-success");
                $("#AddPackageService").addClass("btn-danger");
            }
            else {
                if (Price.length>13) {
                    $("#AddPackageService").html("قیمت مناسب وارد کنید");
                    $("#AddPackageService").removeClass("btn-success");
                    $("#AddPackageService").addClass("btn-danger");
                } else {

                    $("#AddPackageService").html("<i class='fas fa-plus-circle'></i>افزودن");
                    $("#AddPackageService").addClass("btn-success");
                    $("#AddPackageService").removeClass("btn-danger");

                    var data = new FormData();
                    var files = $("#Image").get(0).files;

                    if (files[0].size > 3000000) {

                        $("#AddPackageService").html("فایل بیش از اندازه بزرگ است");
                        $("#AddPackageService").removeClass("btn-success");
                        $("#AddPackageService").addClass("btn-danger");

                    } else {

                        if (files.length > 0) {
                            data.append("UploadPackageImageFile", files[0]);
                        }

                        $.ajax({
                            url: "/Admin/Upload/UploadPackageImage",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {

                                if (response == "0") {
                                    $("#AddPackageService").html("فایل معتبر نیست");
                                    $("#AddPackageService").removeClass("btn-success");
                                    $("#AddPackageService").addClass("btn-danger");

                                } else {
                                    $("#AddPackageService").html("<i class='fas fa-plus-circle'></i>افزودن");
                                    $("#AddPackageService").addClass("btn-success");
                                    $("#AddPackageService").removeClass("btn-danger");

                                    var Category = $("#Category").val();
                                    var Title = $("#Title").val();
                                    var Price = $("#Price").val();
                                    var Image = response;
                                    var mytextarea = $("#my-textarea").val();
                                    $(".loding").removeClass('d-none');
                                    $.ajax({
                                        type: "POST",
                                        url: '/Admin/Package/Create',
                                        data: { Category: Category, Title: Title, Price: Price, Image: Image, Description: mytextarea },
                                        success: function (result) {
                                            if (result != "true") {

                                                ////////////////////////////////

                                                var len = $(".DetailsRow").length;
                                                var Details = [];

                                                for (let i = 0; i < len; i++) {
                                                    var part = $(".DetailsRow")[i]
                                                    var obj = {
                                                        PackageID: result,
                                                        Title: part.children[0].innerHTML,
                                                        Response: part.children[1].innerHTML
                                                    }

                                                    Details.push(obj);
                                                }

                                                $.ajax(
                                                    {
                                                        url: "/Admin/Package/CreatePackageServiceDetails",
                                                        data: JSON.stringify(Details),
                                                        method: 'Post',
                                                        contentType: 'application/json',
                                                        dataType: 'json',
                                                        async: true,
                                                        success: function (data) {
                                                            window.location.reload();
                                                        },
                                                        error: function () {
                                                            returner = false;
                                                        }
                                                    });

                                                ////////////////////////////////

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
});


$("#MainCategorySelect").change(function () {
    if ($("#MainCategorySelect option:selected").val() == 0) { } else {
        $.get("/Admin/ServiceCategory/P_ChildCategoryInCreate?ParentID=" + $("#MainCategorySelect option:selected").val(), function (result) {
            $("#ChildCategory").html(result);
            $("#Category").val($("#MainCategorySelect option:selected").val());
        });
    }
});


$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});


function EditPackageService(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Price").val() == null || $("#my-textarea").val() == null || $("#my-textarea").val() == "" || $("#Price").val() == "" || $("#Category").val() == null || $("#Category").val() == "") {
        $("#EditPackageService").removeClass('btn-success');
        $("#EditPackageService").addClass('btn-danger');
        $("#EditPackageService").html("تمامی موارد اجباری است");
    } else {

        var Title = $("#Title").val();
        var Description = $("#my-textarea").val();
        var Price = $("#Price").val();
        if (Title.includes("'") || Title.length > 100) {
            $("#EditPackageService").html("عنوان معتبر وارد کنید");
            $("#EditPackageService").removeClass("btn-success");
            $("#EditPackageService").addClass("btn-danger");
        } else {
            $("#EditPackageService").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#EditPackageService").addClass("btn-success");
            $("#EditPackageService").removeClass("btn-danger");

            if (Description.includes("&#39;") || Description.length > 1500) {
                $("#EditPackageService").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                $("#EditPackageService").removeClass("btn-success");
                $("#EditPackageService").addClass("btn-danger");
            }
            else {

                if (Price.length > 13) {
                    $("#EditPackageService").html("قیمت مناسب وارد کنید");
                    $("#EditPackageService").removeClass("btn-success");
                    $("#EditPackageService").addClass("btn-danger");
                } else {
                    if ($("#Image").val() == null || $("#Image").val() == "") {


                        var Category = $("#Category").val();
                        var Title = $("#Title").val();
                        var Price = $("#Price").val();
                        var mytextarea = $("#my-textarea").val();
                        var Image = $("#Image").val();
                        $("#EditPackageService").addClass('btn-success');
                        $("#EditPackageService").removeClass('btn-danger');
                        $("#EditPackageService").html("<i class='fas fa-edit'></i>ویرایش");
                        $(".loding").removeClass('d-none');
                        $.ajax({
                            type: "POST",
                            url: '/Admin/Package/Edit',
                            data: { ID: ID, Category: Category, Title: Title, Price: Price, Image: Image, Description: mytextarea },
                            success: function (result) {
                                if (result == "true") {

                                    ////////////////////////////////

                                    var len = $(".DetailsRow").length;
                                    var Details = [];

                                    for (let i = 0; i < len; i++) {
                                        var part = $(".DetailsRow")[i]
                                        var obj = {
                                            PackageID: ID,
                                            Title: part.children[0].innerHTML,
                                            Response: part.children[1].innerHTML
                                        }

                                        Details.push(obj);
                                    }

                                    $.ajax(
                                        {
                                            url: "/Admin/Package/CreatePackageServiceDetails",
                                            data: JSON.stringify(Details),
                                            method: 'Post',
                                            contentType: 'application/json',
                                            dataType: 'json',
                                            async: true,
                                            success: function (data) {
                                                window.location.reload();
                                            },
                                            error: function () {
                                                returner = false;
                                            }
                                        });

                                    ////////////////////////////////

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

                            $("#EditPackageService").html("فایل بیش از اندازه بزرگ است");
                            $("#EditPackageService").removeClass("btn-success");
                            $("#EditPackageService").addClass("btn-danger");

                        } else {

                            if (files.length > 0) {
                                data.append("UploadPackageImageFile", files[0]);
                            }

                            $.ajax({
                                url: "/Admin/Upload/UploadPackageImage",
                                type: "POST",
                                processData: false,
                                contentType: false,
                                data: data,
                                success: function (response) {

                                    if (response == "0") {
                                        $("#EditPackageService").html("فایل نا معتبراست");
                                        $("#EditPackageService").removeClass("btn-success");
                                        $("#EditPackageService").addClass("btn-danger");
                                    } else {

                                        var Category = $("#Category").val();;
                                        var Title = $("#Title").val();
                                        var Price = $("#Price").val();
                                        var Image = response;
                                        var mytextarea = $("#my-textarea").val();

                                        $("#EditPackageService").addClass('btn-success');
                                        $("#EditPackageService").removeClass('btn-danger');
                                        $("#EditPackageService").html("<i class='fas fa-edit'></i>ویرایش");
                                        $(".loding").removeClass('d-none');
                                        $.ajax({
                                            type: "POST",
                                            url: '/Admin/Package/Edit',
                                            data: { ID: ID, Category: Category, Title: Title, Price: Price, Image: Image, Description: mytextarea },
                                            success: function (result) {
                                                if (result == "true") {

                                                    ////////////////////////////////

                                                    var len = $(".DetailsRow").length;
                                                    var Details = [];

                                                    for (let i = 0; i < len; i++) {
                                                        var part = $(".DetailsRow")[i]
                                                        var obj = {
                                                            PackageID: result,
                                                            Title: part.children[0].innerHTML,
                                                            Response: part.children[1].innerHTML
                                                        }

                                                        Details.push(obj);
                                                    }

                                                    $.ajax(
                                                        {
                                                            url: "/Admin/Package/CreatePackageServiceDetails",
                                                            data: JSON.stringify(Details),
                                                            method: 'Post',
                                                            contentType: 'application/json',
                                                            dataType: 'json',
                                                            async: true,
                                                            success: function (data) {
                                                                window.location.reload();
                                                            },
                                                            error: function () {
                                                                returner = false;
                                                            }
                                                        });

                                                    ////////////////////////////////

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
}


function ConfirmDelete(ID) {
    $(".loding").removeClass('d-none');
    $.post("/Admin/Package/Remove?ID=" + ID, function (result) {
        if (result == "true") {
            window.location.reload();
        } else {
            alert(result);
        }
    });
}