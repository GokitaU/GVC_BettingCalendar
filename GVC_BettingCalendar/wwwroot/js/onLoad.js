$(document).ready(function () {
    $("input")
        .keyup(function () {
            var value = $(this).val();
            $(this).text(value);
        })
        .keyup();
});