$('#addBtn').on("click", function () {
    
    var today = $(this).attr('data-dateNow');
    var date = today.concat(' 23:59');
    console.log(today);
    var row = '<tr id="custom"><td>Id</td><td><input id="customName" asp-for="@Model[i].EventName" class="form-control" style="border:0px"/></td><td><input id="customFirst" asp-for="@Model[i].OddsForFirstTeam" class="form-control" style="border:0px"/></td><td><input id="customDraw" asp-for="@Model[i].OddsForDraw" class="form-control" style="border:0px" /></td><td><input id="customSecond" asp-for="@Model[i].OddsForSecondTeam" class="form-control" style="border:0px" /></td><td><input id="customDate" asp-for="@Model[i].EventStartDate" class="form-control" style="border:0px" value='+date+'/></td> <td><input type="submit" id="addNewEventButton" value="Add" class="btn saveBtn" data-eventId="@Model[i].Id" data-eventName="@Model[i].EventName" data-eventFirst="@Model[i].OddsForFirstTeam" data-eventDraw="@Model[i].OddsForDraw" data-eventSecond="@Model[i].OddsForSecondTeam" data-eventDate="@Model[i].EventStartDate" /></td></tr>';

    $('#tableEdit').append(row);

    $('#customName')
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();

    $('#customFirst')
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();

    $('#customSecond')
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();

    $('#customDraw')
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();

    $('#customDate')
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();

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

        const a = $(this);

        const url = "/Event/AddEvent?name=" + newEventName + "&first=" + newEventFirst + "&draw=" + newEventDraw + "&second=" + newEventSecond + "&date=" + newEventDate;

        $.ajax({
            url: url,
            data: {
                'name': newEventName, 'first': newEventFirst, 'draw': newEventDraw,
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

});