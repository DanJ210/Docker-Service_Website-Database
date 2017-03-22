$(document).ready(function () {
    //alert("ready");
    $('td').click(function () {
        var currentId = $(this).offset();
        //alert(currentId.left);
        //awesome.id();
        //alert(awesome.screenX);
        //alert(awesome.returnValue);
        //alert(awesome.result);
        //alert(awesome.pageX);
        //alert(awesome.pagey);
        //var position = this.position();
        //var x = awesome.pageX;
        //var position = awesome.position;
        //alert(x);
        //alert(position);

        //alert("clicked");
        $('#serverModal').modal().css("left", currentId.left).css("top", currentId.top);
        //$('#serverModal').modal('show.bs.modal', function () {
        //    $('.modal-dialog').css("left", "800px");
        //});

    });
});