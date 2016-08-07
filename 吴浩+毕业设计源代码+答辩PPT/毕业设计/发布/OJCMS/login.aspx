<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OJCMS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #1D3647;
        }
    </style>
    <%--<link rel="shortcut icon" href="icon/logo.ico" />--%>
    <link href="images/skin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="42" valign="top">
                    <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                        <tr>
                            <td width="1%" height="21">&nbsp;
                            </td>
                            <td height="42">&nbsp;
                            </td>
                            <td width="17%">&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                        <tr>
                            <td width="49%" align="right">
                                <table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                    <tr>
                                        <td height="138" valign="top">
                                            <table width="89%" height="427" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="149">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="80" align="right" valign="top">
                                                        <%--<img src="images/logo.png" width="279" height="68" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="198" align="right" valign="top">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="1%">&nbsp;
                            </td>
                            <td width="50%" valign="bottom">
                                <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4%">&nbsp;
                                        </td>
                                        <td width="96%" height="38">
                                            <span class="login_txt_bt"><font size="+2">在线评测后台管理系统</font></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td height="21">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328">
                                                <tr>
                                                    <td height="164" colspan="2" align="center">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" height="143" id="table212">
                                                            <tr>
                                                                <td style="white-space: nowrap; overflow: hidden;" height="38" class="top_hui_text"
                                                                    align="left">账 &nbsp; 号:&nbsp;&nbsp;
                                                                </td>
                                                                <td height="38" colspan="2" class="top_hui_text" align="left">
                                                                    <asp:TextBox runat="server" ID="TxtZH" name="username" size="120" Style="width: 162px" />
                                                                    <asp:Label ID="LBtishi1" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="white-space: nowrap; overflow: hidden;" height="38" class="top_hui_text"
                                                                    align="left">密 &nbsp; 码:&nbsp;&nbsp;
                                                                </td>
                                                                <td height="35" colspan="2" class="top_hui_text" align="left">
                                                                    <asp:TextBox runat="server" ID="TxtMM" name="password" TextMode="Password" size="120"
                                                                        Style="width: 162px" />
                                                                    <asp:Label ID="LBtishi2" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="35">&nbsp;
                                                                </td>
                                                                <td width="150" height="35" align="left">
                                                                    <asp:Button runat="server" name="button1" type="submit" Style="width: 45px; height: 25px; background-image: url('/images/llogin.jpg'); text-align: center; cursor: pointer"
                                                                        class="button" ID="Submit" Text="登 录" OnClick="Submit_Click" BorderStyle="None" />
                                                                </td>
                                                                <td width="72%" class="top_hui_text" align="left">
                                                                    <asp:Button name="button2" runat="server" type="submit" Style="width: 45px; height: 25px; background-image: url('/images/llogin.jpg'); text-align: center; cursor: pointer"
                                                                        class="button" ID="cs" Text="退 出" OnClick="cs_Click" BorderStyle="None" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="433" height="164" align="right" valign="bottom">
                                                       <%-- <img src="images/login-wel.gif" width="242" height="138" />--%>
                                                    </td>
                                                    <td width="57" align="right" valign="bottom">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="20">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                        <tr>
                            <td align="center">
                                <span class="login-buttom-txt"></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
