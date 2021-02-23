const renderButtons = (data) => {

    return `<a  class='btn btn-sm btn-success btn-icon-split mr-2' onclick = "Edit('${location.pathname}/AddOrEdit/${data}', 'Edit Manufacturer')">
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
    { "data": "VehicleManufacturerId" },
    { "data": "Name" },
    { "data": "VehicleManufacturerId", "render": renderButtons }
]


const columnDef = [
    {
        "targets": 2,
        "className": "text-center",
    }]


$(document).ready(loadTable);
