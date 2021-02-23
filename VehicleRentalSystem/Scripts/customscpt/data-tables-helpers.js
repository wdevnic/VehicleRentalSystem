
const loadTable = () => {
    dataTable = $("#table").DataTable({
        "responsive": true,
        "autoWidth": false,
        "sDom": "lrtip",
        'columnDefs': columnDef,
        "ajax": {
            "url": `${location.pathname}/GetData`,
            "type": "GET",
            "datatype": "json"

        },
        "columns": columns,
        "language": {
            "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
        },
    });

    $('#mainSearch').keyup(function () {
        dataTable.search($(this).val()).draw();
    })

    console.dir(location)

}

const formatDate = (data) => {
    return (moment(data).isValid()) ? moment(data).format("DD/MM/YYYY") : "-";
}

const AddCheckbox = (data) => {
    if (data === true) {
        return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
    } else {
        return '<input type="checkbox" onclick="return false;" class="editor-active">';
    }
    return data;
}





