
$(document).ready(function () {
    dataTable = $("#rentalTable").DataTable({
        "responsive": true,
        "sDom": "lrtip",
        "autoWidth": false,
        'columnDefs': [
            {
                "targets": [7,8],
                "className": "text-center"
            }
        ],
        "autoWidth": false,
        "ajax": {
            "url": "/Rental/GetData",
            "type": "GET",
            "datatype": "json"

        },

        "columns": [
            { "data": "Id" },
            { "data": "RentalDate", "render": formatDate },
            { "data": "CustomerName" },        
            { "data": "StartDate", "render": formatDate },
            { "data": "EndDate", "render": formatDate  },
            { "data": "PickUpLocation" },
            { "data": "DropOffLocation" },
            { "data": "Returned", "render": AddCheckbox },
            {                
                "data": "Id", "render": function (data, type, row) {

                    var disable = "";

                    if (row['Returned'] == true) {
                        disable = "disabled";
                    }
                  
                    return "<a  class='btn btn-sm btn-success btn-icon-split mr-2 " + disable + "\'  onclick = \"Edit('/Rental/AddReturn/" + data + "', 'Process Return')\">"
                        + "<span class='icon text-white-50'>"
                        + " <i class='fas fa-edit'></i>"
                        + "</span>"
                        + "<span class='text text-white'>Return</span>"
                        + "</a>"

                        + "<a class='btn btn-sm btn-info btn-icon-split mr-2' onclick = \Details('/Rental/Details/" + data + "')>"
                        + "<span class='icon text-white-50'>"
                        + " <i class='fas fa-info-circle'></i>"
                        + "</span>"
                        + "<span class='text text-white'>Details</span>"
                        + "</a>"

                        + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Rental/Delete/" + data + "')>"
                        + "<span class='icon text-white-50'>"
                        + " <i class='fas fa-trash'></i>"
                        + "</span>"
                        + "<span class='text text-white'>Delete</span>"
                        + "</a>"
                },
              
            }

        ],

        "language": {
            "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
        }


    });

    $('#mainSearch').keyup(function () {
        dataTable.search($(this).val()).draw();
    })

});

function formatDate(data) {
    return (moment(data).isValid()) ? moment(data).format("DD/MM/YYYY") : "-";
}