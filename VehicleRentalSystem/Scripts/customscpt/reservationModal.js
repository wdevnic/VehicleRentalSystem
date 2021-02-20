$(document).ready(function () {
    SetDateRangePickerValue(); 
    NumberOfDaysRented();
});


function NumberOfDaysRented() {
    $('input[name="daterange"]').daterangepicker({
        opens: 'right'
    }, function (start, end, label) {
        //var days = end.diff(start, 'days');
        //$('#number-of-days').text(days);
        $('#start-date').val(start.format('YYYY-MM-DD'));
        $('#end-date').val(end.format('YYYY-MM-DD'));
        //PopulateBill();
    });
}


function SetDateRangePickerValue() {
    if ($('#start-date').val() && $('#end-date').val()) {
        var start = $('#start-date').val();
        var end = $('#end-date').val();

        var startDate = moment(start).format('MM/DD/YYYY');
        var endDate = moment(end).format('MM/DD/YYYY');

        var range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);
    }
    else {
        var startDate = moment().format('MM/DD/YYYY');
        var endDate = moment().add(1, 'days').format('MM/DD/YYYY');

        var range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);

        $('#start-date').val(moment(startDate).format('YYYY-MM-DD'));

        $('#end-date').val(moment(endDate).format('YYYY-MM-DD'));
    }
} 

