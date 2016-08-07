<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="OJCMS.User.UserView" %>

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
            <Rows>
                <f:FormRow runat="server" ID="FormRow2">
                    <Items>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtUserName" LabelWidth="70px" Label="用户名" Required="True" ShowRedStar="True" Readonly="True"></f:TextBox>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtUserPassWord" LabelWidth="70px" Label="密码" Required="True" ShowRedStar="True" Readonly="True"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow1">
                    <Items>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtName" LabelWidth="70px" Label="姓名" ShowRedStar="False" Readonly="True"></f:TextBox>
                        <f:NumberBox runat="server" LabelAlign="Right" ID="TxtAge" LabelWidth="70px" Label="年龄" ShowRedStar="False" MaxValue="150" MinValue="0" NoDecimal="true" NoNegative="True" Readonly="True">
                        </f:NumberBox>
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow4">
                    <Items>
                        <f:DatePicker runat="server" ID="TxtBirthday" LabelWidth="70px" Label="出生日期" ShowRedStar="False" LabelAlign="Right" Readonly="True"></f:DatePicker>
                        <f:ToolbarFill runat="server" />
                    </Items>
                </f:FormRow>
                <f:FormRow runat="server" ID="FormRow5">
                    <Items>
                        <f:TextArea runat="server" ID="TxtAddress" LabelWidth="70px" Label="家庭住址" ShowRedStar="False" AutoGrowHeight="False" Height="60" LabelAlign="Right" Readonly="True"></f:TextArea>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
