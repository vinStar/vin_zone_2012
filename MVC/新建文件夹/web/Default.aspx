<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script language="javascript" type="text/javascript">
    function wait()
    {
        document.getElementById("bSearch").style.display='none';
        document.getElementById('book_span_msg').style.display='';     
        return true ;
    }    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>aa</asp:ListItem>
                <asp:ListItem>bb</asp:ListItem>
                <asp:ListItem>cc</asp:ListItem>
                <asp:ListItem>dd</asp:ListItem>
                <asp:ListItem>ee</asp:ListItem>
                <asp:ListItem>ff</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <table width="100%">
                <tr>
                    <td style="width: 600px; text-align: center;">
                        &nbsp;<asp:Button ID="bSearch" OnClientClick="return wait()" TabIndex="14" runat="server"
                                CssClass="button1" Text="立即查询" OnClick="Button1_Click"></asp:Button>
                            <span id="book_span_msg" style="display: none; color: Red;">
                                <img src="images/loading_little.gif" onmouseover="this.src='image/loading_mid.gif'"
                                    alt="页面加载中" />
                                数据加载中，请稍候!</span> 
                    </td>
                    <td style="padding-right: 20px; float: right;">
                        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="btnToHtml" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
