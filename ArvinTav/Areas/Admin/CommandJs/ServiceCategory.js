$("#AddCategory").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Image").val() == null || $("#Image").val() == "" || $("#my-textarea").val() == null || $("#my-textarea").val() == "") {
        $("#AddCategory").html("همه موارد اجباری میباشد");
        $("#AddCategory").removeClass("btn-success");
        $("#AddCategory").addClass("btn-danger");
    } else {

        var Title = $("#Title").val();
        var Description = $("#my-textarea").val();

        if (Title.includes("'") || Title.length > 100) {
            $("#AddCategory").html("عنوان معتبر وارد کنید");
            $("#AddCategory").removeClass("btn-success");
            $("#AddCategory").addClass("btn-danger");
        } else {
            $("#AddCategory").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#AddCategory").addClass("btn-success");
            $("#AddCategory").removeClass("btn-danger");

            if (Description.includes("&#39;") || Description.length > 1500) {
                $("#AddCategory").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                $("#AddCategory").removeClass("btn-success");
                $("#AddCategory").addClass("btn-danger");
            }
            else {

                $("#AddCategory").html("<i class='fas fa-plus-circle'></i>افزودن");
                $("#AddCategory").addClass("btn-success");
                $("#AddCategory").removeClass("btn-danger");

                var data = new FormData();
                var files = $("#Image").get(0).files;

                if (files[0].size > 3000000) {

                    $("#AddCategory").html("فایل بیش از اندازه بزرگ است");
                    $("#AddCategory").removeClass("btn-success");
                    $("#AddCategory").addClass("btn-danger");

                } else {

                    if (files.length > 0) {
                        data.append("UploadCategoryImageFile", files[0]);
                    }
                    $.ajax({
                        url: "/Admin/Upload/UploadCategoryImage",
                        type: "POST",
                        processData: false,
                        contentType: false,
                        data: data,
                        success: function (response) {
                            if (response == "0") {
                                $("#AddCategory").html("فایل معتبر نیست");
                                $("#AddCategory").removeClass("btn-success");
                                $("#AddCategory").addClass("btn-danger");
                            } else {
                                $("#AddCategory").html("<i class='fas fa-plus-circle'></i>افزودن");
                                $("#AddCategory").addClass("btn-success");
                                $("#AddCategory").removeClass("btn-danger");
                                var Image = response;
                                var ParentID = $("#ParentID").val();
                                var Title = $("#Title").val();
                                if ($("#IsActive").is(":checked")) {
                                    var IsActive = "1";
                                } else {
                                    var IsActive = "0";
                                }
                                var mytextarea = $("#my-textarea").val();
                                $(".loding").removeClass("d-none");
                                $.ajax({
                                    type: "POST",
                                    url: '/Admin/ServiceCategory/Create',
                                    data: { ParentID: ParentID, Title: Title, IsActive: IsActive, Description: mytextarea, Image: Image },
                                    success: function (result) {
                                        if (result == "true") {
                                            if (ParentID == 0) {
                                                window.location.reload();
                                            } else {
                                                $.get("/Admin/ServiceCategory/P_ChildCategory?ParentID=" + ParentID, function (result) {
                                                    $(".modal-dialog").removeClass("modal-md");
                                                    $(".modal-dialog").removeClass("modal-lg");
                                                    $(".modal-dialog").addClass("modal-xl");
                                                    $(".modal-content").html(result);
                                                });
                                            }
                                        }
                                    },
                                    dataType: "json",
                                    traditional: true
                                });
                            }
                        },
                        error: function (er) {
                            alert(er);
                        }

                    });


                }


            }

        }

    }

});

