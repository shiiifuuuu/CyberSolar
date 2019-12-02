//Disable Search Button On Page Load
$("#searchButton").attr('disabled', 'disabled');

var inp = $("#SearchText");

$("#SearchText").keyup(function () {
    if (inp.val().length <= 0) {
        $('#searchButton').attr('disabled', 'disabled');
        $('#saveButton').removeAttr('disabled');
    } else {
        $('#searchButton').removeAttr('disabled');
        $('#saveButton').attr('disabled', 'disabled');
    }
});