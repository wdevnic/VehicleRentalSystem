   $(document).ready(function () {
            dataTable = $("#vehicleModelTable").DataTable({
                "responsive": true,
                "sDom": "lrtip",
                "bAutoWidth": true,
                'columnDefs': [
                    {
                        "targets": [6, 7],
                        "className": "text-center",
                    }],
                "ajax": {
                    "url": "/VehicleModel/GetData",
                    "type": "GET",
                    "datatype": "json"

                },

                "columns": [
                    { "data": "Id" },
                    { "data": "Name" },
                    { "data": "SeatingCapacity" },
                    { "data": "BaggageCapacity" },
                    { "data": "VehicleManufacturer" },
                    { "data": "VehicleType" },
                    { "data": "Automatic", "render": AddCheckbox },
                    {
                        "data": "Id", "render": function (data) {
                           
                            
                            return    "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/VehicleModel/AddOrEdit/" + data + "', 'Edit Vehicle Model')\">"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-edit'></i>"
                                + "</span>"
                                + "<span class='text text-white'>Edit</span>"
                                + "</a>"

                                + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/VehicleModel/Delete/" + data + "')>"
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