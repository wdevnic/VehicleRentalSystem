
const addNumberSel = $('#addPhoneNumber')
const addAddressSel = $("#addAddress")
const addEmailSel = $("#addEmailAddress")
const allNumsSel = $('#allPhoneNumbers')
const allAddressesSel = $('#allAddresses')
const allEmailsSel = $('#allEmailAddresses')

const AddMissingFields = () => {
    if ($('#allPhoneNumbers select').length == 3) {
        addNumberSel.hide();
    }

    if ($('#allPhoneNumbers .phoneRow').length == 0) {
        addNumberSel.click();
    }

    if ($('#allAddresses .addressRow').length == 0) {
        addAddressSel.click();
    }

    if ($('#allEmailAddresses .emailRow').length == 0) {
        addEmailSel.click();
    }
}

const  AddPhoneNumber = () => {
    const list = [];
    $.ajax({
        async: false,
        url: `${location.pathname}/AddNewPhoneNumber`
    }).done((partialView) => {
        allNumsSel.append(partialView);
    });

    $('option', allNumsSel).each(() => {
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
        addNumberSel.hide();
    }

}

    const AddAddress = () => {
        $.ajax({
            async: false,
            url: `${location.pathname}/AddNewAddress`
        }).done((partialView) => {
            allAddressesSel.append(partialView);
        });

    }

    const AddEmail = () => {
        $.ajax({
            async: false,
            url: `${location.pathname}/AddNewEmailAddress`
        }).done((partialView) => {
            allEmailsSel.append(partialView);
        });
}


    $(document).ready(() => {
        AddMissingFields();
    });



