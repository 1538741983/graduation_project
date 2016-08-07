<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OJCMS.Index" %>

<%@ Import Namespace="OJCMS.OJCMSService" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>OJCMS</title>
    <link type="text/css" rel="stylesheet" href="./res/css/default.css" />
    <%--<script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/index.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server"></f:PageManager>
        <f:Panel ID="Panel1" Layout="Region" ShowBorder="false" ShowHeader="false" runat="server">
            <Items>
                <f:ContentPanel ID="ContentPanel1" RegionPosition="Top" ShowBorder="false" CssClass="jumbotron" ShowHeader="false" runat="server">
                    <div class="wrap">
                        <div class="logos">
                            在线评测后台管理系统
                        </div>
                        <div class="menu" id="topmenu">
                            <ul>
                                <% foreach (MenuDO menu in MenuList)
                                   {
                                       string str = string.Format("<li class=\"selected menu-{0}\"><a href=\"javascript:;\"><span>{1}</span></a> </li>", menu.Code, menu.Name);
                                       Response.Write(str);

                                   } %>
                                <%--<li class="selected menu-oj"><a href="javascript:;"><span>OJ管理></span></a> </li>
                                <li class="selected menu-sys"><a href="javascript:;"><span>系统管理></span></a> </li>--%>
                            </ul>
                        </div>
                        <div class="member">
                            领先的 XXX 管理系统欢迎您！
                        </div>
                        <div class="exit">
                            <a href="javascript:;">退出管理</a>
                        </div>
                    </div>
                </f:ContentPanel>
                <f:Panel ID="Region2" RegionPosition="Left" RegionSplit="true" Width="200px"
                    ShowHeader="true" Title="业务菜单" Icon="Outline"
                    EnableCollapse="true" EnableIFrame="true" IFrameName="leftframe" IFrameUrl="about:blank"
                    runat="server">
                </f:Panel>
                <f:TabStrip ID="mainTabStrip" RegionPosition="Center" EnableTabCloseMenu="true" ShowBorder="true" runat="server">
                    <Tabs>
                        <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" CssClass="maincontent" runat="server">
                            <Items>
                                <f:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                    runat="server">
                                    首页内容
                                </f:ContentPanel>
                            </Items>
                        </f:Tab>
                    </Tabs>
                </f:TabStrip>
            </Items>
        </f:Panel>
    </form>
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var mainTabStripClientID = '<%= mainTabStrip.ClientID %>';
    </script>

    <script src="js/index.js" type="text/javascript"></script>
</body>
</html>

