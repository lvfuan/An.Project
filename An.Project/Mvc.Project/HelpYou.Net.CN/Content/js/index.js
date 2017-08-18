
layui.define(['element', 'layer', 'form'], function (exports) {
    login();
    var form = layui.form();
    var la = layui.jquery;
    $("#submit").on("click", function () {
        var login = $("input[name=account]").val();
        var pwd = $("input[name= password]").val();
        var yzm = $("input[name=yzm]").val();
        var param = { login: login, pwd: pwd, yzm: yzm }
        $.ajax({
            type: 'post',
            url: 'UserManager/SignIn',
            data: param,
            beforeSend: function () {
                if (login == "" || login == "undefined") {
                    layer.msg("账号不能为空"); return false;
                }
                if (pwd == "" || pwd == "undefined") {
                    layer.msg("密码不能为空"); return false;
                }
                if (yzm == "" || yzm == "undefined") {
                    layer.msg("请输入验证码"); return false;
                }
            },
            success: function (res) {
                if (res.Type > 0) {
                    layer.msg(res.Message);
                }
                else {
                    window.location.href = 'UserManager/Main';
                }
            }
        })
    })

    $(function () {
        $("#valiCode").bind("click", function () {
            this.src = "PartView/GetValidateCode?time=" + (new Date()).getTime();
        });
        //alert("good");
    });

    //自定义验证
    //form.verify({      
    //    passWord: [/^[\S]{6,12}la/, '密码必须6到12位'],
    //    account: function (value) {
    //        if (value.length <= 0 || value.length > 10) {
    //            return "账号必须1到10位"
    //        }
    //        var reg = /^[a-zA-Z0-9]*la/;
    //        if (!reg.test(value)) {
    //            return "账号只能为英文或数字";
    //        }
    //    },
    //    result_response: function (value) {
    //        if (value.length < 1) {
    //            return '请点击人机识别验证';
    //        }
    //    },
    //});
    //监听登陆提交
    //form.on('submit(login)', function (data) {
    //    var index = layer.load(1);
    //    setTimeout(function () {
    //        //模拟登陆
    //        layer.close(index);
    //      
    //        //if (data.field.account != 'lyblogscn' || data.field.password != '111111') {
    //        //    layer.msg('账号或者密码错误', { icon: 5 });
    //        //} else {
    //        //    layer.msg('登陆成功，正在跳转......', { icon: 6 });
    //        //    layer.closeAll('page');
    //        //    setTimeout(function () {
    //        //        location.href = "main";
    //        //    }, 1000);
    //        //}
    //    }, 400);
    //    return false;
    //});

    //检测键盘按下
    la('body').keydown(function (e) {
        if (e.keyCode == 13) {  //Enter键
            if (la('#layer-login').length <= 0) {
                login();
            } else {
                la('button[lay-filter=login]').click();
            }
        }
    });

    la('.enter').on('click', login);

    function login() {
        var loginHtml = ''; //静态页面只能拼接，这里可以用iFrame或者Ajax请求分部视图。html文件夹下有login.html

        loginHtml += '<div class="layui-form" action="">';
        loginHtml += '<div class="layui-form-item">';
        loginHtml += '<label class="layui-form-label">账号</label>';
        loginHtml += '<div class="layui-input-inline pm-login-input">';
        loginHtml += '<input type="text" name="account" lay-verify="account" placeholder="请输入账号" value="admin" autocomplete="off" class="layui-input">';
        loginHtml += '</div>';
        loginHtml += '</div>';
        loginHtml += '<div class="layui-form-item">';
        loginHtml += '<label class="layui-form-label">密码</label>';
        loginHtml += '<div class="layui-input-inline pm-login-input">';
        loginHtml += '<input type="password" name="password" lay-verify="passWord" placeholder="请输入密码" value="123456" autocomplete="off" class="layui-input">';
        loginHtml += '</div>';
        loginHtml += '</div>';
        loginHtml += '<div class="layui-form-item">';
        loginHtml += '<label class="layui-form-label">验证码</label>';
        loginHtml += '<div class="layui-input-inline pm-login-input">';
        //loginHtml += '<input type="text" name="result_response" placeholder="人机验证，百度螺丝帽" value="" autocomplete="off" class="layui-input">';
        loginHtml += '<img id="valiCode" style="cursor: pointer;width:100px;" src="WebPartView/GetValidateCode"   alt="验证码" /><input type="text" name="yzm" class="layui-input" style="width:150px; float: left; margin-right:30px"/>';
        loginHtml += '</div>';
        loginHtml += '</div>';
        loginHtml += '<div class="layui-form-item" style="margin-top:25px;margin-bottom:0;">';
        loginHtml += '<div class="layui-input-block">';
        loginHtml += ' <button class="layui-btn" style="width:230px;" id="submit" lay-filter="login">立即登录</button>';
        loginHtml += ' </div>';
        loginHtml += ' </div>';
        loginHtml += '</div>';

        layer.open({
            id: 'layer-login',
            type: 1,
            title: false,
            shade: 0.4,
            shadeClose: true,
            area: ['480px', '270px'],
            closeBtn: 0,
            anim: 1,
            skin: 'pm-layer-login',
            content: loginHtml
        });
        layui.form().render('checkbox');
    }

    exports('signin', {});
});

