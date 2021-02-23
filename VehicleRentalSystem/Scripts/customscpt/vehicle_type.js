const renderButtons = (data) => {

    return `<a class='btn btn-sm btn-success btn-icon-split mr-2' onclick = "Edit('${location.hostname}/AddOrEdit/${data}', 'Edit Vehicle Type')">
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
    { "data": "VehicleTypeId" },
    { "data": "Name" },
    { "data": "Rate" },
    { "data": "VehicleTypeId", "render": renderButtons }
]


const columnDef = [
    {
        "targets": 3,
        "className": "text-center",
    }]

$(document).ready(loadTable);
