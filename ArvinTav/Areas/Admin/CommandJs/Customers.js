$("#Image").change(function () {
    if ($("#Image").val() != null) {
        $("#FileName").html($("#Image").val());
        $("#FileName").addClass("border");
        $("#FileName").addClass("border-success");
    }
});

$("#BtnCustomerCreate").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#PhoneNumber").val() == null || $("#PhoneNumber").val() == "") {
        $("#BtnCustomerCreate").removeClass('btn-success');
        $("#BtnCustomerCreate").addClass('btn-danger');
        $("#BtnCustomerCreate").html("تمامی موارد اجباری است");
    } else {

        var Title = $("#Title").val();
        var PhoneNumber = $("#PhoneNumber").val();

        if (Title.length > 20 || Title.includes("'")) {
            $("#BtnCustomerCreate").removeClass('btn-success');
            $("#BtnCustomerCreate").addClass('btn-danger');
            $("#BtnCustomerCreate").html("عنوان مناسب وارد کنید");
        } else {

            if (PhoneNumber.length > 11 || PhoneNumber.includes("'")) {

                $("#BtnCustomerCreate").removeClass('btn-success');
                $("#BtnCustomerCreate").addClass('btn-danger');
                $("#BtnCustomerCreate").html("لطفا شماره تماس مناسب وارد کنید");

            } else {

                var data = new FormData();
                var files = $("#Logo").get(0).files;


                if (files[0].size > 3000000) {
                    $("#BtnCustomerCreate").removeClass('btn-success');
                    $("#BtnCustomerCreate").addClass('btn-danger');
                    $("#BtnCustomerCreate").html("حجم فایل بسیار است");
                } else {
                    if (files.length > 0) {
                        data.append("UploadCustomerImageFile", files[0]);
                    }
                    $.ajax({
                        url: "/Admin/Upload/UploadCustomerLogo",
                        type: "POST",
                        processData: false,
                        contentType: false,
                        data: data,
                        success: function (response) {
                            if (response == "0") {
                                $("#BtnCustomerCreate").removeClass('btn-success');
                                $("#BtnCustomerCreate").addClass('btn-danger');
                                $("#BtnCustomerCreate").html("فایل نا معتبر است");
                            } else {
                                $("#BtnCustomerCreate").addClass('btn-success');
                                $("#BtnCustomerCreate").removeClass('btn-danger');
                                $("#BtnCustomerCreate").html("<i class='fas fa-plus-circle'></i>افزودن");
                                $(".loding").removeClass("d-none");
                                var Title = $("#Title").val();
                                var PhoneNumber = $("#PhoneNumber").val();
                                var Logo = response;
                                $.get("/Admin/Management/CreateCustomer?Title=" + Title + "&PhoneNumber=" + PhoneNumber + "&Logo=" + Logo, function (result) {
                                    if (result == "true") {
                                        $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                                        $.get("/Admin/Management/P_Customers", function (result) {
                                            $(".Panel").removeClass("bg-info");
                                            $(".Panel").removeClass("text-white");
                                            $("#CustomersPaper").addClass("bg-info");
                                            $("#CustomersPaper").addClass("text-white");
                                            $("#card-table").html(result);
                                            alert(" مشتری با موفقیت ثبت شد");
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


function BtnCustomerEdit(ID) {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#PhoneNumber").val() == null || $("#PhoneNumber").val() == "") {
        $("#BtnCustomerEdit").removeClass('btn-success');
        $("#BtnCustomerEdit").addClass('btn-danger');
        $("#BtnCustomerEdit").html("تمامی موارد اجباری است");
    } else {
        $("#BtnCustomerEdit").addClass('btn-success');
        $("#BtnCustomerEdit").removeClass('btn-danger');
        $("#BtnCustomerEdit").html("<i class='fas fa-edit'></i>ویرایش");

        var Title = $("#Title").val();
        var PhoneNumber = $("#PhoneNumber").val();



        if (Title.length > 20 || Title.includes("'")) {
            $("#BtnCustomerEdit").removeClass('btn-success');
            $("#BtnCustomerEdit").addClass('btn-danger');
            $("#BtnCustomerEdit").html("عنوان مناسب وارد کنید");
        } else {

            if (PhoneNumber.length > 11 || PhoneNumber.includes("'")) {

                $("#BtnCustomerEdit").removeClass('btn-success');
                $("#BtnCustomerEdit").addClass('btn-danger');
                $("#BtnCustomerEdit").html("لطفا شماره تماس مناسب وارد کنید");

            } else {

                if ($("#Logo").val() == null || $("#Logo").val() == "") {
                    $.get("/Admin/Management/EditCustomer?ID=" + ID + "&Title=" + Title + "&PhoneNumber=" + PhoneNumber + "&Logo=", function (result) {
                        if (result == "true") {
                            $("#card-table").html("<img src='/img/gif/load.gif' class='loding justify-content-center' />");
                            $.get("/Admin/Management/P_Customers", function (result) {
                                $(".Panel").removeClass("bg-info");
                                $(".Panel").removeClass("text-white");
                                $("#PartnersPaper").addClass("bg-info");
                                $("#PartnersPaper").addClass("text-white");
                                $("#card-table").html(result);
                                alert(" مشتری با موفقیت ویرایش شد");
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
                        $("#BtnCustomerEdit").removeClass('btn-success');
                        $("#BtnCustomerEdit").addClass('btn-danger');
                        $("#BtnCustomerEdit").html("حجم فایل بسیار است");
                    } else {
                        if (files.length > 0) {
                            data.append("UploadCustomerImageFile", files[0]);
                        }
                        $.ajax({
                            url: "/Admin/Upload/UploadPartnerLogo",
                            type: "POST",
                            processData: false,
                            contentType: false,
                            data: data,
                            success: function (response) {
                                if (response == "0") {
                                    $("#BtnCustomerEdit").removeClass('btn-success');
                                    $("#BtnCustomerEdit").addClass('btn-danger');
                                    $("#BtnCustomerEdit").html("فایل نامعتبر است");
                                } else {
                                    var Logo = response;
                                    $("#BtnCustomerEdit").addClass('btn-success');
                                    $("#BtnCustomerEdit").removeClass('btn-danger');
                                    $("#BtnCustomerEdit").html("<i class='fas fa-edit'></i>ویرایش");
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