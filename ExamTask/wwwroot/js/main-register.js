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

function myFunction(a) {
    var x = document.getElementsByClassName("my_pass");
    var eye = document.getElementsByClassName("toggle-password");
    if (x[a].type === "password") {
        x[a].type = "text";
        eye[a].classList.remove("fa-eye");
        eye[a].classList.add("fa-eye-slash");
    } else {
        x[a].type = "password";
        eye[a].classList.remove("fa-eye-slash");
        eye[a].classList.add("fa-eye");
    }
}