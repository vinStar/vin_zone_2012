<%@ Page Title="员工信息管理-中级验证-1" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Middle-1.aspx.cs" Inherits="Middle_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="1" cellspacing="1" border="1" width="50%" align="center">
        <tr>
            <td>
                用户名
            </td>
            <td>
                <asp:TextBox ID="txtUid" runat="server" CssClass="required"></asp:TextBox>
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
                确认密码
            </td>
            <td>
                <asp:TextBox ID="txtRePwd" TextMode="Password" runat="server" CssClass="required" minlength="6" equalTo='#<%=txtPwd.ClientID %>'></asp:TextBox>
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
</asp:Content>

