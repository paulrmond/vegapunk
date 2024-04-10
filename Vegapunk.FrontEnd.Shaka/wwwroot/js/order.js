var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    $.ajax({
        url: "/order/GetAllOrder",
        method: "GET",
        success: function (data) {
            // Alert to check the data
            alert("Data received: " + JSON.stringify(data));

            // Initialize DataTable with received data
            dataTable = $('#tblData').DataTable({
                "data": data,
                "columns": [
                    { data: 'orderHeaderId', "width": "5%" },
                    { data: 'email', "width": "25%" },
                    { data: 'name', "width": "20%" },
                    { data: 'phone', "width": "10%" },
                    { data: 'orderStatus', "width": "10%" },
                    { data: 'orderTotal', "width": "10%" },
                    {
                        data: 'orderHeaderId',
                        "render": function (data) {
                            return `<div class="w-75 btn-group" role="group">
                            <a href="/order/orderDetail?orderId=${data}" class="btn btn-primary mx-2">
                            <i class="bi bi-pencil-square"></i></a></div>`
                        },
                        "width": "13%"
                    }
                ]
            });
        },
        error: function (xhr, status, error) {
            // Handle error
            console.error("Error fetching data:", error);
        }
    });
}