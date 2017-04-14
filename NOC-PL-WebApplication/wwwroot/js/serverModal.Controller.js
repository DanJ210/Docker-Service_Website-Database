; (function ($) {
    var productId;
    var serverColumn;
    var serverGroup;
    
    /**
         * @desc Sets up logic for modal window. Creates jquery method to listen
         *       for a change on the server select list in the modal window.
         * @param  {int} productId
         * @param  {string} serverColumn
         * @param  {string} serverGroup
         */

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
         * @desc jquery function to save selected server to database
         * @param {int} serverId
         */
        var serverId = $('#ServerSelectList').val();
        var ajaxRequest = $.ajax({
            type: 'POST',
            url: 'products/SaveSelectedServer',
            data: {
                'productId': productId,
                'serverColumn': serverColumn,
                'serverId' : serverId},
            success: function () {
                $('#serverModal').modal('hide');
                location.reload();
            },
            error: function (status) {
                if (status.status === '401') {
                    alert("Data can only be changed by admin");
                }
                else {
                    alert(status.statusText);
                }
                $('#serverModal').modal('hide');
            }
        });
        //ajaxRequest.send();
        //var ajaxSaveSelectedServer = $.post("products/SaveSelectedServer",
        //    {
        //        productId: productId,
        //        serverColumn: serverColumn,
        //        serverId: serverId
        //    }, function (data, status) {
        //        //alert("Success: " + status);
        //        //alert("test");
        //        //alert(theObject);
        //        $('#serverModal').modal('hide');
        //    }
        //);
        //ajaxSaveSelectedServer.fail(function () {
        //    alert("Must be logged in");
        //    $('#serverModal').modal('hide');
        //});
        //alert("Before Fuck");
        //var errorHandling = ajaxPost.error(ajaxPost);
        //alert(typeof (errorHandling));
        //alert("Fuck");
        //alert(ajaxPostError);
        //ajaxPost.onerror(function (error) {
        //    alert("error");
        //});
        //ajaxPost.send();
        
    };
}(jQuery));


