<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OJViewTest.view.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/Resource/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/Resource/js/jquery.min.js"></script>
    <script src="/Resource/bootstrap/js/bootstrap.min.js"></script>
    <script src="/Resource/js/Login.js"></script>
    <title></title>
</head>
<body>
    <div class="container-fluid">
        <div class="row-fluid">
            <!--head-->
            <div class="span12">

                <!--    <div class="row">
                    <div class="col-md-4">
                        <img class="img-rounded img-responsive" style="width: 198px; height: 45px; margin: 30px 20px 10px 50px;" src="/Resource/img/test.png" />
                    </div>
                    <div class="col-md-8" style="height: 99px">
                    </div>
                </div>-->


                <!--Menu-->
                <nav class="navbar navbar-default" role="navigation">
                    <div class="nav-header">
                        <a class="navbar-brand col-sm-2 text-center" href="#">在线评测系统</a>
                    </div>
                    <ul class="nav navbar-nav">
                        <li>
                            <a href="/view/MainPage.html">练习</a>
                        </li>
                        <li>
                            <a href="#">分类</a>
                        </li>
                        <li>
                            <a href="#">比赛</a>
                        </li>
                        <li>
                            <a href="#">班级</a>
                        </li>
                        <li>
                            <a href="#">排名</a>
                        </li>
                        <li>
                            <a href="#">关于</a>
                        </li>
                        <!--<li class="dropdown">
                            <a data-toggle="dropdown" class="dropdown-toggle" href="#">下拉菜单<b class="caret"></b></a>
                            <ul class="dropdown-menu" contenteditable="true">
                                <li>
                                    <a href="#">下拉导航1</a>
                                </li>
                                <li>
                                    <a href="#">下拉导航2</a>
                                </li>
                                <li>
                                    <a href="#">其他</a>
                                </li>
                                <li class="divider"></li>
                                <li class="nav-header">标签
                                </li>
                                <li>
                                    <a href="#">链接1</a>
                                </li>
                                <li>
                                    <a href="#">链接2</a>
                                </li>
                            </ul>
                        </li>-->
                    </ul>
                    <div id="loginPanel"></div>
                    <%-- <ul class="nav navbar-nav pull-right">
                        <li>
                            <a href="/view/Login.html">登录</a>
                        </li>
                        <li><a href="/view/Regist.html">注册</a></li>
                    </ul>--%>
                </nav>

            </div>
        </div>

        <div class="row-fluid">

            <div class="col-md-2">
            </div>

            <div class="col-md-8">
                <div class="panel panel-default" style="margin-left: 200px; margin-right: 200px; margin-top: 50px">
                    <div class="panel-heading">
                        <h3 class="panel-title">登录</h3>
                    </div>
                    <div class="panel-body">
                        <form runat="server">
                            <div class="form-group">
                                <label class="col-md-3 control-label text-right" style="margin-left: 50px;">用户名</label>
                                <input runat="server" id="input_username" type="text" />
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label text-right" style="margin-left: 50px;">密码</label>
                                <input runat="server" id="input_password" type="password" />
                            </div>
                            <button class="btn" id="btn_login" runat="server" contenteditable="true" style="margin-left: 120px; width: 210px;" onserverclick="btn_login_OnServerClick">登录</button>
                        </form>
                    </div>
                </div>

            </div>

            <div class="col-md-2">
            </div>
        </div>
    </div>
</body>
</html>
