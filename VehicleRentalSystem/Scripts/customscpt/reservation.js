const renderButtons = (data) => {

    return `<a class='btn btn-sm btn-danger btn-icon-split' onclick = "Delete('${location.pathname}/Delete/${data}')">
                <span class='icon text-white-50'><i class='fas fa-trash'></i></span>
                <span class='text text-white'>Delete</span>
            </a>`
}


const columns = [
    { "data": "Id" },
    { "data": "ReservationDate", "render": formatDate },
    { "data": "CustomerName" },
    { "data": "StartDate", "render": formatDate },
    { "data": "EndDate", "render": formatDate },
    { "data": "NumberOfDaysReserved" },
    { "data": "PickUpLocation" },
    { "data": "DropOffLocation" },
    {"data": "Id", "render": renderButtons}]


const columnDef = [
            {
                "targets": [5, 8],
                "className": "text-center",
            }]
    

$(document).ready(loadTable);
