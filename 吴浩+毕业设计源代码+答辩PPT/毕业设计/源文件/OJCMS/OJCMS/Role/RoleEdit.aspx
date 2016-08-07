<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="OJCMS.Role.RoleEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1"></f:PageManager>
        <f:Form runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px"
            Title="SimpleForm" ID="SimpleForm1">
            <Toolbars>
                <f:Toolbar runat="server" ID="Toolbar1" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSave" Text="保存" ValidateForms="SimpleForm1" runat="server" Icon="SystemSave" OnClick="btnSave_Click">
                        </f:Button>
                        <f:Button ID="btnCancel" Text="取消" runat="server" Icon="Cancel">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <%--<f:FormRow runat="server" ID="FormRow1">
                    <Items>
                        <f:DropDownList runat="server" ID="DDLAccess" LabelWidth="125px" AutoPostBack="true" OnSelectedIndexChanged="DDLAccess_SelectedIndexChanged" Label="请选择所属权限" Required="true" ShowRedStar="true"></f:DropDownList>
                    </Items>
                </f:FormRow>--%>
                <f:FormRow runat="server" Hidden="True">
                    <Items>
                        <f:Label runat="server" ID="Ds" />
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow2">
                    <Items>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtUserName" LabelWidth="70px" Label="用户名" Required="True" ShowRedStar="True"></f:TextBox>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtUserPassWord" LabelWidth="70px" Label="密码" Required="True" ShowRedStar="True"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow1">
                    <Items>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtName" LabelWidth="70px" Label="姓名" ShowRedStar="False"></f:TextBox>
                        <f:NumberBox runat="server" LabelAlign="Right" ID="TxtAge" LabelWidth="70px" Label="年龄" ShowRedStar="False" MaxValue="150" MinValue="0" NoDecimal="true" NoNegative="True">
                        </f:NumberBox>
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow4">
                    <Items>
                        <f:DatePicker runat="server" ID="TxtBirthday" LabelWidth="70px" Label="出生日期" ShowRedStar="False" LabelAlign="Right"></f:DatePicker>
                        <f:ToolbarFill runat="server" />
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow5">
                    <Items>
                        <f:TextArea runat="server" ID="TxtAddress" LabelWidth="70px" Label="家庭住址" ShowRedStar="False" AutoGrowHeight="False" Height="60" LabelAlign="Right"></f:TextArea>
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow3" runat="server">
                    <Items>
                        <f:HiddenField ID="Hid" runat="server"></f:HiddenField>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
