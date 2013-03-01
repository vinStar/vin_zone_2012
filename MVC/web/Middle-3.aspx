<%@ Page Title="员工信息管理-中级验证-3" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Middle-3.aspx.cs" Inherits="Middle_3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function InitRules() {
            opts = {
                 rules:
                 {
                        <%=txtUid.UniqueID %>: 
                        {
                            required: true
                        },
                        <%=txtPwd.UniqueID %>: 
                        {
                            required: true,
                            minlength: 6
                        },
                        <%=txtRePwd.UniqueID %>: 
                        {
                            required: true,
                            minlength: 6,
                            equalTo:"#<%=txtPwd.ClientID %>"
                        },
                        <%=txtName.UniqueID %>: 
                        {
                            required: true
                        },
                        <%=txtAge.UniqueID %>: 
                        {
                            required: true,
                            number: true,
                            range: [1,99]
                        },
                        <%=txtEmail.UniqueID %>: 
                        {
                            email: true
                        }
                 },
                 messages:
                 {
                        <%=txtPwd.UniqueID %>:
                        {
                            required:"不输入用户名你怎么登陆?"
                        },
                        <%=txtPwd.UniqueID %>: 
                        {
                            required:"你不输入密码怎么行呢?",
                            minlength:"密码太短啦至少6位"
                        },
                        <%=txtAge.UniqueID %>: 
                        {
                            range:"您的年龄有问题把,得在1-99岁之间哦"
                        }
                 }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                确认密码
            </td>
            <td>
                <asp:TextBox ID="txtRePwd" TextMode="Password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                姓名
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                年龄
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                邮箱
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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

