const renderButtons = (data) => {
    return `<a class='btn btn-primary btn-xs' onclick = "Edit('${location.pathname}/AddOrEdit/${data}', 'Edit Rate')" >
                <span class='icon text-white-50'> <i class='fa fa - edit'></i> </span>
                <span class='text text-white'>Edit</span>
            </a>`
            +
            `<a class='btn btn - primary btn - xs' onclick= "Delete('${location.pathname}/Delete/${data}')"> 
                 <span class='icon text-white-50'><i class='fa fa - trash'></i ></span> 
                <span class='text text-white></span>Delete
             </a>`
            +
            `<a class='btn btn - primary btn - xs' onclick= "Details('${location.pathname}/Details/${data}')">
                <span class='icon text-white-50'><i class='fa fa - edit'></i></span>
                <span>Details</span>
            </a>`
}

const columnDef = [
    {
        "targets": 2,
        "className": "text-center",
        "width": "34%"
    },
    {
        "targets": 1,
        "width": "33%"
    },
    {
        "targets": 0,
        "width": "33%"
    }]


const columns = [
    { "data": "Id" },
    { "data": "RentalRate" },
    { "data": "Id", "render": renderButtons}
]

$(document).ready(loadTable);

