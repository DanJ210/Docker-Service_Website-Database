; (function ($) {

    /**
     * @desc Store scroll position for and set it after reload
     * @return {boolean} [loacalStorage is available]
     */
    $.fn.scrollPosReaload = function () {
        if (localStorage) {
            var posReader = localStorage["posStorage"];
            if (posReader) {
                $(window).scrollTop(posReader);
                localStorage.removeItem("posStorage");
            }
            /**
             * @param {object} Event Object
             */
            $(this).click(function (e) {
                localStorage["posStorage"] = $(window).scrollTop();
            });

            return true;
        }

        return false;
    };
    // Adds the jQuery function to modal save button
    $(document).ready(function () {
        //$('#saveButton').scrollPosReaload();
        $('#serverModal').scrollPosReaload();
    });

}(jQuery));  