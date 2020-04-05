﻿var User_Login = {
    Init: function () { },
    Login: {
        Login: function () {
            var email = $("#user-login-email").val();
            var password = $("#user-login-password").val();
            var rememberMe = $("#user-login-rememberme").prop("checked");

            var data = { Email: email, Password: password, RememberMe: rememberMe };

            data = JSON.stringify(data);

            $.ajax({
                type: "POST",
                url: "/user/loginaction",
                data: data,
                success: User_Login.Login.Login_Callback,
                error: User_Login.Login.Login_Callback_Error,
                dataType: "json",
                contentType: "application/json; charset=utf-8;"
            });
        },
        Login_Callback: function (result) {
            window.location = "/";
        },
        Login_Callback_Error: function (result) {
            alert("YAPTIĞIN AYIP");
        }
    },
    Register: {
        Register: function () {
            var name = $("#user-register-name").val();
            var surname = $("#user-register-surname").val();
            var email = $("#user-register-email").val();
            var password = $("#user-register-password").val();
            var password2 = $("#user-register-password2").val();

            if (password != password2) {
                Helper.UI.Alert("Hata!", "Şifreler birbiriyle uyuşmuyor!", "error")
            }
            else if (!Helper.MailCheck(email)) {
                Helper.UI.Alert("Hata!", "Lütfen geçerli bir email giriniz.", "error")
            } 
            else {
                var data = { Name: name, Surname: surname, Email: email, Password: password };

                data = JSON.stringify(data);

                $.ajax({
                    type: "POST",
                    url: "/user/registeraction",
                    data: data,
                    success: User_Login.Register.Register_Callback,
                    error: User_Login.Register.Register_Callback_Error,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8;"
                });
            }
            //client side validation
            //send to server
        },
        Register_Callback: function () {
            window.location.reload();
        },
        Register_Callback_Error: function (result) {
            Helper.UI.Alert("Hata Oluştu", result.responseText, "error");
        }
    }
};