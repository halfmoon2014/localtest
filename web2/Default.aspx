<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-1.8.0.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function show() {
            alert(document.getElementById("text2").value);
            alert(document.getElementById("mydiv").innerHTML);
            var sql = "update " + $("#text2").attr("value") + "hello";
            myAjax(sql);
        }
        function myAjax(v1, xact_abort) {
            if (xact_abort == undefined) {
                xact_abort = "";
            }
            if ($.trim(xact_abort) != "off" && $.trim(xact_abort) != "on") {
                xact_abort = "";
            }
            var r; var wid;
            try {
                wid = this.wid.value;
            } catch (e) { wid = -1; }

            $.ajax({ type: 'post',
                url: 'WebService.asmx/zdwh_up',
                async: false,
                data: { v1: v1, xact_abort: xact_abort, wid: wid },
                error: function (e) { r = -1; },
                success: function (data) {
                  
                }
            });

            return r;
        }
        function DJFocus(a, b, c) {

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input type="button" onclick="show()" value="test" />
    <div id="mydiv" runat="server">    
    </div>
    <%
        string chr = "hello\\\"world";
        string s2 = ThreadOne().Tables[0].Rows[0]["value"].ToString();
         %>
        
        <input type=text    class='tlin' style='text-align:right; width:75;' oncontextmenu=MyDmxz(name,value) readonly   onfocus=DJFocus(0,'sjcjsl',value)  value=""  name=mytext_0_sjcjsl id=mytext_0_sjcjsl>
    <input type="text" value=<%=chr%>   />
    <input type="text" runat="server" id="bid" />
    <input type="text" id="text2" value="<%=s2.Replace("\"","&quot;").Replace(" ","&nbsp;") %>" />
    <div id="join" runat="server"></div>
    </form>
</body>
</html>
