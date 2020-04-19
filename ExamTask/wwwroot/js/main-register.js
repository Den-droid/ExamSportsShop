(function($) {

    $('#signup-form').validate({
        rules : {
            first_name : {
                required: true,
            },
            last_name : {
                required: true,
            },
            password : {
                required: true
            },
            middle_name: {
                required: true
            },
            email: {
                required: true
            },
            re_password : {
                required: true,
                equalTo: "#password"
            }
        },
        onfocusout: function(element) {
            $(element).valid();
        },
    });

    jQuery.extend(jQuery.validator.messages, {
        required: "",
        remote: "",
        email: "",
        url: "",
        date: "",
        dateISO: "",
        number: "",
        digits: "",
        creditcard: "",
        equalTo: ""
    });
})(jQuery);