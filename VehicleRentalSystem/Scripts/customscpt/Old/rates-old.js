$(document).ready(function () {
    dataTable = $("#ratesTable").DataTable({
        "responsive": true,
        'columnDefs': [
            {
                "targets": 2,
                "className": "text-center",
                "width": "34%"
            },
            {
                "targets": 1,               
                "width": "33%"
            },
            {
                "targets": 0,                
                "width": "33%"
            }],
        "autoWidth": false,
        "ajax": {
            "url": "/VehicleRates/GetData",
            "type": "GET",
            "datatype": "json"

        },

        "columns": [
            { "data":  "Id"},
            { "data":  "RentalRate"},                   
            {
                "data": "Id", "render": function (data) {
                    return "<a class='btn btn-primary btn-xs' onclick = \"Edit('/VehicleRates/AddOrEdit/"+ data +"', 'Edit Rate')\" > <i class='fa fa-edit'></i> Edit</a><a class='btn btn-primary btn-xs' onclick = \"Delete('/VehicleRates/Delete/" + data + "')\" > <i class='fa fa-trash'></i> Delete</a><a class='btn btn-primary btn-xs' onclick = Details('/VehicleRates/Details/" + data + "') > <i class='fa fa-edit'></i> Details</a>"
                 
                }
                
            }

        ],

        "language": {
            "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
        }


        });

});