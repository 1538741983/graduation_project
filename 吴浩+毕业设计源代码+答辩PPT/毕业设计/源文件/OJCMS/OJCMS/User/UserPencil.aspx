<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPencil.aspx.cs" Inherits="GDMM.ChildPages.UserPencil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager runat="server" ID="PageManager1" AutoSizePanelID="SimpleForm1"></f:PageManager>
        <f:Form runat="server" ID="SimpleForm1" ShowBorder="false" ShowHeader="false">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1">
                    <Items>
                        <f:Button runat="server" ID="BtnClose" Text="关闭"></f:Button>
                        <f:Button runat="server" ID="BtnSave" OnClick="BtnSave_Click" ValidateForms="SimpleForm1" Text="保存后关闭"></f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnDelete" runat="server" Icon="Delete" EnablePostBack="true" Text="清除当前角色机器码" Hidden="true"
                            OnClick="btnDelete_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow runat="server" ID="FormRow1" ColumnWidths="30% 70%">
                    <Items>
                        <f:Label runat="server" ID="LabUserID" Label="用户ID"></f:Label>
                        <f:DropDownList runat="server" ID="DDLAccessName" Label="选择所属权限" Required="true" ShowRedStar="true"></f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow2">
                    <Items>
                        <f:TextBox runat="server" ID="TxtUserName" LabelWidth="100px" Label="输入用户名" Required="true" ShowRedStar="true"></f:TextBox>
                        <f:TextBox runat="server" ID="TxtUserPassWord" LabelWidth="100px" Label="输入用户密码" Required="true" ShowRedStar="true"></f:TextBox>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
