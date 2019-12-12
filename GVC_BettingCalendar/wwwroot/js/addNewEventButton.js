$('#addNewEventButton').on("click", function () {

    var nameId = 'customName';
    var firstId = 'customFirst';
    var drawId = 'customDraw';
    var secondId = 'customSecond';
    var dateId = 'customDate';

    const newEventName = $('#' + nameId).text();
    const newEventFirst = $('#' + firstId).text();
    const newEventDraw = $('#' + drawId).text();
    const newEventSecond = $('#' + secondId).text();
    const newEventDate = $('#' + dateId).text();


    console.log(newEventName)
    console.log(newEventFirst)
    console.log(newEventDraw)
    console.log(newEventSecond)
    console.log(newEventDate)

});
