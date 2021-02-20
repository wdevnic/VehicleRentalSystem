$(document).ready(function () {
    dataTable = $("#branchTable").DataTable({
        "responsive": true,
        "autoWidth": false,
        "sDom": "lrtip",
        'columnDefs': [
            {
                "targets": 6,
                "className": "text-center",
            }],
        "ajax": {
            "url": "/Branch/GetData",
            "type": "GET",
            "datatype": "json"

        },

        "columns": [
            { "data":  "Id"},
            { "data": "Name" },
            { "data": "AddressLine1" }, 
            { "data": "AddressLine2" }, 
            { "data": "City" }, 
            { "data": "PostalCode" }, 
            {
                "data": "Id", "render": function (data) {
                    return    "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/Branch/AddOrEdit/" + data + "', 'Edit Branch')\">"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-edit'></i>"
                                + "</span>"
                        + "<span class='text text-white'>Edit</span>"
                               + "</a>"

                        + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Branch/Delete/" + data + "')>"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-trash'></i>"
                                + "</span>"
                        + "<span class='text text-white'>Delete</span>"
                               + "</a>"
                }
                
            }

        ],
        "language": {
            "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
        },

    });

     
    $('#mainSearch').keyup(function () {
        dataTable.search($(this).val()).draw();
    })

});