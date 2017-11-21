<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testhtmlcode.aspx.cs" Inherits="testhtmlcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" runat="server" id="abc" value="aaa\\\a" />
    </div>
    
    <div id="ggs" runat="server"></div>
    <div id="Div1" runat="server"></div>
    <%
        string hello = "abc\"hello";
         %>
    <input type="text" value=<%=hello %> />
    </form>
</body>
</html>