$("#EditCategory").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#my-textarea").val() == null || $("#my-textarea").val() == "") {
        $("#EditCategory").html("همه موارد اجباری میباشد");
        $("#EditCategory").removeClass("btn-success");
        $("#EditCategory").addClass("btn-danger");
    } else {

        $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
        $("#EditCategory").addClass("btn-success");
        $("#EditCategory").removeClass("btn-danger");

        var ID = $("#ID").val();
        if ($("#Image").val() == null || $("#Image").val() == "") {

            var Title = $("#Title").val();
            var Description = $("#my-textarea").val();

            if (Title.includes("'") || Title.length > 100) {
                $("#EditCategory").html("عنوان معتبر وارد کنید");
                $("#EditCategory").removeClass("btn-success");
                $("#EditCategory").addClass("btn-danger");
            } else {
                $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                $("#EditCategory").addClass("btn-success");
                $("#EditCategory").removeClass("btn-danger");

                if (Description.includes("&#39;") || Description.length > 1500) {
                    $("#EditCategory").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                    $("#EditCategory").removeClass("btn-success");
                    $("#EditCategory").addClass("btn-danger");
                }
                else {
                    $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                    $("#EditCategory").addClass("btn-success");
                    $("#EditCategory").removeClass("btn-danger");
                    var ParentID = $("#ParentID").val();
                    var Title = $("#Title").val();
                    if ($("#IsActive").is(":checked")) {
                        var IsActive = "1";
                    } else {
                        var IsActive = "0";
                    }
                    var mytextarea = $("#my-textarea").val();
                    $(".loding").removeClass("d-none");
                    $.ajax({
                        type: "POST",
                        url: '/Admin/ServiceCategory/Edit',
                        data: { ID: ID, ParentID: ParentID, Title: Title, IsActive: IsActive, Description: mytextarea, Image: null },
                        success: function (result) {
                            if (result == "true") {
                                if (ParentID == 0) {
                                    window.location.reload();
                                } else {
                                    $.get("/Admin/ServiceCategory/P_ChildCategory?ParentID=" + ParentID, function (result) {
                                        $(".modal-dialog").removeClass("modal-md");
                                        $(".modal-dialog").removeClass("modal-lg");
                                        $(".modal-dialog").addClass("modal-xl");
                                        $(".modal-content").html(result);
                                    });
                                }
                            }
                        },
                        dataType: "json",
                        traditional: true
                    });



                }
            }

        } else {

            var Title = $("#Title").val();
            var Description = $("#my-textarea").val();

            if (Title.includes("'") || Title.length > 30) {
                $("#EditCategory").html("عنوان معتبر وارد کنید");
                $("#EditCategory").removeClass("btn-success");
                $("#EditCategory").addClass("btn-danger");
            } else {
                $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                $("#EditCategory").addClass("btn-success");
                $("#EditCategory").removeClass("btn-danger");

                if (Description.includes("&#39;") || Description.length > 1500) {
                    $("#EditCategory").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                    $("#EditCategory").removeClass("btn-success");
                    $("#EditCategory").addClass("btn-danger");
                }
                else {

                    $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                    $("#EditCategory").addClass("btn-success");
                    $("#EditCategory").removeClass("btn-danger");

                    var data = new FormData();
                    var files = $("#Image").get(0).files;

                    if (files[0].size > 3000000) {

                        $("#EditCategory").html("فایل بیش از اندازه بزرگ است");
                        $("#EditCategory").removeClass("btn-success");
                        $("#EditCategory").addClass("btn-danger");
                    }
                    else {

                        $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                        $("#EditCategory").addClass("btn-success");
                        $("#EditCategory").removeClass("btn-danger");

                        var data = new FormData();
                        var files = $("#Image").get(0).files;
                        if (files.length > 0) {
                            data.append("UploadCategoryImageFile", files[0]);
                        }
                        $.ajax({
                            url: "/Admin/Upload/UploadCategoryImage",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {


                                if (response == "0") {
                                    $("#EditCategory").html("فایل معتبر نیست");
                                    $("#EditCategory").removeClass("btn-success");
                                    $("#EditCategory").addClass("btn-danger");

                                } else {

                                    $("#EditCategory").html("<i class='fas fa-check'></i>ویرایش");
                                    $("#EditCategory").addClass("btn-success");
                                    $("#EditCategory").removeClass("btn-danger");


                                    var Image = response;

                                    var ParentID = $("#ParentID").val();
                                    var Title = $("#Title").val();
                                    if ($("#IsActive").is(":checked")) {
                                        var IsActive = "1";
                                    } else {
                                        var IsActive = "0";
                                    }
                                    var mytextarea = $("#my-textarea").val();
                                    $(".loding").removeClass("d-none");
                                    $.ajax({
                                        type: "POST",
                                        url: '/Admin/ServiceCategory/Edit',
                                        data: { ID: ID, ParentID: ParentID, Title: Title, IsActive: IsActive, Description: mytextarea, Image: Image },
                                        success: function (result) {
                                            if (result == "true") {
                                                if (ParentID == 0) {
                                                    window.location.reload();
                                                } else {
                                                    $.get("/Admin/ServiceCategory/P_ChildCategory?ParentID=" + ParentID, function (result) {
                                                        $(".modal-dialog").removeClass("modal-md");
                                                        $(".modal-dialog").removeClass("modal-lg");
                                                        $(".modal-dialog").addClass("modal-xl");
                                                        $(".modal-content").html(result);
                                                    });
                                                }
                                            }
                                        },
                                        dataType: "json",
                                        traditional: true
                                    });

                                }
                            },
                            error: function (er) {
                                alert(er);
                            }

                        });

                    }
                }
            }

        }

    }

});

function ConfirmDelete(ID) {
    $(".loding").removeClass("d-none");
    $.get("/Admin/ServiceCategory/Remove?ID=" + ID, function (result) {
        if (result == "true") {
            window.location.reload();
        }
    });
}

$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});