   $(document).ready(function () {
            dataTable = $("#vehicleTypeTable").DataTable({
                "responsive": true,
                "sDom": "lrtip",
                "bAutoWidth": true,
                'columnDefs': [
                    {
                        "targets": 3,
                        "className": "text-center",
                    }],
                "ajax": {
                    "url": "/VehicleType/GetData",
                    "type": "GET",
                    "datatype": "json"

                },

                "columns": [
                    { "data": "VehicleTypeId" },
                    { "data": "Name" },
                    { "data": "Rate" },
                    {
                        "data": "VehicleTypeId", "render": function (data) {                            
                            return    "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/VehicleType/AddOrEdit/" + data + "', 'Edit Vehicle Type')\">"
                                + "<span class='icon text-white-50'>"
                                + " <i class='fas fa-edit'></i>"
                                + "</span>"
                                + "<span class='text text-white'>Edit</span>"
                                + "</a>"

                                + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/VehicleType/Delete/" + data + "')>"
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