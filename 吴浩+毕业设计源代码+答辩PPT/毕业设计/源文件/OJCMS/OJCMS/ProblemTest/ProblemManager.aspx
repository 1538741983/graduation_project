﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemManager.aspx.cs" Inherits="OJCMS.ProblemTest.ProblmeManager" %>

<%@ Register Src="~/Controls/WindowDialog.ascx" TagPrefix="uc1" TagName="WindowDialog" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <f:PageManager runat="server" ID="PageManager" AutoSizePanelID="RegionPanel1"></f:PageManager>
            <f:RegionPanel ID="RegionPanel1" runat="server" ShowBorder="False">
                <Regions>
                    <f:Region ID="Region2" runat="server" BodyPadding="5px"
                        ShowBorder="False" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
                        ShowHeader="False">
                        <Items>
                            <f:Grid ID="Grid1" runat="server" BoxFlex="1" PageSize="20" ShowBorder="True" ShowHeader="false" IsDatabasePaging="true"
                                EnableCheckBoxSelect="true" EnableTextSelection="true" DataKeyNames="Id,UserName" AllowSorting="true" OnSort="Grid1_Sort" SortField="U_ID"
                                SortDirection="ASC" AllowPaging="true" OnRowCommand="Grid1_RowCommand" OnPageIndexChange="Grid1_PageIndexChange">
                                <Toolbars>
                                    <f:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="true" Text="新增" />
                                            <%--<f:Button runat="server" ID="BtnSelectDel" Text="删除" OnClick="BtnSelectDel_Click" />--%>
                                            <f:ToolbarFill runat="server" />
                                            <f:TwinTriggerBox ID="ttbSearchMessage" runat="server" ShowLabel="false" EmptyText="请输入问题标题"
                                                Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                                                OnTrigger2Click="ttbSearchMessage_Trigger2Click" OnTrigger1Click="ttbSearchMessage_Trigger1Click" />
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                                <PageItems>
                                    <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </f:ToolbarSeparator>
                                    <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                                    </f:ToolbarText>
                                    <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlGridPageSize_SelectedIndexChanged"
                                        runat="server">
                                        <f:ListItem Text="20" Value="20" />
                                        <f:ListItem Text="30" Value="30" />
                                        <f:ListItem Text="50" Value="50" />
                                        <f:ListItem Text="70" Value="70" />
                                    </f:DropDownList>
                                </PageItems>
                                <Columns>
                                    <f:BoundField DataField="Id" Width="150px" HeaderText="题号" />
                                    <f:BoundField DataField="Difficulty" SortField="Difficulty" Width="100px" HeaderText="难度" />
                                    <f:BoundField DataField="Title" SortField="Title" Width="100px" HeaderText="标题" />
                                    <%--<f:BoundField DataField="权限名称" SortField="权限名称" Width="100px" HeaderText="所属权限" />--%>
                                    <f:WindowField ColumnID="editField" TextAlign="Center" Icon="Pencil" ToolTip="编辑"
                                        WindowID="Window1" Title="编辑问题信息" HeaderText="编辑" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="~/ProblemTest/ProblemEdit.aspx?id={0}&action=Edit"
                                        Width="50px" />
                                    <f:WindowField ColumnID="viewField" TextAlign="Center" Icon="Zoom" ToolTip="查看"
                                        WindowID="Window1" Title="查看问题信息" HeaderText="查看" DataIFrameUrlFields="Id" DataIFrameUrlFormatString="~/Problem/ProblemView.aspx?id={0}"
                                        Width="50px" />
                                    <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ToolTip="删除" HeaderText="删除"
                                        ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="50px" />
                                </Columns>
                            </f:Grid>
                        </Items>
                    </f:Region>
                </Regions>
            </f:RegionPanel>
            <uc1:WindowDialog runat="server" SizeType="Big" ID="WindowDialog" />
        </div>
    </form>
</body>
</html>

