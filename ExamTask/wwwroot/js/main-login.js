
(function ($) {
    "use strict";


    /*==================================================================
    [ Focus input ]*/
    $('.input100').each(function(){
        $(this).on('blur', function(){
            if($(this).val().trim() != "") {
                $(this).addClass('has-val');
            }
            else {
                $(this).removeClass('has-val');
            }
        })    
    })

})(jQuery);

function myFunction() {
    var x = document.getElementById("myPass");
    var eye = document.getElementsByClassName("toggle-password");
    if (x.type === "password") {
        x.type = "text";
        eye[0].classList.remove("fa-eye");
        eye[0].classList.add("fa-eye-slash");
    } else {
        x.type = "password";
        eye[0].classList.remove("fa-eye-slash");
        eye[0].classList.add("fa-eye");
    }
}