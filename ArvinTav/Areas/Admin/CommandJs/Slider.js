$("#BtnAddSlider").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Link").val() == null || $("#Link").val() == "" || $("#Image").val() == null || $("#Image").val() == "") {
        $("#BtnAddSlider").html("تمامی موارد اجباری میباشد");
        $("#BtnAddSlider").addClass('btn-danger');
        $("#BtnAddSlider").removeClass('btn-success');
    } else {


        var Title = $("#Title").val();
        var Link = $("#Link").val();

        if (Title.includes("'") || Title.length > 3000) {
            $("#BtnAddSlider").html("عنوان معتبر وارد کنید");
            $("#BtnAddSlider").removeClass("btn-success");
            $("#BtnAddSlider").addClass("btn-danger");
        } else {
            $("#BtnAddSlider").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#BtnAddSlider").addClass("btn-success");
            $("#BtnAddSlider").removeClass("btn-danger");

            if (Link.includes("&#39;") || Link.length > 200) {
                $("#BtnAddSlider").html("لطفا لینک مناسب وارد کنید");
                $("#BtnAddSlider").removeClass("btn-success");
                $("#BtnAddSlider").addClass("btn-danger");
            }
            else {


                var data = new FormData();
                var files = $("#Image").get(0).files;


                if (files[0].size > 3000000) {

                    $("#BtnAddSlider").html("فایل بیش از اندازه بزرگ است");
                    $("#BtnAddSlider").removeClass("btn-success");
                    $("#BtnAddSlider").addClass("btn-danger");

                } else {


                    if (files.length > 0) {
                        data.append("UploadSliderImageFile", files[0]);
                    }

                    $.ajax({
                        url: "/Admin/Upload/UploadSliderImage",
                        type: "POST",
                        processData: false,
                        contentType: false,
                        data: data,
                        success: function (response) {

                            if (response == "0") {
                                $("#BtnAddSlider").html("فایل نامعتبر است");
                                $("#BtnAddSlider").removeClass("btn-success");
                                $("#BtnAddSlider").addClass("btn-danger");
                            } else {
                                $("#BtnAddSlider").html("<i class='fas fa-plus-circle'></i>افزودن");
                                $("#BtnAddSlider").removeClass('btn-danger');
                                $("#BtnAddSlider").addClass('btn-success');
                                var Title = $("#Title").val();
                                var Link = $("#Link").val();
                                var Image = response;
                                $(".loding").removeClass("d-none");
                                $.post("/Admin/HomeSetting/SliderCreate?Title=" + Title + "&Link=" + Link + "&Image=" + Image, function (result) {

                                    if (result == "true") {

                                        $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                                        $.get("/Admin/HomeSetting/P_Slider", function (result) {
                                            $("#card-table").html(result);
                                            $("#modalSave").css('display', 'none');
                                            $("#modalSave").removeClass('show');
                                            document.querySelectorAll('.modal-backdrop')[0].parentElement.removeChild(document.querySelectorAll('.modal-backdrop')[0]);
                                        });

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
});


function BtnEditSlider(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Link").val() == null || $("#Link").val() == "") {
        $("#BtnEditSlider").html("تمامی موارد اجباری میباشد");
        $("#BtnEditSlider").addClass('btn-danger');
        $("#BtnEditSlider").removeClass('btn-success');
    } else {


        var Title = $("#Title").val();
        var Link = $("#Link").val();

        if (Title.includes("'") || Title.length > 3000) {
            $("#BtnEditSlider").html("عنوان معتبر وارد کنید");
            $("#BtnEditSlider").removeClass("btn-success");
            $("#BtnEditSlider").addClass("btn-danger");
        } else {

            if (Link.includes("&#39;") || Link.length > 5000) {
                $("#BtnEditSlider").html("لطفا لینک مناسب وارد کنید");
                $("#BtnEditSlider").removeClass("btn-success");
                $("#BtnEditSlider").addClass("btn-danger");
            }
            else {
                $("#BtnEditSlider").html("<i class='fas fa-plus-circle'></i>ویرایش");
                $("#BtnEditSlider").addClass("btn-success");
                $("#BtnEditSlider").removeClass("btn-danger");
                if ($("#Image").val() == null || $("#Image").val() == "") {

                    $.post("/Admin/HomeSetting/SliderEdit?ID=" + ID + "&Title=" + Title + "&Link=" + Link + "&Image=", function (result) {

                        if (result == "true") {

                            $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                            $.get("/Admin/HomeSetting/P_Slider", function (result) {
                                $("#card-table").html(result);
                                $("#modalSave").css('display', 'none');
                                $("#modalSave").removeClass('show');
                                document.querySelectorAll('.modal-backdrop')[0].parentElement.removeChild(document.querySelectorAll('.modal-backdrop')[0]);
                            });

                        } else {
                            alert(result);
                        }

                    });


                }
                else {

                    var data = new FormData();
                    var files = $("#Image").get(0).files;

                    if (files[0].size > 3000000) {

                        $("#BtnEditSlider").html("فایل بیش از اندازه بزرگ است");
                        $("#BtnEditSlider").removeClass("btn-success");
                        $("#BtnEditSlider").addClass("btn-danger");

                    } else {


                        if (files.length > 0) {
                            data.append("UploadSliderImageFile", files[0]);
                        }

                        $.ajax({
                            url: "/Admin/Upload/UploadSliderImage",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {
                                var Title = $("#Title").val();
                                var Link = $("#Link").val();
                                var Image = response;
                                $(".loding").removeClass("d-none");
                                $("#BtnEditSlider").html("<i class='fas fa-plus-circle'></i>ویرایش");
                                $("#BtnEditSlider").addClass("btn-success");
                                $("#BtnEditSlider").removeClass("btn-danger");
                                $.post("/Admin/HomeSetting/SliderEdit?ID=" + ID + "&Title=" + Title + "&Link=" + Link + "&Image=" + Image, function (result) {

                                    if (result == "true") {
                                        $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                                        $.get("/Admin/HomeSetting/P_Slider", function (result) {
                                            $("#card-table").html(result);
                                            $("#modalSave").css('display', 'none');
                                            $("#modalSave").removeClass('show');
                                            document.querySelectorAll('.modal-backdrop')[0].parentElement.removeChild(document.querySelectorAll('.modal-backdrop')[0]);
                                        });

                                    } else {
                                        alert(result);
                                    }

                                });
                            }
                        });
                    }
                }

            }
        }

    }
}