//var bgImgs = ['../Content/images/bg3.jpg']
//var currentIndex = 0;
//function changeBg() {
//    //定义要切换的背景图片，双引号里面，可以放任意多个
//    if (currentIndex >= bgImgs.length)
//        currentIndex = 0;
//    var obj = document.getElementsByTagName("BODY")[0];
//    obj.style.backgroundImage = "url(" + bgImgs[currentIndex] + ")"
//    currentIndex += 1;
//}
//setInterval(changeBg, 3000); //设定定时切换，单位为毫秒，比如：30分钟=1800秒=1800000毫秒

var $sub = $("#submit");//提交按钮
var $cal = $("#cancel");//取消按钮
//提交注册
$sub.on("click", function () {
    var loginId = $.trim($("#login").find("input").val());
    var pw1 = $.trim($("#pw1").val());
    var pw2 = $.trim($("#pw2").val());
    var type = $("#login").find("input").attr("id");
    //console.log($("#login").find("input"))
    var param = { loginId: loginId, pw1: pw1, pw2: pw2, type: type  }
    $.ajax({
        type: 'post',
        data: param,
        url: 'Custom/Register',
        beforeSend: function () {
            if (loginId == '' || loginId == 'undefined') {
                alert("请输入登录账号"); return;
            }
            if (pw1 == '' || pw1 == 'undefined') {
                alert("请输入密码"); return;
            }
            if (pw2 == '' || pw2 == 'undefined') {
                alert("请再次输入密码"); return;
            }
            if (pw1 != pw2) {
                alert("两次密码输入不一致"); return;
            }
        },
        success: function (res) {
            if (res.Type == 0) {
                if (confirm("注册成功,是否立即登录?")) {
                    window.location.href = 'home/index';
                }
            }
        }
    });

})
//切换注册方式
function a_Switch() {
    var text = $("#maskLayer").find("a").text();  
    $("#pw1").val("");
    $("#pw2").val("");
    $("#pw1").next("span").text("");
    $("#pw2").next("span").text("");
    if (text == "使用手机注册") {
        $("#maskLayer").find("a").text("使用邮箱注册");
        $("#email").val("");
        $("#email").next("span").text("");
        $("#email").attr("placeholder", "请 输 入 手 机 号 码").attr("id", "mobile");     
    } else {
        $("#maskLayer").find("a").text("使用手机注册");
        $("#mobile").val("");
        $("#mobile").next('span').text("");
        $("#mobile").attr("placeholder", "请 输 入 邮 箱").attr("id", "email");
    }
}

$("#email").on("change", function () {
    switch ($(this).attr("id")) {
        case 'email':
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!filter.test($.trim($(this).val()))) {
                FilterContent(this,"邮箱格式不正确"); return;
            } else {
                FilterContent(this,"")
            };
            break;
        case 'mobile':
            var filter = /^1[3|4|5|8][0-9]\d{4,8}$/;
            if (!filter.test($.trim($(this).val()))) {
                FilterContent(this,"手机格式不正确"); return;
            } else {
                FilterContent(this,"");
            }
            break;
        default:
            break;
    }  
})
$("#pw1").on("change", function () {
    var filter = /^[a-zA-Z0-9]{8,18}$/;
    if (!filter.test($.trim($(this).val()))) {
        FilterContent(this, "密码输入有误"); return;
    } else {
        FilterContent(this,"");
    }
})
$("#pw2").on("change", function () {
    var filter = $.trim($("#pw1").val());
    if (filter != $.trim($("#pw2").val())) {
        FilterContent(this, "两次密码不一致"); return;
    } else {
        FilterContent(this, "");
    }
})
function FilterContent(controller,val) {
    return $(controller).next('span').text(val);
}
/*$("#mobile").on("change", function () {
    var filter = /^1[3|4|5|8][0-9]\d{4,8}$/;
    if (!filter.test($.trim($(this).val()))) {
        $(this).next('span').text("手机号码格式不正确"); return;
    } else {
        $(this).next('span').text("");
    }
}) */
//取消注册
$cal.on("click", function () {
    window.location.href = 'http://helpyou.net.cn';
})