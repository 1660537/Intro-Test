var Sanitation = "box-sanitation";
var Security = "box-security";
var CustomerCare = "box-customer-care";

function Logout() {
    var passcode = $("#password-field").val();

    $.ajax({
        url: "/Login/LogOut",
        type: "post",
        dataType: "json",
        data: { passcode: passcode },
        cache: false,
        async: false,
        success: function (data) {
            if (data) {
                $('#modal').modal('toggle');
                window.location.href = "/login";
            }
            else {
                alert("Passcode đã sai. Vui lòng nhập lại.")
                $("#password-field").val("");
                $("#password-field").focus();
            }
        }, error: function (data) {
            alert("Error");
        }
    }); 
}

function ChangeRole() {
    var passcode = $("#password-field-change").val();
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
        $("#password-field-change").focus();
        return;
    }

    var data = { IdRole: role, code: passcode };   

    $.ajax({
        url: "/Login/ChangeRole",
        type: "post",
        dataType: "json",
        data: { passcode: data },
        cache: false,
        async: false,
        success: function (data) {
            if (data) {
                $('#modal').modal('toggle');
                window.location.href = "/rating";
            }
            else {
                alert("Passcode đã sai. Vui lòng nhập lại.")
                $("#password-field-change").val("");
                $("#password-field-change").focus();
            }
        }, error: function (data) {
            alert("Error");
        }
    }); 
}