<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FunctionNew.aspx.cs" Inherits="OJCMS.menu.FunctionNew" %>

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
                <f:Toolbar runat="server" ID="Toolbar1" ToolbarAlign="Right" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSaveRefresh" Text="保存" ValidateForms="SimpleForm1" runat="server" Icon="SystemSave" OnClick="btnSaveRefresh_Click">
                        </f:Button>
                        <f:Button ID="btnCancel" Text="取消" runat="server" Icon="Cancel" OnClick="btnSaveRefresh_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ID="FormRow1" runat="server">
                    <Items>
                        <f:Label ID="LabMenuID" runat="server" Label="菜单编号" LabelWidth="70px" LabelAlign="Right">
                        </f:Label>
                        <f:Label ID="LabMenuName" runat="server" Label="菜单名称" LabelWidth="70px" LabelAlign="Right">
                        </f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow2" runat="server">
                    <Items>
                        <f:TextBox runat="server" ID="TxtMenuId" Label="功能编号" LabelWidth="70px" LabelAlign="Right" NextFocusControl="btnSaveRefresh" />
                        <f:TextBox ID="TxtFunctionName" runat="server" Label="功能名称" LabelWidth="70px" LabelAlign="Right" NextFocusControl="btnSaveRefresh" />
                    </Items>
                </f:FormRow>
                <f:FormRow ID="FormRow3" runat="server">
                    <Items>
                        <f:TextBox ID="TxtLink" runat="server" Label="链接" LabelWidth="70px" LabelAlign="Right" NextFocusControl="btnSaveRefresh">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>

