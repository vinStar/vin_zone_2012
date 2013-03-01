<%@ Page Title="员工信息管理-高级验证2" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="High-2.aspx.cs" Inherits="High_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function InitRules() {
            opts = {
             rules:
                {
                    <%=txtUid.UniqueID %>: 
                    {
                        required: true,
                        remote:{
                            type: "POST",
                            dataType:"xml",
                            async: false,
                            url: "WebService.asmx/CheckUid",
                            data: {uid:function(){ return jQuery("#<%=txtUid.ClientID %>").val();}},
                            dataFilter: function(dataXML) {
                                var result = new Object();
                                result.Result = jQuery(dataXML).find("Result").text();
                                result.Msg = jQuery(dataXML).find("Msg").text();
                                if (result.Result == "-1") {
                                    result.Result = false;
                                    return result;
                                }
                                else {
                                    result.Result = result.Result == "1" ? true : false;
                                    return result;
                                }
                            }
                        }
                    }
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <table cellpadding="1" cellspacing="1" border="1" width="50%" align="center">
    <tr>
        <td>
            用户名
        </td>
        <td>
            <asp:TextBox ID="txtUid" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            密码
        </td>
        <td>
            <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" CssClass="required" minlength="6"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            姓名
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" CssClass="required"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            年龄
        </td>
        <td>
            <asp:TextBox ID="txtAge" runat="server" class="required number" max="99" min="1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            邮箱
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="email"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Button ID="Button1" runat="server" Text="提交" />
        </td>
    </tr>
    </table>
    <script type="text/javascript">
        InitRules();
    </script>
</asp:Content>
