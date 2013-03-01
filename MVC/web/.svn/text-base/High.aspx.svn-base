<%@ Page Title="员工信息管理-高级验证" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="High.aspx.cs" Inherits="High" %>

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
                    <%=TextBox1.UniqueID %>: 
                        {
                            required: true
                        },
                        <%=txtUid.UniqueID %>: 
                        {
                            required: true
                        },
//                        <%=txtPwd.UniqueID %>: 
//                        {
//                            required: true,
//                            minlength: 6
//                        },
//                        <%=txtRePwd.UniqueID %>: 
//                        {
//                            required: true,
//                            minlength: 6,
//                            equalTo:"#<%=txtPwd.ClientID %>"
//                        },
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
                       <%=TextBox1.UniqueID %>:
                        {
                            required:"不输入怎么搞?"
                        },
                        <%=txtUid.UniqueID %>:
                        {
                            required:"不输入用户名你怎么登陆?"
                        },
//                        <%=txtPwd.UniqueID %>: 
//                        {
//                            required:"你不输入密码怎么行呢?",
//                            minlength:"密码太短啦至少6位"
//                        },
//                        <%=txtRePwd.UniqueID %>: 
//                        {
//                            required:"你不输入确认密码怎么行呢?",
//                            minlength:"密码太短啦至少6位"
//                        },
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
                 }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="tabs">
        <a href="http://www.revolvermaps.com/?target=enlarge&amp;i=8i38bn43auk&amp;color=ff8a00&amp;m=0">
            <img src="http://ri.revolvermaps.com/h/m/a/0/ff8a00/128/0/8i38bn43auk.png" width="256"
                height="128" alt="Map" style="border: 0px;" /></a>
        <ul>
            <li><a href="#baseinfo">基本信息</a></li>
            <li><a href="#personaldesc">个人描述</a></li>
        </ul>
        <asp:Button ID="Button4" runat="server" Text="show" OnClick="Button4_Click" />
        <div id="baseinfo" class="validationGroup">
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
                        <asp:TextBox ID="txtPwd" ValidationGroup="" TextMode="Password" runat="server"></asp:TextBox>
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
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="required">
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
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button3" runat="server" Text="基本信息提交" CssClass="causesValidation"
                            OnClick="Button3_Click" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" >
                aaaaaaaaaaaaaaaaaaaa show
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                bbbbbbbbbbbbbbbbbbbb show</asp:Panel>
            <asp:Panel ID="PnlAddEducationMask" runat="server" ClientIDMode="Static" Visible="false">
            </asp:Panel>
            <asp:Panel ID="PnlAddEducationCntr" ClientIDMode="Static" CssClass="WindowsDialog"
                runat="server" Visible="false">
                <asp:ImageButton ID="imgCloseInboxWindow" CausesValidation="false" ClientIDMode="Static"
                    Width="20px" Height="20px" ImageUrl="images/error.png" runat="server" OnClick="imgCloseInboxWindow_Click" />
                <asp:Button ID="Button2" runat="server" CssClass="causesValidation" Text="copy" OnClick="Button2_Click" />
                <asp:TextBox ID="TextBox1" ClientIDMode="Static" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" ClientIDMode="Static" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
        <div id="personaldesc" class="validationGroup">
            <p>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="500px"
                    Height="100px"></asp:TextBox>
            </p>
            <asp:Button ID="Button1" runat="server" Text="描述提交" CssClass="causesValidation" />
        </div>
    </div>
    <script type="text/javascript">
        InitRules();
        isValidationGroup = true;
    </script>
</asp:Content>
