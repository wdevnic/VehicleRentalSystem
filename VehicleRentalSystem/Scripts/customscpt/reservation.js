   $(document).ready(function () {
            dataTable = $("#reservationTable").DataTable({
                "responsive": true,
                "sDom": "lrtip",
                "autoWidth": false,
                'columnDefs': [
                    {
                        "targets": [5, 8],
                        "className": "text-center",
                    }],
                "autoWidth": false,
                "ajax": {
                    "url": "/Reservation/GetData",
                    "type": "GET",
                    "datatype": "json"

                },

                "columns": [
                    { "data": "Id" },                   
                    { "data": "ReservationDate", "render": formatDate },
                    { "data": "CustomerName" },
                    { "data": "StartDate", "render": formatDate},
                    { "data": "EndDate", "render": formatDate},
                    { "data":  "NumberOfDaysReserved"},
                    { "data":  "PickUpLocation"},
                    { "data":  "DropOffLocation"},
                    {
                        "data": "Id", "render": function (data) {

                            return "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Reservation/Delete/" + data + "')>"
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

function formatDate(data) {
    return (moment(data).isValid()) ? moment(data).format("DD/MM/YYYY") : "-";
}