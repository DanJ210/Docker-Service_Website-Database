; (function ($) {
    var productName;
    var productId;
    var serverColumn;
    var serverGroup;

    $(document).ready(function () {

        
        $('[serverColumn]').click(function () {
            productName = $(this).attr('productName');
            serverColumn = $(this).attr('serverColumn');
            serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping of servers
            productId = $(this).attr('productId');
            //alert($(this).attr('productid'));
            alert($(this).attr('productId'));

            $('#serverModal').modal();

            $('#saveButton').click(function () {
                $('#serverModal').modal('hide');
            });
            // Keeping this seperate makes it work faster.
            $('#serverModal').on('hide.bs.modal', function () {
                location.reload();
                //alert($('#container-fluid').get('localhost'));
            });
        });
    });

    $.fn.serverListChangeFunction = function serverListChange() {
        var serverId = $('#ServerSelectList').val();
        $.post("products/SaveSelectedServer",
            {
                productId: productId,
                serverColumn: serverColumn,
                serverId: serverId
            },
            function (data, status) {
                alert(data + "status" + status);
            });
    }
}(jQuery));


