$(document).ready(function () {
    $("#addComment").submit(function(event){
        $("#addComment").hide();
        event.preventDefault();
        var loc = parseInt($("#locationId").val());
        console.log(loc);
        $.ajax({
            type: 'GET',
            data: { locationId: loc },
            url: 'Comments/Create',
            datatype: 'html',
            success: function(result){
                $('#commentForm').html(result);
            }
        });
    });

    //$("#newComment").submit(function(event) {
    //    event.preventDefault();
    //    $.ajax({
    //        type: 'POST',
    //        data: $(this).serialize(),
    //        url: 'Comments/Create',
    //        datatype: 'json',
    //        success: function(result){
    //            console.log(result);
    //            $('#commentList').append(result.Body +" by "+ result.User.UserName);
    //        }
    //    });
    //    $("#Body, #UserEmail").val("");
    //    $("#newComment").hide();
    //});
});