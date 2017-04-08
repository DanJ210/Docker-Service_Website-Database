﻿; (function ($) {

    /**
     * Store scroll position for and set it after reload
     *
     * @return {boolean} [loacalStorage is available]
     */
    $.fn.scrollPosReaload = function () {
        if (localStorage) {
            var posReader = localStorage["posStorage"];
            if (posReader) {
                $(window).scrollTop(posReader);
                localStorage.removeItem("posStorage");
            }
            $(this).click(function () {
                localStorage["posStorage"] = $(window).scrollTop();
            });

            return true;
        }

        return false;
    };

    /* ================================================== */

    $(document).ready(function () {
        $('#saveButton').scrollPosReaload();
    });

}(jQuery));  