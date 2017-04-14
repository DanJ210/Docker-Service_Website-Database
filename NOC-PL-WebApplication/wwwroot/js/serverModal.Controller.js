; (function ($) {
    var productId;
    var serverColumn;
    var serverGroup;
    
    /**
    * @desc Logic for Modal Window. Gets parameters for server call. 
    * @param  {int} productId
    * @param  {string} serverColumn
    * @param  {string} serverGroup
    */
debugger;
    $(document).ready(function () { 
        
        $('[serverColumn]').click(function () {
            serverColumn = $(this).attr('serverColumn');
            serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping of servers
            productId = $(this).attr('productId');

            $('#serverModal').modal();

            $('#saveButton').click(function () {
                $('#serverModal').modal('hide');
            });
            // Keeping this seperate makes it work faster.
            $('#serverModal').on('hide.bs.modal', function () {
                
            });
        });
    });

    $.fn.serverListChangeFunction = function serverListChange() {
        /**
         * @desc POSt
         * @param {int} serverId
         * @param {Controller} TableDataVMs
         * @param {ACtion} SaveSelectedServer
         */
        var serverId = $('#ServerSelectList').val();
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: 'SaveSelectedServer',
            data: {
                'productId': productId,
                'serverColumn': serverColumn,
                'serverId' : serverId},
            success: function () {
                $('#serverModal').modal('hide');
                location.reload();
            },
            error: function (status) {
                if (status.status === 401) {
                    alert("Data can only be changed by admin");
                }
                else {
                    alert(status.statusText + ". Please contact admin");
                }
                $('#serverModal').modal('hide');
            }
        });
    };
}(jQuery));


