$("#AddDiscount").click(function () {
    if ($("#Code").val() == null || $("#Code").val() == "" || $("#Percentage").val() == null || $("#Percentage").val() == "") {
        $("#AddDiscount").html("تمامی موارد اجباری میباشد");
        $("#AddDiscount").removeClass("btn-success");
        $("#AddDiscount").addClass("btn-danger");
    } else {


        if ($("#Code").val().includes("'")) {
            $("#AddDiscount").html("عنوان مناسب وارد کنید");
            $("#AddDiscount").removeClass("btn-success");
            $("#AddDiscount").addClass("btn-danger");
        } else {

            if ($("#Code").val().length > 20) {
                $("#AddDiscount").html("کد تخفیف مناسب وارد کنید");
                $("#AddDiscount").removeClass("btn-success");
                $("#AddDiscount").addClass("btn-danger");
            } else {

                if ($("#Percentage").val().length > 2) {
                    $("#AddDiscount").html("درصد تخفیف مناسب وارد کنید");
                    $("#AddDiscount").removeClass("btn-success");
                    $("#AddDiscount").addClass("btn-danger");
                } else {

                    if ($("#Percentage").val().startsWith("0")) {
                        $("#AddDiscount").html("درصد تخفیف مناسب وارد کنید");
                        $("#AddDiscount").removeClass("btn-success");
                        $("#AddDiscount").addClass("btn-danger");

                    } else {

                        $("#AddDiscount").html("<i class='fas fa-plus-circle'></i>افزودن");
                        $("#AddDiscount").addClass("btn-success");
                        $("#AddDiscount").removeClass("btn-danger");
                        $(".loding").removeClass('d-none');
                        var Code = $("#Code").val();
                        var Percentage = $("#Percentage").val();
                        $.post("/Admin/Festival/Create?Code=" + Code + "&Percentage=" + Percentage, function (result) {
                            if (result == "true") {
                                window.location.reload();
                            } else {
                                alert(result);
                            }
                        });

                    }

                }
            }
        }
    }
});

function EditDiscount(ID) {
    if ($("#Code").val() == null || $("#Code").val() == "" || $("#Percentage").val() == null || $("#Percentage").val() == "") {
        $("#BtnEditDiscount").html("تمامی موارد اجباری میباشد");
        $("#BtnEditDiscount").removeClass("btn-success");
        $("#BtnEditDiscount").addClass("btn-danger");
    } else {

        if ($("#Code").val().includes("'")) {
            $("#BtnEditDiscount").html("عنوان مناسب وارد کنید");
            $("#BtnEditDiscount").removeClass("btn-success");
            $("#BtnEditDiscount").addClass("btn-danger");

        } else {


            if ($("#Code").val().length > 100) {
                $("#BtnEditDiscount").html("کد تخفیف مناسب وارد کنید");
                $("#BtnEditDiscount").removeClass("btn-success");
                $("#BtnEditDiscount").addClass("btn-danger");
            } else {

                if ($("#Percentage").val().length > 2) {
                    $("#BtnEditDiscount").html("درصد تخفیف مناسب وارد کنید");
                    $("#BtnEditDiscount").removeClass("btn-success");
                    $("#BtnEditDiscount").addClass("btn-danger");
                } else {

                    if ($("#Percentage").val().startsWith("0")) {
                        $("#BtnEditDiscount").html("درصد تخفیف مناسب وارد کنید");
                        $("#BtnEditDiscount").removeClass("btn-success");
                        $("#BtnEditDiscount").addClass("btn-danger");

                    } else {

                        $("#BtnEditDiscount").html("<i class='fas fa-plus-circle'></i>ویرایش");
                        $("#BtnEditDiscount").addClass("btn-success");
                        $("#BtnEditDiscount").removeClass("btn-danger");
                        $(".loding").removeClass('d-none');
                        var Code = $("#Code").val();
                        var Percentage = $("#Percentage").val();
                        $.post("/Admin/Festival/Edit?ID=" + ID + "&Code=" + Code + "&Percentage=" + Percentage, function (result) {
                            if (result == "true") {
                                window.location.reload();
                            } else {
                                alert(result);
                            }
                        });

                    }
                }
            }
        }

    }
}