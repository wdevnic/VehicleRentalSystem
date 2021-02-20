
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';
var popupForm, dataTable;

// function that filters overdue rentals
var myFilterFunction = function (settings, data, dataIndex) {
    var endDate = moment(data[4], "DD/MM/YYYY");
    var returned = data[8] == 'true';

    var today = moment();
    var today2 = moment(today, "DD/MM/YYYY");

    if ((today2.diff(endDate, 'days') > 0) && (!returned)) {
        return true;
    }
    return false;
};



    // load charts and tables
    $(document).ready(function () { 
        getTableData();
        getBarChartData();
        getLineChartData();
        initializeToolTips();
    });

    // show rental records for todays pickup
    $('#pickup').click(function () { 
        var table = $('#rentalTable').DataTable();
        table
            .column(3)
            .search(moment().format("DD/MM/YYYY"))
            .draw();

        table.columns().search("");
    });

    // show rental records for todays dropoff
    $('#dropoff').click(function () { 
        var table = $('#rentalTable').DataTable();
        table
            .column(4)
            .search(moment().format("DD/MM/YYYY"))
            .draw();
        table.columns().search("");
    });

    // show rental records for overdue returns
    $('#overdue').click(function () {
        var table = $('#rentalTable').DataTable();
        $.fn.dataTable.ext.search.push(myFilterFunction);
        table.draw();
        $.fn.dataTable.ext.search.splice($.fn.dataTable.ext.search.indexOf(myFilterFunction, 1));
            
    });

    // remove filters put on by dashboard 
    function RemoveFilter() {
        var table = $('#rentalTable').DataTable();
         $.fn.dataTable.ext.search.splice($.fn.dataTable.ext.search.indexOf(myFilterFunction, 1));
        table.draw();
    }


        // display datatable
    function getTableData() {

        dataTable = $("#rentalTable").DataTable({
            "responsive": true,
            "sDom": "lrtip",
            "autoWidth": false,
            'columnDefs': [
                {
                    "targets": [7,9],
                    "className": "text-center"
                },
                {
                    "targets": 8,
                    "visible": false
                }
            ],
            "autoWidth": false,
            "ajax": {
                "url": "/Rental/GetData",
                "type": "GET",
                "datatype": "json"

            },

            "columns": [
                { "data": "Id" },
                { "data": "RentalDate", "render": formatDate },
                { "data": "CustomerName" },
                { "data": "StartDate", "render": formatDate },
                { "data": "EndDate", "render": formatDate },
                { "data": "PickUpLocation" },
                { "data": "DropOffLocation" },
                { "data": "Returned", "render": AddCheckbox },
                { "data": "Returned" },
                {
                    "data": "Id", "render": function (data, type, row) {

                        var disable = "";

                        if (row['Returned'] == true) {
                            disable = "disabled";
                        }

                        return "<a  class='btn btn-sm btn-success btn-icon-split mr-2 " + disable + "\'  onclick = \"Edit('/Rental/AddReturn/" + data + "', 'Process Return')\">"
                            + "<span class='icon text-white-50'>"
                            + " <i class='fas fa-edit'></i>"
                            + "</span>"
                            + "<span class='text text-white'>Return</span>"
                            + "</a>"

                            + "<a class='btn btn-sm btn-info btn-icon-split mr-2' onclick = \Details('/Rental/Details/" + data + "')>"
                            + "<span class='icon text-white-50'>"
                            + " <i class='fas fa-info-circle'></i>"
                            + "</span>"
                            + "<span class='text text-white'>Details</span>"
                            + "</a>"

                            + "<a class='btn btn-sm btn-danger btn-icon-split' onclick = \Delete('/Rental/Delete/" + data + "')>"
                            + "<span class='icon text-white-50'>"
                            + " <i class='fas fa-trash'></i>"
                            + "</span>"
                            + "<span class='text text-white'>Delete</span>"
                            + "</a>"
                    },

                }

            ],

            "language": {
                "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
            }


        });
    }

    // allow search bar to search dat table
    $('#mainSearch').keyup(function () {
        dataTable.search($(this).val()).draw();
    })

    // format date
    function formatDate(data) {
        return (moment(data).isValid()) ? moment(data).format("DD/MM/YYYY") : "-";
    }

    // display car availability chart
    function getBarChartData() {

        $.ajax({
            url: "/Dashboard/CarClassAvailability",
            type: "GET",
            dataType: "json",
            success: function (gif) {
                var dataT = {
                    labels: gif.data.category,
                    datasets: [{
                        label: "Vehicles ",
                        barThickness: 30,
                        data: gif.data.count,
                        fill: false,
                        backgroundColor: "#4e73df",
                        hoverBackgroundColor: "#2e59d9",
                        borderColor: "#4e73df"
                    }]
                };

                var ctx = $("#bar_chart").get(0).getContext("2d");
                var myNewChart = new Chart(ctx, {
                    type: 'bar',
                    data: dataT,
                    options: {
                        maintainAspectRatio: false,
                        layout: {
                            padding: {
                                left: 10,
                                right: 25,
                                top: 25,
                                bottom: 0
                            }
                        },
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true,
                                    stepSize: 1
                                }
                            }]
                        },
                        legend: {display: false}
                    }
                })




            }
        });
    }

    // display revenue chart
    function getLineChartData() {

        $.ajax({
            url: "/Dashboard/LastSevenDaysRevenue",
            type: "GET",
            dataType: "json",
            success: function (gif) {
                let start = new Date(),
                    end = new Date();

                start.setDate(start.getDate() - 6); // set to 'now' minus 7 days.
                start.setHours(0, 0, 0, 0); // set to midnight.

                new Chart(document.getElementById("line_chart"), {
                    type: "line",
                    data: {
                        labels: gif.data.dates,
                        datasets: [{
                            data: gif.data.revenueValues,
                            backgroundColor: 'rgba(51, 153, 255, 0.3)',
                            borderColor: 'rgba(0, 51, 102, 1)',
                            pointBackgroundColor: 'rgba(204, 204, 204, 1)',
                            pointRadius: 5


                        }]
                    },
                    options: {
                        maintainAspectRatio: false,
                        layout: {
                            padding: {
                                left: 10,
                                right: 25,
                                top: 25,
                                bottom: 0
                            },                              
                        },
                        scales: {
                            yAxes: [{
                                ticks: {
                                    callback: function (value) {
                                        return ' $' + value;
                                    }
                                }
                            }],
                            xAxes: [{
                                type: "time",
                                time: {
                                    min: start,
                                    max: end,
                                    unit: "day",
                                    tooltipFormat: 'DD/MM/YYYY'
                                },

                            }]
                        },
                        legend: { display: false },
                        tooltips: {
                            callbacks: {
                                label: function (tooltipItems, data) {
                                    return " $ " + tooltipItems.yLabel.toString();
                                }
                            }
                        }
                    }
                });


            }

        });
    }

        // format date
    function formatDate(data) {
        return (moment(data).isValid()) ? moment(data).format("DD/MM/YYYY") : "-";
    }

    // tooltips
    function initializeToolTips() {
        $('[data-toggle="tooltip"]').tooltip();
    }

      

     