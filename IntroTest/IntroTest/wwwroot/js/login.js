var Sanitation = "box-sanitation";
var Security = "box-security";
var CustomerCare = "box-customer-care";

$(document).ready(function () {
    $(".box-sanitation").addClass("checked");
    $(".box-sanitation .login-box-type").css("background-color", "white");
    $(".box-sanitation .img-login").css("filter", "none");
    $(".box-sanitation .text-login").css("color", "#C01E31");

    $(".box-sanitation").click(
        function () {
            $(".box-customer-care").removeClass("checked");
            $(".box-customer-care .login-box-type").css("background-color", "#C01E31");
            $(".box-customer-care .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-customer-care .text-login").css("color", "white");

            $(".box-security").removeClass("checked");
            $(".box-security .login-box-type").css("background-color", "#C01E31");
            $(".box-security .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-security .text-login").css("color", "white");

            $(this).addClass("checked");
            $(".box-sanitation .login-box-type").css("background-color", "white");
            $(".box-sanitation .img-login").css("filter", "none");
            $(".box-sanitation .text-login").css("color", "#C01E31");
        }
    )

    $(".box-customer-care").click(
        function () {
            $(".box-sanitation").removeClass("checked");
            $(".box-sanitation .login-box-type").css("background-color", "#C01E31");
            $(".box-sanitation .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-sanitation .text-login").css("color", "white");

            $(".box-security").removeClass("checked");
            $(".box-security .login-box-type").css("background-color", "#C01E31");
            $(".box-security .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-security .text-login").css("color", "white");

            $(this).addClass("checked");
            $(".box-customer-care .login-box-type").css("background-color", "white");
            $(".box-customer-care .img-login").css("filter", "none");
            $(".box-customer-care .text-login").css("color", "#C01E31");
        }
    )

    $(".box-security").click(
        function () {
            $(".box-sanitation").removeClass("checked");
            $(".box-sanitation .login-box-type").css("background-color", "#C01E31");
            $(".box-sanitation .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-sanitation .text-login").css("color", "white");

            $(".box-customer-care").removeClass("checked");
            $(".box-customer-care .login-box-type").css("background-color", "#C01E31");
            $(".box-customer-care .img-login").css("filter", "brightness(0) invert(1)");
            $(".box-customer-care .text-login").css("color", "white");

            $(this).addClass("checked");
            $(".box-security .login-box-type").css("background-color", "white");
            $(".box-security .img-login").css("filter", "none");
            $(".box-security .text-login").css("color", "#C01E31");
        }
    )
});

$(".toggle-password").click(function () {
    $(this).toggleClass("fa-eye fa-eye-slash");
    var input = $($(this).attr("toggle"));
    if (input.attr("type") == "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }
});

function CheckLogin() {
    var passcode = $("#password-field").val();
    var classNameChecked = $('.checked').attr('class');
    var role = 0;

    if (classNameChecked !== "") {
        if (classNameChecked.indexOf(Sanitation) !== -1) {
            role = 1;
        }
        else if (classNameChecked.indexOf(Security) !== -1) {
            role = 2;
        }
        else {
            role = 3;
        }
    }

    if (passcode === "" || role === 0) {
        $("#password-field").focus();
        return;
    }

    var data = { IdRole: role, code: passcode };   

    $.ajax({
        url: "/Login/CheckLogin",
        type: "post",
        dataType: "json",
        data: { passcode: data },
        cache: false,
        async: false,
        success: function (data) {
            window.location.href = data;
        }, error: function (data) {
            alert("Error");
        }
    }); 
}