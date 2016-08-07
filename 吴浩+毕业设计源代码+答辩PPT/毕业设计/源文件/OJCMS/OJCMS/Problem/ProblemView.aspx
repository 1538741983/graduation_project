<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProblemView.aspx.cs" ValidateRequest="false" Inherits="OJCMS.Problem.ProblemView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/res/ueditor/themes/default/css/ueditor.min.css" />
    <title></title>
</head>
<body>
    <form id="_form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="SimpleForm1" />
        <f:Form LabelWidth="70px" LabelAlign="Right" runat="server" ShowBorder="false" ShowHeader="false" BodyPadding="10px"
            Title="SimpleForm" ID="SimpleForm1" AutoScroll="True">
            <Items>
                <f:GroupPanel runat="server" Layout="Table" ColumnWidth="50% 50%" TableConfigColumns="2" Title="基本信息">
                    <Items>
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtTitle" LabelWidth="70px" Label="标题" Required="True" ShowRedStar="True" Readonly="True"></f:TextBox>
                        <f:NumberBox runat="server" LabelAlign="Right" ID="TxtDifficulty" LabelWidth="70px" Label="难度" ShowRedStar="False" MaxValue="5" MinValue="0" NoDecimal="true" NoNegative="True" Readonly="True" />
                        <f:NumberBox runat="server" LabelAlign="Right" ID="TxtTimeLimit" LabelWidth="70px" Label="时间限制" ShowRedStar="False" MinValue="0" NoDecimal="true" NoNegative="True" Readonly="True" />
                        <f:NumberBox runat="server" LabelAlign="Right" ID="TxtMemeoryLimit" LabelWidth="70px" Label="内存限制" ShowRedStar="False" MinValue="0" NoDecimal="true" NoNegative="True" Readonly="True" />
                        <f:TextBox runat="server" LabelAlign="Right" ID="TxtSource" LabelWidth="70px" Label="来源" TableColspan="2" ShowRedStar="False" Readonly="True"></f:TextBox>
                    </Items>
                </f:GroupPanel>
                <f:Panel ID="Panel1" Layout="Column" ShowHeader="false" ShowBorder="false" runat="server">
                    <Items>
                        <f:Label ID="Label1" Width="80px" ColumnWidth="100%" runat="server" CssClass="marginr" ShowLabel="false"
                            Text="描述：">
                        </f:Label>
                        <f:ContentPanel ID="ContentPanel3" ColumnWidth="100%" Height="300" runat="server" ShowBorder="false" ShowHeader="false">
                            <script type="text/plain" id="Editor"></script>
                        </f:ContentPanel>
                        <f:TextArea ID="TxtInput" runat="server" Label="输入" LabelAlign="Top" AutoGrowHeight="False" Height="150" ColumnWidth="100%" Readonly="True" />
                        <f:TextArea ID="TxtOutput" runat="server" Label="输出" LabelAlign="Top" AutoGrowHeight="False" Height="150" ColumnWidth="100%" Readonly="True" />
                        <f:TextArea ID="TxtSampleInput" runat="server" Label="样例输入" LabelAlign="Top" AutoGrowHeight="False" Height="150" ColumnWidth="100%" Readonly="True" />
                        <f:TextArea ID="TxtSampleOutput" runat="server" Label="样例输出" LabelAlign="Top" AutoGrowHeight="False" Height="150" ColumnWidth="100%" Readonly="True" />
                        <f:TextArea ID="TxtHint" runat="server" Label="提示" LabelAlign="Top" AutoGrowHeight="False" Height="150" ColumnWidth="100%" Readonly="True" />
                    </Items>
                </f:Panel>
            </Items>
        </f:Form>
    </form>

    <script type="text/javascript">
        window.UEDITOR_HOME_URL = '<%= ResolveUrl("/res/ueditor/") %>';
    </script>
    <script type="text/javascript" src="/res/js/jquery.min.js"></script>
    <script type="text/javascript" src="/res/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" src="/res/ueditor/ueditor.all.min.js"></script>
    <script type="text/javascript">

        var containerClientID = '<%= ContentPanel3.ClientID %>';

        var editor;
        var content;
        F.ready(function () {
            editor = UE.getEditor('Editor', {
                initialFrameWidth: '100%',
                initialFrameHeight: '100%',
                autoHeightEnabled: false,
                autoFloatEnabled: false,
                onready: function () {
                    // 重新布局外部容器
                    editor.setContent(content);
                    doLayout();
                }
            });
        });

        function doLayout() {
            if ((editor && editor.isReady)) {
                // 重新布局外部容器
                F(containerClientID).updateLayout();
            }
        }

        // 更新编辑器内容
        function updateEditor(content) {
            if (editor && editor.isReady) {
                editor.setContent(content);
            }
        }
    </script>
</body>
</html>
