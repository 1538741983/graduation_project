<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        欢迎 <strong><%: Page.User.Identity.Name %></strong>!
        [ <%: Html.ActionLink("注销", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("登录", "LogOn", "Account") %> ]
<%
    }
%>
