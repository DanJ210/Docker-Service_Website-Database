
// Global variable needed to send to controller
var productName;

$(document).ready(function () {
    //alert("ready");
    //var serverCell = $().attr("cellClass");

    //serverCell.click(function () {
    //    alert("Cell class clicked");
    //});
    //$('td').click(function () {

    //    alert($(this).attr("cellClass"));
    //});
    $('[serverCell]').click(function () {
        var currentCellIdPosition = $(this).offset();
        //alert("Clicked");
        productName = $(this).attr('id');

        //alert(currentId.left);
        //function getProductId() {

        //    return cellId
        //}


        $('#serverModal').on('show.bs.modal', function () {


            // Get that got all servers from a past web API
            //$.get("/api/servers/", function (data, status) {
            //    $('#modalTd').text(data);
            //});
        });
        $('#serverModal').modal().css("left", currentCellIdPosition.left).css("top", currentCellIdPosition.top);

        $('#saveButton').click(function () {
            //alert("#ServerList").attr('id');
            $('#serverModal').modal('hide')
        });
        // Keeping this seperate makes it work faster.
        $('#serverModal').on('hide.bs.modal', function () {
            location.reload();
        });
    });
});


function serverListChange() {
    var serverId = $('#ServerSelectList').val();
    //alert(serverId);
    $.post("products/SaveSelectedServer",
        {
            productName: productName,
            serverId: serverId
        },
        function (data, status) {
            //alert("data: " + data + "\nStatus: " + status);
            
        });
    //$.post("servers/GetServerNameById",
    //    {
    //        serverId: serverId
    //    },
    //    function (data, status) {
    //        //$('td').attr('id', data).text("Testing");
    //        //alert(data + "  " + status);
    //    }
    //);
    //$('[serverCell]').text("Test");
}