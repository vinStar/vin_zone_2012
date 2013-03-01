<%@ Page Title="员工信息管理-初级验证" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Base.aspx.cs" Inherits="_Base" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <asp:TextBox ID="TextBox1" runat="server" CssClass="number"></asp:TextBox>
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
                <asp:Button ID="Button1" runat="server" Text="提交" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
