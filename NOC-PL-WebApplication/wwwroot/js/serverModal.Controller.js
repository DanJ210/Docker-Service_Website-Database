﻿

var productName;
var serverColumn;
var serverGroup;

$(document).ready(function () {
    $('[serverColumn]').click(function () {
        var currentCellIdPosition = $(this).offset();
        //alert($(this).text());
        productName = $(this).attr('productName');
        serverColumn = $(this).attr('serverColumn');
        serverGroup = $(this).attr('serverGroup'); // Used in future iteration for color grouping

        //$('#serverModal').on('show.bs.modal', function () {
        //});
        $('#serverModal').modal();   /*.css("left", currentCellIdPosition.left).css("top", currentCellIdPosition.top);*/

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
            serverColumn: serverColumn,
            serverId: serverId
        },
        function (data, status) {
        });
    //$.post("servers/GetServerNameById",
    //    {
    //        serverId: serverId
    //    },
    //    function (data, status) {
    //        alert($('[serverColumn]="' + serverColumn + '"'));
    //    }
    //);
}