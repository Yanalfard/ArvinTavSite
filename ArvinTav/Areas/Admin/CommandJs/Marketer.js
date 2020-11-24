$("#BtnCreateMarketerReport").click(function () {
    if ($("#Title").val() == null || $("#Title").val() == "" || $("#Description").val() == null || $("#Description").val() == "") {
        $("#BtnCreateMarketerReport").removeClass('btn-success');
        $("#BtnCreateMarketerReport").addClass('btn-danger');
        $("#BtnCreateMarketerReport").html("تمامی موارد اجباری میباشد");
    } else {
        var Title = $("#Title").val();
        var Description = $("#Description").val();
        if (Title.includes("'") || Title.length > 30) {
            $("#BtnCreateMarketerReport").html("عنوان معتبر وارد کنید");
            $("#BtnCreateMarketerReport").removeClass("btn-success");
            $("#BtnCreateMarketerReport").addClass("btn-danger");
        } else {
            $("#BtnCreateMarketerReport").html("<i class='fas fa-plus-circle'></i>افزودن");
            $("#BtnCreateMarketerReport").addClass("btn-success");
            $("#BtnCreateMarketerReport").removeClass("btn-danger");

            if (Description.includes("'") || Description.length > 600) {
                $("#BtnCreateMarketerReport").html("توضیحات معتبری وارد کنید - حداکثر تعداد کارکتر 1500 میباشد");
                $("#BtnCreateMarketerReport").removeClass("btn-success");
                $("#BtnCreateMarketerReport").addClass("btn-danger");
            }
            else {

                $("#BtnCreateMarketerReport").removeClass('btn-danger');
                $("#BtnCreateMarketerReport").addClass('btn-success');
                $("#BtnCreateMarketerReport").html("<i class='fas fa-plus-circle'></i>افزودن");

                var Title = $("#Title").val();
                var Description = $("#Description").val();
                $(".loding").removeClass("d-none");
                $.post("/Admin/Marketer/CraateReportUp?Title=" + Title + "&Description=" + Description, function (result) {
                    if (result == "true") {
                        window.location.reload();
                    } else {
                        alert(result);
                    }
                });
            }
        }
    }
});