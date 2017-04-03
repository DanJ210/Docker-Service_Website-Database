$(document).ready(function () {
    //alert("ready");
    $('td').click(function () {
        var currentId = $(this).offset();
        //alert("Clicked");
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
        //$('#serverModal').text("Hello");
        
        $('#serverModal').on('show.bs.modal', function () {


            // Get that got all servers from a past web API
            //$.get("/api/servers/", function (data, status) {
            //    $('#modalTd').text(data);
            //});
        });
        $('#serverModal').modal().css("left", currentId.left).css("top", currentId.top);
        

    });
});