const renderButtons = (data) => {
    return `<a class='btn btn-sm btn-success btn-icon-split mr-2' onclick = "Edit('${location.pathname}/AddOrEdit/${data}', 'Edit Vehicle Model')">
                <span class='icon text-white-50'><i class='fas fa-edit'></i></span>
                <span class='text text-white'>Edit</span>
            </a>`
            +
            `<a class='btn btn-sm btn-danger btn-icon-split' onclick = "Delete('${location.pathname}/Delete/${data}')">
                <span class='icon text-white-50'><i class='fas fa-trash'></i></span>
                <span class='text text-white'>Delete</span>
            </a>`
}


const columns = [
    { "data": "Id" },
    { "data": "Name" },
    { "data": "SeatingCapacity" },
    { "data": "BaggageCapacity" },
    { "data": "VehicleManufacturer" },
    { "data": "VehicleType" },
    { "data": "Automatic", "render": AddCheckbox },
    { "data": "Id", "render": renderButtons }
]


const columnDef = [
    {
        "targets": [6, 7],
        "className": "text-center",
    }]


$(document).ready(loadTable);

