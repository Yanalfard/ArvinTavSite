$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});


$("#BtnProjectCreate").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Image").val() == null || $("#Image").val() == "" || $("#Link").val() == null || $("#Link").val() == "") {
        $("#BtnProjectCreate").html("تمامی موارد اجباری میباشد");
        $("#BtnProjectCreate").addClass('btn-danger');
        $("#BtnProjectCreate").removeClass('btn-success');
    } else {
        var Title = $("#Title").val();
        var Link = $("#Link").val();

        if (Title.includes("'") || Link.includes("'")) {
            $("#BtnProjectCreate").html("عنوان معتبر وارد کنید");
            $("#BtnProjectCreate").addClass('btn-danger');
            $("#BtnProjectCreate").removeClass('btn-success');
        } else {

            if (Title.length > 20) {
                $("#BtnProjectCreate").html("عنوان معتبر وارد کنید");
                $("#BtnProjectCreate").addClass('btn-danger');
                $("#BtnProjectCreate").removeClass('btn-success');
            } else {

                if (Link.length > 100) {
                    $("#BtnProjectCreate").html("لینک معتبر وارد کنید");
                    $("#BtnProjectCreate").addClass('btn-danger');
                    $("#BtnProjectCreate").removeClass('btn-success');
                } else {

                    var data = new FormData();
                    var files = $("#Image").get(0).files;

                    if (files[0].size > 3000000) {

                        $("#BtnProjectCreate").html("فایل بیش از اندازه بزرگ است");
                        $("#BtnProjectCreate").removeClass("btn-success");
                        $("#BtnProjectCreate").addClass("btn-danger");

                    } else {


                        if (files.length > 0) {
                            data.append("UploadProjectImageFile", files[0]);
                        }

                        $.ajax({
                            url: "/Admin/Upload/UploadProjectImage",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {

                                if (response == "0") {
                                    $("#BtnProjectCreate").html("فایل معتبر نیست");
                                    $("#BtnProjectCreate").removeClass("btn-success");
                                    $("#BtnProjectCreate").addClass("btn-danger");
                                } else {
                                    var Title = $("#Title").val();
                                    var Image = response;
                                    var Link = $("#Link").val();

                                    $("#BtnProjectCreate").html("<i class='fas fa-plus-circle'></i>افزودن");
                                    $("#BtnProjectCreate").addClass("btn-danger");
                                    $("#BtnProjectCreate").removeClass("btn-success");

                                    $(".loding").removeClass('d-none');

                                    $.post("/Admin/Project/Create?Title=" + Title + "&Image=" + Image + "&Link=" + Link, function (result) {
                                        if (result == "true") {
                                            window.location.reload();
                                        } else {
                                            alert(result);
                                        }

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

function EditProject(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Link").val() == null || $("#Link").val() == "") {
        $("#BtnEditProject").html("تمامی موارد اجباری میباشد");
        $("#BtnEditProject").addClass('btn-danger');
        $("#BtnEditProject").removeClass('btn-success');
    } else {

        var Title = $("#Title").val();
        var Link = $("#Link").val();

        if (Title.includes("'") || Link.includes("'")) {
            $("#BtnEditProject").html("عنوان معتبر وارد کنید");
            $("#BtnEditProject").addClass('btn-danger');
            $("#BtnEditProject").removeClass('btn-success');
        } else {

            if (Link.startsWith("http") == false) {
                $("#BtnEditProject").html("لینک معتبر وارد کنید");
                $("#BtnEditProject").addClass('btn-danger');
                $("#BtnEditProject").removeClass('btn-success');
            } else {
                
                if (Title.length > 20) {
                    $("#BtnEditProject").html("عنوان معتبر وارد کنید");
                    $("#BtnEditProject").addClass('btn-danger');
                    $("#BtnEditProject").removeClass('btn-success');
                } else {

                    if (Link.length > 100) {
                        $("#BtnEditProject").html("لینک معتبر وارد کنید");
                        $("#BtnEditProject").addClass('btn-danger');
                        $("#BtnEditProject").removeClass('btn-success');
                    } else {

                        if ($("#Image").val() == null || $("#Image").val() == "") {
                            $("#BtnEditProject").html("<i class='fas fa-edit'></i>ویرایش");
                            $("#BtnEditProject").removeClass('btn-danger');
                            $("#BtnEditProject").addClass('btn-success');
                            $.post("/Admin/Project/Edit?ID=" + ID + "&Title=" + Title + "&Image=" + "&Link=" + Link, function (result) {
                                if (result == "true") {
                                    window.location.reload();
                                } else {
                                    alert(result);
                                }

                            });

                        } else {

                            var data = new FormData();
                            var files = $("#Image").get(0).files;

                            if (files[0].size > 3000000) {

                                $("#BtnEditProject").html("فایل بیش از اندازه بزرگ است");
                                $("#BtnEditProject").removeClass("btn-success");
                                $("#BtnEditProject").addClass("btn-danger");

                            } else {

                                if (files.length > 0) {
                                    data.append("UploadProjectImageFile", files[0]);
                                }

                                $.ajax({
                                    url: "/Admin/Upload/UploadProjectImage",
                                    type: "POST",
                                    processData: false,
                                    contentType: false,
                                    data: data,
                                    success: function (response) {
                                        if (response == "0") {
                                            $("#BtnEditProject").html("فایل معتبر نیست");
                                            $("#BtnEditProject").removeClass("btn-success");
                                            $("#BtnEditProject").addClass("btn-danger");
                                        } else {
                                            var Title = $("#Title").val();
                                            var Image = response;
                                            var Link = $("#Link").val();
                                            $("#BtnEditProject").html("<i class='fas fa-plus-circle'></i>افزودن");
                                            $("#BtnEditProject").removeClass('btn-danger');
                                            $("#BtnEditProject").addClass('btn-success');
                                            $(".loding").removeClass('d-none');
                                            $.post("/Admin/Project/Edit?ID=" + ID + "&Title=" + Title + "&Image=" + Image + "&Link=" + Link, function (result) {
                                                if (result == "true") {
                                                    window.location.reload();
                                                } else {
                                                    alert(result);
                                                }

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
}

