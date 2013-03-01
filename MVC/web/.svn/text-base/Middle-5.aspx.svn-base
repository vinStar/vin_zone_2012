<%@ Page Title="员工信息管理-中级验证-5" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Middle-5.aspx.cs" Inherits="Middle_5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles/jquery-ui.css" rel="stylesheet" media="screen" type="text/css" />

    <script src="scripts/jquery-ui.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        jQuery(document).ready(function(){
            jQuery("#tabs").tabs();
        });
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
                        },
                        <%=txtDescription.UniqueID %>: 
                        {
                            required: true
                        }
                 },
                 messages:
                 {
                        <%=txtUid.UniqueID %>:
                        {
                            required:"不输入用户名你怎么登陆?"
                        },
                        <%=txtPwd.UniqueID %>: 
                        {
                            required:"你不输入密码怎么行呢?",
                            minlength:"密码太短啦至少6位"
                        },
                        <%=txtRePwd.UniqueID %>: 
                        {
                            required:"你不输入确认密码怎么行呢?",
                            minlength:"密码太短啦至少6位"
                        },
                        <%=txtName.UniqueID %>: 
                        {
                            required:"你不会没名字吧?"
                        },
                        <%=txtAge.UniqueID %>: 
                        {
                            required:"您的年龄?",
                            range:"您的年龄有问题把,得在1-99岁之间哦"
                        },
                        <%=txtDescription.UniqueID %>: 
                        {
                            required: "您的个人描述还没写呢"
                        }
                 },
                 errorPlacement: function(error, element) {
                        error.html(error.html()+"<br/>");
                        error.appendTo("#errorContainer");
                },
                debug:true
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#baseinfo">基本信息</a></li>
            <li><a href="#personaldesc">个人描述</a></li>
             <li><a href="#contact">联系方式</a></li>
        </ul>
        <div id="baseinfo">
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
                        性别
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="required" disabled="true">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:DropDownList>
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
            </table>
        </div>
        <div id="personaldesc">
            <p>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"
                    Width="500px" Height="100px"></asp:TextBox>
            </p>
        </div>
           <div id="contact">
            <table cellpadding="1" cellspacing="1" border="1" width="50%" align="center">
                <tr>
                    <td>
                        用户名
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        密码
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        确认密码
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        姓名
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        年龄
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        性别
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="required" disabled="true">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="1">男</asp:ListItem>
                            <asp:ListItem Value="0">女</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        邮箱
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Button ID="Button2" runat="server" Text="提交" />
    </div>
    <div id="errorContainer">
    </div>

    <script type="text/javascript">
        InitRules();
    </script>

</asp:Content>
