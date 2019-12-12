$('.deleteBtn').on("click", function () {


    const eventId = $(this).attr('data-eventId');
  

    const a = $(this);

    const url = "/Event/DeleteEvent?id=" + eventId;

    $.ajax({
        url: url,
        data: {
            'id': eventId
        },
        type: "post",
        cache: false,
        success: function () {

            a.closest('tr').remove();

            console.log(result)

        },
        fail: function (xhr, textStatus, errorThrown) {
            alert('request failed');
            window.location = "/Error/CustomError";
        }
    })


});