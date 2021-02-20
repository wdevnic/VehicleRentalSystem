   $(document).ready(function () {
            dataTable = $("#vehicleTable").DataTable({
                "responsive": true,
                "sDom": "lrtip",
                "bAutoWidth": true,
                'columnDefs': [
                    {
                        "targets": [2,5],
                        "className": "text-center",
                    }],
                "ajax": {
                    "url": "/Vehicle/GetData",
                    "type": "GET",
                    "datatype": "json"

                },

                "columns": [
                    { "data": "Id" },
                    { "data": "LicensePlate" },
                    { "data": "IsAvailable", "render": AddCheckbox },
                    { "data": "Branch" },
                    { "data": "VehicleModel" },
                    {
                        "data": "Id", "render": function (data) {
                            return    "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/Vehicle/AddOrEdit/" + data + "', 'Edit Vehicle')\">"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-edit'></i>"
                                + "</span>"
                                + "<span class='text text-white'>Edit</span>"
                                + "</a>"

                                + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Vehicle/Delete/" + data + "')>"
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
                }


            });

       $('#mainSearch').keyup(function () {
           dataTable.search($(this).val()).draw();
       })

      });