<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuManager.aspx.cs" Inherits="OJCMS.Menu.MenuManager" %>

<%@ Register Src="~/Controls/WindowDialog.ascx" TagPrefix="uc1" TagName="WindowDialog" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server" />
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region2" ShowBorder="false" ShowHeader="false" Position="Center" Layout="VBox"
                    BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 0"
                    runat="server">
                    <Items>
                        <f:Grid ID="Grid1" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                            EnableCheckBoxSelect="false" DataKeyNames="Id,Code" EnableTextSelection="true"
                            AllowSorting="true" SortDirection="DESC"
                            AllowPaging="false" OnRowCommand="Grid1_RowCommand">
                            <Toolbars>
                                <f:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <%--<f:Button ID="btnNewMenu" runat="server" Icon="Add" OnClick="btnNewMenu_Click"
                                            Text="新增菜单">
                                        </f:Button>--%>
                                        <f:Button ID="btnNew" runat="server" Icon="Add" OnClick="btnNew_Click" Text="新增功能">
                                        </f:Button>
                                        <f:Button runat="server" ID="btnEdit" Icon="PageEdit" Text="修改功能" OnClick="btnEdit_OnClick"></f:Button>
                                    </Items>
                                </f:Toolbar>
                            </Toolbars>
                            <Columns>
                                <f:BoundField DataField="Id" HeaderText="菜单ID" Hidden="True" />
                                <f:BoundField DataField="Code" HeaderText="菜单编码" Width="80px" />
                                <f:BoundField DataField="Name" HeaderText="菜单标题" DataSimulateTreeLevelField="TreeLevel"
                                    Width="160px" />
                                <f:BoundField DataField="NavigateUrl" HeaderText="链接" Width="200px" ExpandUnusedSpace="true" />
                                <f:BoundField DataField="Num" HeaderText="排序" Width="80px" />
                                <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除" HeaderText="删除"
                                    ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                            </Columns>
                        </f:Grid>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
        <uc1:WindowDialog runat="server" ID="WindowDialog" />
    </form>
</body>
</html>
