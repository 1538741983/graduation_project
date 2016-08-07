<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionMenuNew.aspx.cs" Inherits="OJCMS.menu.FunctionMenuNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
            Title="SimpleForm">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>
                        <f:Button ID="btnSaveRefresh" Text="保存后关闭" runat="server" Icon="SystemSaveNew" OnClick="btnSaveRefresh_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ID="FormRow1" runat="server">
                    <Items>
                        <f:Label ID="LabMenuID" runat="server" Label="菜单编号" LabelWidth="70px" LabelAlign="Right" Hidden="true">
                        </f:Label>
                        <f:Label ID="LabMenuName" runat="server" Label="菜单名称" LabelWidth="70px" LabelAlign="Right" Hidden="true">
                        </f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow2" runat="server">
                    <Items>
                        <f:TextBox ID="TxtMenuName" runat="server" Label="菜单名称" LabelWidth="70px" LabelAlign="Right" NextFocusControl="btnSaveRefresh">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
