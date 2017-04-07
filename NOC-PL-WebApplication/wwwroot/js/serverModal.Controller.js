; (function ($) {
    var productName;
    var productId;
    var serverColumn;
    var serverGroup;

    /**
         * @desc Sets up logic for modal window. Creates jquery method to listen
         *       for a change on the server select list in the modal window.
         * @param  {string} productName
         * @param  {int} productId
         * @param  {string} serverColumn
         * @param  {string} serverGroup
         */

    $(document).ready(function () { 
        
        $('[serverColumn]').click(function () {
            productName = $(this).attr('productName');
            serverColumn = $(this).attr('serverColumn');
            serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping of servers
            productId = $(this).attr('productId');

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

    $.fn.serverListChangeFunction = function serverListChange() {
        /**
         * @desc jquery function to save selected server to database
         * @param {int} serverId
         */
        var serverId = $('#ServerSelectList').val();
        $.post("products/SaveSelectedServer",
            {
                productId: productId,
                serverColumn: serverColumn,
                serverId: serverId
            });
            // function (data, status) {
            //     alert(data + "status" + status);
            // });
    }
}(jQuery));


