   $(document).ready(function () {
            dataTable = $("#vehicleManufacturerTable").DataTable({
                "responsive": true,
                "sDom": "lrtip",
                "bAutoWidth": true,
                'columnDefs': [
                    {
                        "targets": 2,
                        "className": "text-center",
                    }],
                "ajax": {
                    "url": "/VehicleManufacturer/GetData",
                    "type": "GET",
                    "datatype": "json"

                },

                "columns": [
                    { "data": "VehicleManufacturerId" },
                    { "data":  "Name"},
                    {
                        "data": "VehicleManufacturerId", "render": function (data) {
                            return    "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/VehicleManufacturer/AddOrEdit/" + data + "', 'Edit Manufacturer')\">"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-edit'></i>"
                                + "</span>"
                                + "<span class='text text-white'>Edit</span>"
                                + "</a>"

                                + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/VehicleManufacturer/Delete/" + data + "')>"
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