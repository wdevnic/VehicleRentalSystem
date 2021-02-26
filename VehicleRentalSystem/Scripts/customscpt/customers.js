const renderButtons = (data) => {
    return `<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = "Edit('${location.pathname}/AddOrEdit/${data}', 'Edit Customer')">
                <span class='icon text-white-50'><i class='fas fa-edit'></i></span>
                <span class='text text-white'>Edit</span>
            </a>`

            +
            `<a class='btn btn-sm btn-info btn-icon-split mr-2' onclick = "Details('${location.pathname}/Details/${data}')">
                <span class='icon text-white-50'><i class='fas fa-info-circle'></i></span>
                <span class='text text-white'>Details</span>
            </a>`

            +
            `<a class='btn btn-sm btn-danger btn-icon-split' onclick = "Delete('${location.pathname}/Delete/${data}')">
                <span class='icon text-white-50'><i class='fas fa-trash'></i></span>
                <span class='text text-white'>Delete</span>
            </a>`
    }

const columns = [
    { "data": "Id" },
    { "data": "Title" },
    { "data": "FirstName" },
    { "data": "LastName" },
    { "data": "PhoneNumber" },
    { "data": "EmailAddress" },
    { "data": "Branch" },
    { "data": "Id", "render": renderButtons }]

const columnDef = [
    {
        "targets": 7,
        "className": "text-center",
    }]


$(document).ready(loadTable);
