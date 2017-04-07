// Logic for the modal window. Saves a selected server to the database.
// Reloads the page on close

var productName;
var serverColumn;
var serverGroup;

$(document).ready(function () {
    $('[serverColumn]').click(function () {
        var currentCellIdPosition = $(this).offset();
        productName = $(this).attr('productName');
        serverColumn = $(this).attr('serverColumn');
        serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping of servers

        $('#serverModal').modal();

        $('#saveButton').click(function () {
            $('#serverModal').modal('hide');
        });
        // Keeping this seperate makes it work faster.
        $('#serverModal').on('hide.bs.modal', function () {
            location.reload();
        });
    });
});

function serverListChange() {
    var serverId = $('#ServerSelectList').val();
    $.post("products/SaveSelectedServer",
        {
            productName: productName,
            serverColumn: serverColumn,
            serverId: serverId
        },
        function (data, status) {
        });
}