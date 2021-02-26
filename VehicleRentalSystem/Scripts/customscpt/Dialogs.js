
// called when user click on the add button in the action column for the respective data table
const Add = (url) => { // url is the Get action url for the rentals controller
    $.get(url)
        .done((response) => { // gets add form 
            $("#modalContainer").html(response);  // add form data to bootstrap modal container on index page
            $('#addOrEditModal').modal('toggle'); // display Add Modal 
        }); 
} 

// called when user click on the edit button in the action column for the respective data table
const Edit = (url, modalTitle) => {
    $.get(url)
        .done((response) => { // gets edit form 
            $("#modalContainer").html(response); // form data to bootstrap modal container on index page
            $('#addOrEditModalLabel').html(modalTitle);
            $('#addOrEditModal').modal('toggle'); // display Add Modal 
        })
}

// on submit respective form
const SubmitForm= (form) => {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action, //get respective url
            data: $(form).serialize(),
            success: (data) => {
                if (data.success) {
                    $("#close").click(); // close form
                    $('#add').trigger("reset"); // reset form
                    dataTable.ajax.reload(); // reload datatable with updated data
                    $.notify(data.message, { // display notification message 
                        globalPosition: "top-center",
                        className: "success"
                    })
                }
            }

        });
    }
    return false;
}

// called when user click on the delete button in the action column for the respective data table
const Delete = (url) => {
    $('#delete').modal('show'); // show delete modal
    $("#deleteButton").click(() => { // on delete
        $.ajax({ // ajax call to delete action
            type: "POST",
            url: url, 
            success: (data) => {
                if (data.success) {
                    dataTable.ajax.reload(); // reload datatable
                    $.notify(data.message, { // display notification message
                        globalPosition: "top-center",
                        className: "success"
                    })

                }
            }
        });
        $('#delete').modal('toggle'); // hide method
        $("#deleteButton").off("click"); // unclick the delete button to set it to default

    })
    return false;
}

// called when user click on the details button in the action column for the respective data table
const Details = (url) => {
    $.get(url) // get modal details 
        .done((response) => {
            $("#modalContainer").html(response); // add modal to container
            $('#details').modal('toggle'); // show modal
        })
}


// called when user click on the edit button in the action column for the respective rental data table
const SubmitEditForm = (form) => {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        $.ajax({
            type: "POST",
            url: form.action,
            data: $(form).serialize(),
            success: (data) => {
                if (data.success) {
                    $("#close").click();
                    $('#edit').trigger("reset");
                    dataTable.ajax.reload();
                    $.notify(data.message, {
                        globalPosition: "top-center",
                        className: "success"
                    })
                }
            }

        });
    }
    return false;
}

// called when user click on the delete button in the action column for the respective data table
const DeleteItem = (url, element) => {
    $.ajax({ // ajax call to delete action
            type: "POST",
            url: url,
            success: function (data) {
                if (data.success) {
                    $(element).parent('div').parent('div').remove();
                }
            }
        });

    return false;
}

// called when user click on the delete button in the action column for the respective data table
const DeleteHtmlItem = (element) =>
{
    {
        $(element).parent('div').parent('div').remove();
    }
    return false;
}

