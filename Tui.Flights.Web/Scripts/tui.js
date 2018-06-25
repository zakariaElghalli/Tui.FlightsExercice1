(function ($, toastr, window, document) {
    "use strict";

    $(document).on("click", "#btn-addorupdate", function (e) {
        e.preventDefault();
        var form = $("#form-AddOrUpdate");
        var redirectUrl = $(this).data("redirect-url");
        $.ajax({
            cache: false,
            async: true,
            type: "POST",
            dataType: "json",
            url: form[0].action,
            data: form.serialize(),
            success: function (response) {               
                if (response.valid) {
                    window.toastr.success("Success");
                    window.location = redirectUrl;
                } else {
                    window.toastr.error("A problem occured :" + response.message);
                }
            },
            error: function () {
                window.toastr.error("A problem occured !!");
            }
        });
    });  



    $(document).on("click", "#btn-delete", function (e) {
      
        e.preventDefault();
        var form = $("#form-delete");
        var redirectUrl = $(this).data("redirect-url");
        $.ajax({
            cache: false,
            async: true,
            type: "POST",
            dataType: "json",
            url: form[0].action,
            data: form.serialize(),
            success: function (response) {
                if (response.valid) {
                    window.toastr.success("Success");
                    window.location = redirectUrl;
                } else {
                    window.toastr.error("A problem occured :" + response.message);
                }
            },
            error: function () {
                window.toastr.error("A problem occured !!");
            }
        });
    });    

})(jQuery, toastr, window, document);