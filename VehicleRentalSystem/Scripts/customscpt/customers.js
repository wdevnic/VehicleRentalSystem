   $(document).ready(function () {           
       GenerateCustomerTable();
   });

    function GenerateCustomerTable() {
        dataTable = $("#customerTable").DataTable({
            "responsive": true,
            "sDom": "lrtip",
            "autoWidth": false,
            'columnDefs': [
                {
                    "targets": 7,
                    "className": "text-center",
                }],
            "autoWidth": false,
            "ajax": {
                "url": "/Customer/GetData",
                "type": "GET",
                "datatype": "json"

            },

            "columns": [
                { "data": "Id" },
                { "data": "Title" },
                { "data": "FirstName" },
                { "data": "LastName" },
                { "data": "PhoneNumber" },
                { "data": "EmailAddress" },
                { "data": "Branch" },
                {
                    "data": "Id", "render": function (data) {
                        return "<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = \"Edit('/Customer/AddOrEdit/" + data + "', 'Edit Customer')\">"
                            + "<span class='icon text-white-50'>"
                            + " <i class='fas fa-edit'></i>"
                            + "</span>"
                            + "<span class='text text-white'>Edit</span>"
                            + "</a>"


                            +"<a class='btn btn-sm btn-info btn-icon-split mr-2' onclick = \Details('/Customer/Details/" + data + "')>"
                            + "<span class='icon text-white-50'>"
                            + " <i class='fas fa-info-circle'></i>"
                            + "</span>"
                            + "<span class='text text-white'>Details</span>"
                            + "</a>"
                          

                            + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Customer/Delete/" + data + "')>"
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
    }

    


    function AddPhoneNumber() {
        $.ajax({
            async: false,
            url: '/Customer/AddNewPhoneNumber'
        }).done(function (partialView) {
            $('#allPhoneNumbers').append(partialView);
        });

        var list = new Array();
        $('option', $('#allPhoneNumbers')).each(function () {
            if ($(this).attr('selected') == 'selected') {
                list.push($(this).attr('value'));
            }

        });

        $('option', $('#newPhoneRow')).each(function () {
            if (jQuery.inArray($(this).attr('value'), list) !== -1) {
                $(this).remove();
            }
        });

        if ($('#allPhoneNumbers select').length == 3) {
            $('#addPhoneNumber').hide();
        }
           
    }    
