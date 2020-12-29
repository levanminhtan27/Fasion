var CustomerCart = CustomerCart || {};

CustomerCart.AddItem = function (id) {
    /*    preventDefault();*//**/
    var amount = $(`#${id}`).val();
    //var UserId = $("#UserId").val();
    $.ajax({
        url: `/Cart/AddItem/${id}/${amount}`,
        method: "GET",
        contentType: 'json',
        success: function (data) {
            /* window.location.href("https://localhost:44337/");đhjiahàbạ*/
            console.log(data);
            if (data == -1) {
                alert("<p style='color: green'>Thêm Sản Phẩm Thành Công</p>");
            } else {
                alert("Thêm Sản Phẩm Thành Công");
                $("#CartNum").html(parseInt($("#CartNum").text(), 10) + parseInt(1, 10));
            }
            /*if (data == -1) {
                bootbox.alert("<p style='color: green'>Thêm Sản Phẩm Thành Công</p>");
            }
            else {
                bootbox.alert("<p style='color: green'>Thêm Sản Phẩm Thành Công</p>");
                $("#CartNum").html(parseInt($("#CartNum").text(), 10) + parseInt(1, 10));
            }*/
            /* $("#CartNum").val(data);*/
        }
    });
}


CustomerCart.OrderByAccount = function (id) {
    $.ajax({
        url: `/Cart/OrderByAccount/${id}`,
        method: "GET",
        contentType: 'json',
        success: function (data) {
            console.log(data);
            if (data > 0) {
                bootbox.alert({
                    message: "Đặt Hàng Thành Công, Xe được giao hàng trong 3 ngày tới",
                    callback: function () {
                        window.location.href = "/CustomerHome/Index/";
                    }
                });
            }
        }
    });
}

CustomerCart.OrderWithoutAccount = function () {

    var name = $("#Name").val();
    var phoneNum = $("#PhoneNum").val();
    var email = $("#Email").val();
    var address = $("#Address").val();

    if (name == "") {
        $("#validateName").html("bạn chưa nhập tên");
    }
    if (phoneNum == "") {
        $("#validatePhoneNum").html("bạn chưa nhập số điện thoại");
    }
    if (email == "") {
        $("#validateEmail").html("bạn chưa nhập Email");
    }
    if (address == "") {
        $("#validateAddress").html("bạn chưa nhập địa chỉ");
    }
    var j = 0;
    for (var i = 0; i < email.length; i++) {
        if (email[i] == "@") {
            j = 1;
            break;
        }
    }
    if (j != 1) {
        $("#validateEmail").html("Email không đúng định dạng");
        $("#Email").val("");
    }
    if (phoneNum.length < 9) {
        $("#validatePhoneNum").html("Số điện thoại có ít nhất 9 chữ số!");
    }

    $.ajax({
        url: `/Cart/OrderWithoutAccount/${name}/${phoneNum}/${email}/${address}`,
        method: "GET",
        contentType: 'json',
        success: function (data) {
            console.log(data);
            if (data > 0) {
                $("#close").click();
                bootbox.alert({
                    message: "Đặt Hàng Thành Công, Xe được giao hàng trong 3 ngày tới",
                    callback: function () {
                        window.location.href = "/CustomerHome/Index/";
                    }
                });
            }
        }
    });
}

CustomerCart.RemoveItem = function (id) {
    $.ajax({
        url: `/Cart/RemoveItem/${id}`,
        method: "GET",
        contentType: 'json',
        success: function (data) {
            console.log(data);
            if (data > 0) {
                window.location.href = "/CustomerHome/WatchCart/";
            }
        }
    });
}