$(document).ready(function () {
    //alert("ready");
    //var serverCell = $().attr("cellClass");

    //serverCell.click(function () {
    //    alert("Cell class clicked");
    //});
    //$('td').click(function () {
        
    //    alert($(this).attr("cellClass"));
    //});
    $('[cellClass]').click(function () {
        var currentCellIdPosition = $(this).offset();
        //alert("Clicked");
        //var cellId = $(this).attr('id');
        //alert(cellId);
        //alert(currentId.left);
        
        $('#serverModal').on('show.bs.modal', function () {


            // Get that got all servers from a past web API
            //$.get("/api/servers/", function (data, status) {
            //    $('#modalTd').text(data);
            //});
        });
        $('#serverModal').modal().css("left", currentCellIdPosition.left).css("top", currentCellIdPosition.top);

        $('#saveButton').click(function () {
            //alert("#ServerList").attr('id');
            $('#serverModal').modal('hide');
        });
        //$('#serverModal').on('hide.bs.modal', function () {
            
        //    //alert("Modal about to be hidden");
        //    //alert('#ServerList').val();
        //    alert($('#ServerList option:selected').text());
        //});
    });
    
});

function serverListChange() {
    alert("server selected");
}