<%@ Page Title="员工信息管理-中级验证-4" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Middle-4.aspx.cs" Inherits="Middle_4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <script src="scripts/jquery.metadata.js" type="text/javascript"></script>
 <script type="text/javascript">
     jQuery.metadata.setType("attr", "validate");
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="1" cellspacing="1" border="1" width="50%" align="center">
        <tr>
            <td>
                用户名
            </td>
            <td>
                <asp:TextBox ID="txtUid" runat="server" validate="{required:true,messages:{required:'不输入用户名你怎么登陆?'}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                密码
            </td>
            <td>
                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" validate="{required:true,minlength:6,messages:{required:'你不输入密码怎么行呢?',minlength:'密码太短啦至少6位'}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                确认密码
            </td>
            <td>
                <asp:TextBox ID="txtRePwd" TextMode="Password" runat="server" validate="{required:true,minlength:6,equalTo:'#<%=txtPwd.ClientID %>'}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                姓名
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" validate="{required:true}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                年龄
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server" validate="{required:true,number:true,range:[1,99],messages:{range:'您的年龄有问题把,得在1-99岁之间哦'}}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                邮箱
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" validate="{email:true}"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="提交" />
                <asp:Button ID="btnNoValidate" runat="server" Text="点我不会引发验证哦" />
            </td>
        </tr>
    </table>
</asp:Content>

