var table;

$(document).ready(function () {
    $.fn.dataTable.moment("DD/MM/YYYY HH:mm:ss");
    $.fn.dataTable.moment("DD/MM/YYYY");

    table = $("#Table_Datatable").DataTable({
        // Design Assets
        stateSave: true,
        autoWidth: true,
        // ServerSide Setups
        processing: false,
        serverSide: false,
        // Paging Setups
        paging: true,
        lengthMenu: [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "All"]],
        pageLength: 10,
        pagingType: "full_numbers",
        // Custom Export Buttons
        //dom: 'lBfrtip',
        //buttons: [
        //    {
        //        text: 'Excel',
        //        action: function () {
        //            exportToExcel();
        //        }
        //    },
        //    {
        //        text: 'CSV',
        //        action: function () {
        //            exportToCsv();
        //        }
        //    },
        //    {
        //        text: 'HTML',
        //        action: function () {
        //            exportToHtml();
        //        }
        //    },
        //    {
        //        text: 'JSON',
        //        action: function () {
        //            exportToJson();
        //        }
        //    },
        //    {
        //        text: 'XML',
        //        action: function () {
        //            exportToXml();
        //        }
        //    },
        //    {
        //        text: 'YAML',
        //        action: function () {
        //            exportToYaml();
        //        }
        //    }
        //],
        // Searching Setups
        searching: { regex: true },
        // Ajax Filter
        //ajax: {
        //    url: "/TestRegisters/LoadTable",
        //    type: "POST",
        //    contentType: "application/json",
        //    dataType: "json",
        //    data: function (d) {
        //        return JSON.stringify(d);
        //    }
        //},
        // Columns Setups
        //columns: [
        //    { data: "id" },
        //    { data: "name" },
        //    { data: "firstSurname" },
        //    { data: "secondSurname" },
        //    { data: "street" },
        //    { data: "phone" },
        //    { data: "zipCode" },
        //    { data: "country" },
        //    { data: "notes" },
        //    {
        //        data: "creationDate",
        //        render: function (data, type, row) {
        //            // If display or filter data is requested, format the date
        //            if (type === "display" || type === "filter") {
        //                return moment(data).format("ddd DD/MM/YYYY HH:mm:ss");
        //            }
        //            // Otherwise the data type requested (`type`) is type detection or
        //            // sorting data, for which we want to use the raw date value, so just return
        //            // that, unaltered
        //            return data;
        //        }
        //    }
        //],
        // Column Definitions
        //columnDefs: [
        //    { targets: "no-sort", orderable: false },
        //    { targets: "no-search", searchable: false },
        //    {
        //        targets: "trim",
        //        render: function (data, type, full, meta) {
        //            if (type === "display") {
        //                data = strtrunc(data, 10);
        //            }

        //            return data;
        //        }
        //    },
        //    { targets: "date-type", type: "date-eu" },
        //    {
        //        targets: 10,
        //        data: null,
        //        defaultContent: "<a class='btn btn-link' role='button' href='#' onclick='edit(this)'>Edit</a>",
        //        orderable: false
        //    },
        //]
    });
});