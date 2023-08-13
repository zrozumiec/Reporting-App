let solutionIdString = "0";

$(document).on("click", ".open-AddSolutionDialog", function () {
    solutionIdString = $(this).data('id');
    $(".modal-body #solutionId").val(solutionIdString);
    $('#myVar').val(solutionIdString);
});


function acceptSolution(p1) {
    let solutionId = Number(solutionIdString);
    let failureId = Number(p1)

    $.ajax({
        url: '/Solution/AcceptSolution',
        type: 'POST',
        data: { 'solutionId': solutionId, 'failureId': failureId },
        async: true,
        success: function (data) {
            location.reload(true);
        }
    });
}