function InfoMassage(ID) {
    $.get("/Admin/Management/P_MassageInfo?ID=" + ID, function (result) {
        $(".modal-dialog").removeClass("modal-lg");
        $(".modal-dialog").removeClass("modal-xl");
        $(".modal-dialog").addClass("modal-md");
        $(".modal-content").html(result);
        $.get("/Admin/Management/P_Massage", function (result) {
            $(".Panel").removeClass("bg-info");
            $(".Panel").removeClass("text-white");
            $("#MassagePaper").addClass("bg-info");
            $("#MassagePaper").addClass("text-white");
            $("#card-table").html(result);
        });
    });
}

function RemoveMassage(ID) {
    $.get("/Admin/Management/RemoveMassage?ID=" + ID, function (result) {
        if (result == "true") {
            $.get("/Admin/Management/P_Massage", function (result) {
                $(".Panel").removeClass("bg-info");
                $(".Panel").removeClass("text-white");
                $("#MassagePaper").addClass("bg-info");
                $("#MassagePaper").addClass("text-white");
                $("#card-table").html(result);

            });
        } else {
            alert(result);
        }
    });
}

function BtnSearch() {
    var Result = $("#Search").val();
    var PageId = 1;
    var Status = $("#DegreeSearch option:selected").val();
    var InPageCount = $("#InPageCount option:selected").val();
    $("#SearchLoad").removeClass("d-none");
    $.get("/Admin/Management/P_Massage?PageId=" + PageId + "&Result=" + Result + "&Status=" + Status + "&InPageCount=" + InPageCount, function (result) {
        $("#card-table").html(result);
        $("#SearchLoad").addClass("d-none");
    });
}

$("#pageNumber").change(function () {
    var Result = $("#Search").val();
    var PageId = $("#pageNumber option:selected").val();
    var Status = $("#DegreeSearch option:selected").val();
    var InPageCount = $("#InPageCount option:selected").val();
    $("#SearchLoad").removeClass("d-none");
    $.get("/Admin/Management/P_Massage?PageId=" + PageId + "&Result=" + Result + "&Status=" + Status + "&InPageCount=" + InPageCount, function (result) {
        $("#card-table").html(result);
        $("#SearchLoad").addClass("d-none");
    });
});

$("#InPageCount").change(function () {
    var Result = $("#Search").val();
    var PageId = $("#pageNumber option:selected").val();
    var Status = $("#DegreeSearch option:selected").val();
    var InPageCount = $("#InPageCount option:selected").val();
    $("#SearchLoad").removeClass("d-none");
    $.get("/Admin/Management/P_Massage?PageId=" + PageId + "&Result=" + Result + "&Status=" + Status + "&InPageCount=" + InPageCount, function (result) {
        $("#card-table").html(result);
        $("#SearchLoad").addClass("d-none");
    });
});