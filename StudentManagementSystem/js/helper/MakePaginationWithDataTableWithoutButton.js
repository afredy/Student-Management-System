var MakePaginationWithDataTableWithoutButton = function (tableId, rows) {

    if ($.fn.DataTable.isDataTable('#' + tableId)) {
        $('#' + tableId).DataTable().clear().destroy();
    }

    $('#' + tableId + ' tbody').append(rows);
    $('#' + tableId).DataTable({
        'paging': true,
        "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
        'searching': true,
        'ordering': true,
        'info': true,
        'autoWidth': true
    });


};