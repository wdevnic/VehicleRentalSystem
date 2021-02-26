
const UpdateVehicleModelDropDown= () => {
    $("#vehicleTypeDropdown").change(function(){
        $.get("/Rentals/FilterByVehicleModelsByType", { vehicleTypeId: $(this).children("option:selected").val() }, (data) => {
            $("#vehicleModelDropdown").empty();
            $.each(data, (index, row) => {
                $("#vehicleModelDropdown").append("<option value='" + row.VehicleModelId + "'>" + row.Name + "</option>")
            });

            $.get("/Rentals/FilterByVehiclesByModel", { vehicleModelId: $("#vehicleModelDropdown").children("option:selected").val() }, (data) => {
                $("#vehicleDropdown").empty();
                $.each(data, (index, row) => {
                    $("#vehicleDropdown").append("<option value='" + row.VehicleId + "'>" + row.LicensePlate + "</option>")
                });
            });

            $('#vehicleRateDropdown').val($("#vehicleTypeDropdown").val());
            const rate = $('#vehicleRateDropdown').children(":selected").text();
            $('#vehicle-rate').text(rate);
             PopulateBill();
            
        });
    });
}

const NumberOfDaysRented = () => {
    $('input[name="daterange"]').daterangepicker({
        opens: 'right'
    }, (start, end, label) => {
        const days = end.diff(start, 'days');
            $('#number-of-days').text(days);
            $('#start-date').val(start.format('YYYY-MM-DD'));
            $('#end-date').val(end.format('YYYY-MM-DD'));
            PopulateBill();                       
    });
}


const PopulateBill = () => {
    const cost = ($('#number-of-days').text()) * ($('#vehicle-rate').text());
    $('#total-cost').text(cost.toFixed(2));

    if (cost > 0) {
        $('#bill').removeAttr('hidden');
    }    
}



const SetDateRangePickerValue = () => {
    if ($('#start-date').val() && $('#end-date').val())
    {
        const start = $('#start-date').val();
        const end = $('#end-date').val();
        const startDate = moment(start).format('MM/DD/YYYY');
        const endDate = moment(end).format('MM/DD/YYYY');
        
        const range = startDate + ' - ' + endDate;
        $('#rental-range').attr('value', range);
    }
    else
    {
        const startDate = moment().format('MM/DD/YYYY');       
        const endDate = moment().add(1, 'days').format('MM/DD/YYYY');
        const range = startDate + ' - ' + endDate;

        $('#rental-range').attr('value', range);
        $('#start-date').val(moment(startDate).format('YYYY-MM-DD'));
        $('#end-date').val(moment(endDate).format('YYYY-MM-DD'));
    }
} 

const SetDefaultRentalDate = () => {

    $('#rental-date').val(moment().format('YYYY-MM-DD'));
    $('#rental-date').prop("readonly", true);
    
}


const ReturnPicker = () => {

    $('input[name="Return.ReturnDate"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true

    }, function (start, end, label) {
            const endValue = $('#end-date').val();
            const endDate = moment(endValue);

            const days = start.diff(endDate, 'days');
            $('#number-overdue-days').text(days);

            PopulateOverdue();
    });
}

const PopulateOverdue= () => {
    const cost = ($('#number-overdue-days').text()) * ($('#vehicle-rate').text());
    $('#overdue-cost').text(cost.toFixed(2));

    if (cost > 0) {
        $('#overdue').removeAttr('hidden');
    }
}

const InitReturnDate = () => {
    const endValue = $('#end-date').val();
    const endDate = moment(endValue);

    const days = moment().diff(endDate, 'days');
    $('#number-overdue-days').text(days);
    PopulateOverdue();
}

    $(document).ready(() => {
        SetDateRangePickerValue();
        InitReturnDate();
        ReturnPicker();
        UpdateVehicleModelDropDown();
        NumberOfDaysRented();
        SetDefaultRentalDate();
    });


