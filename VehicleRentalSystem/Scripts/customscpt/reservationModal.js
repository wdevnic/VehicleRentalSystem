
const NumberOfDaysRented = () => {
    $('input[name="daterange"]').daterangepicker({
        opens: 'right'
    },  (start, end, label) => {
        $('#start-date').val(start.format('YYYY-MM-DD'));
        $('#end-date').val(end.format('YYYY-MM-DD'));
    });
}


const SetDateRangePickerValue = () => {

    const startDate, endDate, range 

    if ($('#start-date').val() && $('#end-date').val()) {
        const start = $('#start-date').val();
        const end = $('#end-date').val();
        startDate = moment(start).format('MM/DD/YYYY');
        endDate = moment(end).format('MM/DD/YYYY');

        range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);
    }
    else {
        startDate = moment().format('MM/DD/YYYY');
        endDate = moment().add(1, 'days').format('MM/DD/YYYY');
        range = startDate + ' - ' + endDate;

        $('#rental-range').attr('value', range);
        $('#start-date').val(moment(startDate).format('YYYY-MM-DD'));
        $('#end-date').val(moment(endDate).format('YYYY-MM-DD'));
    }
} 

$(document).ready(() => {
    SetDateRangePickerValue();
    NumberOfDaysRented();
});


