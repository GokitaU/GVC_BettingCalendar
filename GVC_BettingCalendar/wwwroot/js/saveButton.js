
$('.saveBtn').on("click", function () {

    const eventId = $(this).attr('data-eventId');
    const eventName = $(this).attr('data-eventName');
    const eventFirst = $(this).attr('data-eventFirst');
    const eventDraw = $(this).attr('data-eventDraw');
    const eventSecond = $(this).attr('data-eventSecond');
    const eventDate = $(this).attr('data-eventDate');

    console.log(eventId);
    //debugger;
    var nameId = 'Name' + eventId;
    var firstId = 'First' + eventId;
    var drawId = 'Draw' + eventId;
    var secondId = 'Second' + eventId;
    var dateId = 'Date' + eventId;

    const newEventName = $('#' + nameId).text();
    const newEventFirst = $('#' + firstId).text();
    const newEventDraw = $('#' + drawId).text();
    const newEventSecond = $('#' + secondId).text();
    const newEventDate = $('#' + dateId).text();

    console.log(newEventName);
    console.log(newEventFirst);
    console.log(newEventDraw);
    console.log(newEventSecond);
    console.log(newEventDate);
    
    const a = $(this);

    const url = "/Event/UpdateEvent?id=" + eventId + "&name=" + eventName + "&first=" + eventFirst + "&draw=" + eventDraw + "&second=" + eventSecond + "&date=" + eventDate;

    $.ajax({
        url: url,
        data: {
            'id': eventId, 'name': newEventName, 'first': newEventFirst, 'draw': newEventDraw,
            'second': newEventSecond, 'date': newEventDate
        },
        type: "post",
        cache: false,
        success: function (result) {

            a.closest('tr').replaceWith(result);

            console.log(result)
            
        },
        fail: function (xhr, textStatus, errorThrown) {
            alert('request failed');
            window.location = "/Error/CustomError";
        }
    })


});