var CustomersAdminController = function ($scope, $compile, $templateCache) {
    // TODO: Figure out key for '/CustomersAdmin/Edit/*' pages 
    // and use $templateCache.remove('key'); instead.
    $templateCache.removeAll();

    // Load the datatable from the REST api.
    $("#customers").DataTable({
        ajax: {
            url: "http://" + location.host + "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return '<a href="/CustomersAdmin/Edit/' + customer.id + '">' + customer.name + '</a>';
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    // Watch the delete button.
    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);

        if (confirm("Are you sure you want to delete this customer?")) {
            $.ajax({
                url: "../api/customers/" + button.attr("data-customer-id"),
                method: "DELETE",
                success: function () {
                    button.parents("tr").remove();
                }
            });
        }
    });
}

CustomersAdminController.$inject = ['$scope', '$compile', '$templateCache'];
