//import * as moment from "moment";

$(document).ready(function () {
    SetDateRangePickerValue();
    InitReturnDate(); 
    ReturnPicker();
    UpdateVehicleModelDropDown();
    NumberOfDaysRented(); 
    SetDefaultRentalDate();   
});

function UpdateVehicleModelDropDown() {
    $("#vehicleTypeDropdown").change(function () {
        $.get("/Rental/FilterByVehicleModelsByType", { vehicleTypeId: $(this).children("option:selected").val() }, function (data) {
            $("#vehicleModelDropdown").empty();
            $.each(data, function (index, row) {
                $("#vehicleModelDropdown").append("<option value='" + row.VehicleModelId + "'>" + row.Name + "</option>")
            });

            $.get("/Rental/FilterByVehiclesByModel", { vehicleModelId: $("#vehicleModelDropdown").children("option:selected").val() }, function (data) {
                $("#vehicleDropdown").empty();
                $.each(data, function (index, row) {
                    $("#vehicleDropdown").append("<option value='" + row.VehicleId + "'>" + row.LicensePlate + "</option>")
                });
            });

            $('#vehicleRateDropdown').val($("#vehicleTypeDropdown").val());
            var rate = $('#vehicleRateDropdown').children(":selected").text();
            $('#vehicle-rate').text(rate);
             PopulateBill();
            
        });
    });
}

function NumberOfDaysRented() {
    $('input[name="daterange"]').daterangepicker({
        opens: 'right'
    }, function (start, end, label) {
        var days = end.diff(start, 'days');
            $('#number-of-days').text(days);
            $('#start-date').val(start.format('YYYY-MM-DD'));
            $('#end-date').val(end.format('YYYY-MM-DD'));
            PopulateBill();                       
    });
}


function PopulateBill() {
    var t = $('#vehicle-rate').text();
    var cost = ($('#number-of-days').text()) * ($('#vehicle-rate').text());
    $('#total-cost').text(cost.toFixed(2));

    if (cost > 0) {
        $('#bill').removeAttr('hidden');
    }    
}



function SetDateRangePickerValue() {
    if ($('#start-date').val() && $('#end-date').val())
    {
        var start = $('#start-date').val();
        var end = $('#end-date').val();

        var startDate = moment(start).format('MM/DD/YYYY');
        var endDate = moment(end).format('MM/DD/YYYY');
        
        var range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);
    }
    else
    {
        var startDate = moment().format('MM/DD/YYYY');       
        var endDate = moment().add(1, 'days').format('MM/DD/YYYY');

        var range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);

        $('#start-date').val(moment(startDate).format('YYYY-MM-DD'));

        $('#end-date').val(moment(endDate).format('YYYY-MM-DD'));
    }
} 

function SetDefaultRentalDate() {

    $('#rental-date').val(moment().format('YYYY-MM-DD'));
    console.log(moment().format('YYYY-MM-DD') + 'DATE');

    $('#rental-date').prop("readonly", true);
    
}


//--------------------------------------------------------------------------------------------------


function ReturnPicker() {

    $('input[name="Return.ReturnDate"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true

    }, function (start, end, label) {
            var endValue = $('#end-date').val();
            var endDate = moment(endValue);
            var days = start.diff(endDate, 'days');
            $('#number-overdue-days').text(days);

            PopulateOverdue();
    });
}

function PopulateOverdue() {
    var t = $('#vehicle-rate').text($('#rate').val());
    var cost = ($('#number-overdue-days').text()) * ($('#vehicle-rate').text());
    $('#overdue-cost').text(cost.toFixed(2));

    if (cost > 0) {
        $('#overdue').removeAttr('hidden');
    }
}

function InitReturnDate() {
    var endValue = $('#end-date').val();
    var endDate = moment(endValue);

    var returnDate = moment();
    var days = returnDate.diff(endDate, 'days');
    $('#number-overdue-days').text(days);
    PopulateOverdue();
}

