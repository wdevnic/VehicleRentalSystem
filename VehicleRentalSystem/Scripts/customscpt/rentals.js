const renderButtons = (data, type, row) => {
    let disable = "";

    if (row['Returned'] == true) {
        disable = "disabled";
    }

    return `<a class='btn btn-sm btn-success btn-icon-split mr-2 ${disable} onclick = "Edit('${location.pathname}/AddReturn/${data}', 'Process Return')">
                <span class='icon text-white-50'><i class='fas fa-edit'></i></span>
                <span class='text text-white'>Return</span>
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
    { "data": "RentalDate", "render": formatDate },
    { "data": "CustomerName" },
    { "data": "StartDate", "render": formatDate },
    { "data": "EndDate", "render": formatDate },
    { "data": "PickUpLocation" },
    { "data": "DropOffLocation" },
    { "data": "Returned", "render": AddCheckbox },
    { "data": "Id", "render": renderButtons}
]


const columnDef = [
    {
        "targets": [7, 8],
        "className": "text-center"
    }]


$(document).ready(loadTable);

