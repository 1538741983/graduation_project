<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="OJCMS.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在线评测后台管理系统</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%--<link rel="shortcut icon" href="icon/logo.ico" />--%>
    <style>
        .header {
            background-color: #2164A6;
            border-bottom: 1px solid #020031;
        }

            .header .x-panel-body {
                background-color: transparent;
            }

            .header .title a {
                font-weight: bold;
                font-size: 24px;
                text-decoration: none;
                line-height: 50px;
                margin-left: 10px;
            }

        .intro {
            font-size: 13px;
            line-height: 1.5em;
        }

            .intro h2 {
                font-size: 14px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" Margin="0 0 0 0" ShowBorder="false" Height="90px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                            <Items>
                                <f:ToolbarText ID="txtUser" Text="欢迎您：吴浩" runat="server">
                                </f:ToolbarText>
                                <f:ToolbarSeparator runat="server" />
                                <f:ToolbarText ID="txtOnlineUserCount" Text="在线人数:10000" runat="server">
                                </f:ToolbarText>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server"></f:ToolbarFill>
                                <f:Button ID="btnShowHideHeader" runat="server" Icon="SectionExpanded" Hidden="True" ToolTip="隐藏标题栏"
                                    EnablePostBack="false">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                                <f:Button ID="btnRefresh" runat="server" Icon="ArrowRotateClockwise" EnablePostBack="false"
                                    ToolTip="刷新主区域内容" OnClientClick="refresh()">
                                </f:Button>
                                <f:Button ID="btnManage" Hidden="True" runat="server" Icon="UserAlert" Text="用户管理">
                                </f:Button>
                                <f:ToolbarSeparator ID="ToolbarSeparator4" runat="server" />
                                <f:Button ID="btnExit" runat="server" Icon="UserRed" Text="安全退出" ConfirmText="确定退出系统？"
                                    OnClick="btnExit_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Items>
                        <f:ContentPanel ShowBorder="false" ShowHeader="false" ID="ContentPanel1" CssClass="header"
                            runat="server">
                            <div class="title">
                                <a href="./default.aspx" style="color: #fff;">在线评测后台管理系统</a>
                            </div>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
                <f:Region ID="regionLeft" Split="true" Width="200px" Margin="0 0 0 0" ShowHeader="true"
                    Title="系统导航菜单" Icon="Outline" EnableCollapse="true" Layout="Fit" Position="Left"
                    runat="server">
                    <Items>
                        <%--<f:Accordion ID="AccordionmMenu" runat="server" ShowBorder="false" ShowHeader="false"
                            ShowCollapseTool="true" />--%>
                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" ID="leftTree">
                        </f:Tree>
                    </Items>
                </f:Region>
                <f:Region IFrameName="Main" ID="mainRegion" ShowHeader="false" Layout="Fit" Margin="0 0 0 0"
                    Position="Center" EnableFrame="true" runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Items>
                                        <f:ContentPanel ID="ContentPanel2" CssClass="intro" ShowBorder="false" BodyPadding="10px"
                                            ShowHeader="false" AutoScroll="true" runat="server">
                                            <h1>在线评测后台管理系统</h1>
                                            <p style="margin-left: 13px">欢迎访问在线评测后台管理系统。</p>
                                            <br />
                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <f:Window ID="Window1" runat="server" IsModal="true" Hidden="true" Target="Top" EnableResize="true"
            EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank" Width="650px"
            Height="450px" OnClose="Window1_Close">
        </f:Window>
    </form>
    <script>
        var menuClientID = '<%= leftTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        // 页面控件初始化完毕后，会调用用户自定义的onReady函数
        F.ready(function () {

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
            // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
            F.initTreeTabStrip(F(menuClientID), F(tabStripClientID), null, true, false, false);

        });
        function refresh() {
            var activeTab = F(tabStripClientID).getActiveTab();
            Ext.DomQuery.selectNode('iframe', activeTab.el.dom).contentWindow.location.reload();
        }
    </script>
</body>
</html>
