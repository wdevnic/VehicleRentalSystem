
Chart.defaults.global.defaultFontFamily = 'Nunito', '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#858796';



     const getTableData = () => {

         const dataTable = tableSelect.DataTable({
            "responsive": true,
            "sDom": "lrtip",
            "autoWidth": false,
            'columnDefs': [
                {
                    "targets": [7, 9],
                    "className": "text-center"
                },
                {
                    "targets": 8,
                    "visible": false
                }
            ],
            "autoWidth": false,
            "ajax": {
                "url": "/Rentals/GetData",
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
                    "data": "Id", "render": (data, type, row) => {

                        let disable = "";

                        if (row['Returned'] == true) {
                            disable = "disabled";
                        }
                        return `<a class='btn btn-sm btn-success btn-icon-split mr-2 ${disable}'  onclick = "Edit('/Rentals/AddReturn/${data}', 'Process Return')">
                                <span class='icon text-white-50'><i class='fas fa-edit'></i></span>
                                <span class='text text-white'>Return</span>
                            </a>`
                            +
                             `<a class='btn btn-sm btn-info btn-icon-split mr-2' onclick = "Details('/Rentals/Details/${data}')">
                                <span class='icon text-white-50'><i class='fas fa-info-circle'></i></span>
                                <span class='text text-white'>Details</span>
                            </a>`
                            +
                            `<a class='btn btn-sm btn-danger btn-icon-split' onclick = "Delete('/Rentals/Delete/${data}')">
                                <span class='icon text-white-50'><i class='fas fa-trash'></i></span>
                                <span class='text text-white'>Delete</span>
                            </a>`

                    },

                }

            ],

            "language": {
                "emptyTable": "No data found, please click the <b>Add</b> button to add a new record"
            }


        });
    }



    // function that filters overdue rentals
    const filterOverdue = (settings, data) => {

        const endDate = moment(data[4], dateFormat);
        const returned = data[8] == 'true';
        const today = moment(moment(), dateFormat);

        return ((today.diff(endDate, 'days') > 0) && (!returned)) 
    };



   

    // show rental records for todays pickup
    $('#pickup').click(() => { 
        const table = tableSelect.DataTable();
        table
            .column(3)
            .search(moment().format(dateFormat))
            .draw();

        table.columns().search("");
    });

    // show rental records for todays dropoff
    $('#dropoff').click(() => { 
        const table = tableSelect.DataTable();
        table
            .column(4)
            .search(moment().format(dateFormat))
            .draw();
        table.columns().search("");
    });

    // show rental records for overdue returns
    $('#overdue').click(() => {
        const table = tableSelect.DataTable();
        $.fn.dataTable.ext.search.push(filterOverdue);
        table.draw();
        $.fn.dataTable.ext.search.splice($.fn.dataTable.ext.search.indexOf(filterOverdue, 1));
            
    });

    // remove filters put on by dashboard 
    const removeFilter = () => {
        const table = tableSelect.DataTable();
         $.fn.dataTable.ext.search.splice($.fn.dataTable.ext.search.indexOf(filterOverdue, 1));
        table.draw();
    }


        // display car availability chart
    const getBarChartData = () =>{

            $.ajax({
                url: "/Dashboard/CarClassAvailability",
                type: "GET",
                dataType: "json",
                success: (gif) => {
                    const dataT = {
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

                    const ctx = $("#bar_chart").get(0).getContext("2d");
                    const myNewChart = new Chart(ctx, {
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
    const getLineChartData = () => {

        $.ajax({
            url: "/Dashboard/LastSevenDaysRevenue",
            type: "GET",
            dataType: "json",
            success: (gif) => {
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
                                    callback: (value) => ' $' + value
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
                                label: (tooltipItems, data) => " $ " + tooltipItems.yLabel.toString()
                                
                            }
                        }
                    }
                });


            }

        });
    }


    // tooltips
    const initializeToolTips = () => {
        $('[data-toggle="tooltip"]').tooltip();
}

    // load charts and tables
    $(document).ready(() => {
        getTableData();
        getBarChartData();
        getLineChartData();
        initializeToolTips();
    });

      

     