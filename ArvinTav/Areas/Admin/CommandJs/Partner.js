$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});

$("#BtnPartnerCreate").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#PhoneNumber").val() == null || $("#PhoneNumber").val() == "") {
        $("#BtnPartnerCreate").removeClass('btn-success');
        $("#BtnPartnerCreate").addClass('btn-danger');
        $("#BtnPartnerCreate").html("تمامی موارد اجباری است");
    } else {
        var Title = $("#Title").val();
        var PhoneNumber = $("#PhoneNumber").val();

        if (Title.length > 20 || Title.includes("'")) {
            $("#BtnPartnerCreate").removeClass('btn-success');
            $("#BtnPartnerCreate").addClass('btn-danger');
            $("#BtnPartnerCreate").html("عنوان مناسب وارد کنید");
        } else {

            if (PhoneNumber.length > 11 || PhoneNumber.includes("'")) {

                $("#BtnPartnerCreate").removeClass('btn-success');
                $("#BtnPartnerCreate").addClass('btn-danger');
                $("#BtnPartnerCreate").html("لطفا شماره تماس مناسب وارد کنید");

            } else {


                var data = new FormData();
                var files = $("#Logo").get(0).files;

                if (files[0].size > 3000000) {
                    $("#BtnPartnerCreate").removeClass('btn-success');
                    $("#BtnPartnerCreate").addClass('btn-danger');
                    $("#BtnPartnerCreate").html("حجم فایل بسیار است");
                } else {

                    if (files.length > 0) {
                        data.append("UploadPartnerImageFile", files[0]);
                    }

                    $.ajax({
                        url: "/Admin/Upload/UploadPartnerLogo",
                        type: "POST",
                        processData: false,
                        contentType: false,
                        data: data,
                        success: function (response) {
                            if (response == "0") {

                                $("#BtnPartnerCreate").removeClass('btn-success');
                                $("#BtnPartnerCreate").addClass('btn-danger');
                                $("#BtnPartnerCreate").html("فایل معتبر نیست");

                            } else {

                                var Title = $("#Title").val();
                                var PhoneNumber = $("#PhoneNumber").val();
                                var Logo = response;
                                $("#BtnPartnerCreate").addClass('btn-success');
                                $("#BtnPartnerCreate").removeClass('btn-danger');
                                $("#BtnPartnerCreate").html("<i class='fas fa-plus-circle'></i>افزودن");
                                $(".loding").removeClass("d-none");
                                $.get("/Admin/Management/CreatePartner?Title=" + Title + "&PhoneNumber=" + PhoneNumber + "&Logo=" + Logo, function (result) {
                                    if (result == "true") {
                                        $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                                        $.get("/Admin/Management/P_Partners", function (result) {
                                            $(".Panel").removeClass("bg-info");
                                            $(".Panel").removeClass("text-white");
                                            $("#PartnersPaper").addClass("bg-info");
                                            $("#PartnersPaper").addClass("text-white");
                                            $("#card-table").html(result);
                                            alert(" همکار با موفقیت ثبت شد");
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


function BtnPartnerEdit(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#PhoneNumber").val() == null || $("#PhoneNumber").val() == "") {
        $("#BtnPartnerEdit").removeClass('btn-success');
        $("#BtnPartnerEdit").addClass('btn-danger');
        $("#BtnPartnerEdit").html("تمامی موارد اجباری است");
    } else {

        var Title = $("#Title").val();
        var PhoneNumber = $("#PhoneNumber").val();

        if (Title.length > 20 || Title.includes("'")) {
            $("#BtnPartnerEdit").removeClass('btn-success');
            $("#BtnPartnerEdit").addClass('btn-danger');
            $("#BtnPartnerEdit").html("عنوان مناسب وارد کنید");
        } else {

            if (PhoneNumber.length > 11 || PhoneNumber.includes("'")) {

                $("#BtnPartnerEdit").removeClass('btn-success');
                $("#BtnPartnerEdit").addClass('btn-danger');
                $("#BtnPartnerEdit").html("لطفا شماره تماس مناسب وارد کنید");

            } else {


                if ($("#Logo").val() == null || $("#Logo").val() == "") {
                    $.get("/Admin/Management/EditPartner?ID=" + ID + "&Title=" + Title + "&PhoneNumber=" + PhoneNumber + "&Logo=", function (result) {
                        if (result == "true") {
                            $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                            $.get("/Admin/Management/P_Partners", function (result) {
                                $(".Panel").removeClass("bg-info");
                                $(".Panel").removeClass("text-white");
                                $("#PartnersPaper").addClass("bg-info");
                                $("#PartnersPaper").addClass("text-white");
                                $("#card-table").html(result);
                                alert(" همکار با موفقیت ویرایش شد");
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
                    var files = $("#Logo").get(0).files;



                    if (files[0].size > 3000000) {
                        $("#BtnPartnerEdit").removeClass('btn-success');
                        $("#BtnPartnerEdit").addClass('btn-danger');
                        $("#BtnPartnerEdit").html("حجم فایل بسیار است");
                    } else {


                        if (files.length > 0) {
                            data.append("UploadPartnerImageFile", files[0]);
                        }
                        $.ajax({
                            url: "/Admin/Upload/UploadPartnerLogo",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {
                                if (response == "0") {
                                    $("#BtnPartnerEdit").removeClass('btn-success');
                                    $("#BtnPartnerEdit").addClass('btn-danger');
                                    $("#BtnPartnerEdit").html("فایل معتبر نیست");
                                } else {
                                    var Logo = response;

                                    $("#BtnPartnerEdit").addClass('btn-success');
                                    $("#BtnPartnerEdit").removeClass('btn-danger');
                                    $("#BtnPartnerEdit").html("<i class='fas fa-edit'></i>ویرایش");

                                    $.get("/Admin/Management/EditPartner?ID=" + ID + "&Title=" + Title + "&PhoneNumber=" + PhoneNumber + "&Logo=" + Logo, function (result) {
                                        if (result == "true") {
                                            $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                                            $.get("/Admin/Management/P_Partners", function (result) {
                                                $(".Panel").removeClass("bg-info");
                                                $(".Panel").removeClass("text-white");
                                                $("#PartnersPaper").addClass("bg-info");
                                                $("#PartnersPaper").addClass("text-white");
                                                $("#card-table").html(result);
                                                alert(" همکار با موفقیت ثبت شد");
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

    }
}