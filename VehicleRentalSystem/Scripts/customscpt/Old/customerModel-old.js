$(document).ready(function () {
    AddMissingFields();
});


function AddMissingFields() {
    if ($('#allPhoneNumbers select').length == 3) {
        $('#addPhoneNumber').hide();
    }


    if ($('#allPhoneNumbers .phoneRow').length == 0) {
        $("#addPhoneNumber").click();
    }

    if ($('#allAddresses .addressRow').length == 0) {
        $("#addAddress").click();
    }

    if ($('#allEmailAddresses .emailRow').length == 0) {
        $("#addEmailAddress").click();
    }
}

function AddPhoneNumber() {
    $.ajax({
        async: false,
        url: '/Customers/AddNewPhoneNumber'
    }).done(function (partialView) {
        $('#allPhoneNumbers').append(partialView);
    });

    var list = new Array();
    $('option', $('#allPhoneNumbers')).each(function () {
        if ($(this).attr('selected') == 'selected') {
            list.push($(this).attr('value'));
        }

    });

    $('option', $('#newPhoneRow')).each(function () {
        if (jQuery.inArray($(this).attr('value'), list) !== -1) {
            $(this).remove();
        }
    });

    if ($('#allPhoneNumbers select').length == 3) {
        $('#addPhoneNumber').hide();
    }

}

    function AddAddress() {
        $.ajax({
            async: false,
            url: '/Customers/AddNewAddress'
        }).done(function (partialView) {
            $('#allAddresses').append(partialView);
        });

    }

    function AddEmail() {
        $.ajax({
            async: false,
            url: '/Customers/AddNewEmailAddress'
        }).done(function (partialView) {
            $('#allEmailAddresses').append(partialView);
        });
    }

