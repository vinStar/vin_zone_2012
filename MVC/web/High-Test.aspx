<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="High-Test.aspx.cs" Inherits="High_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles/jquery-ui.css" rel="stylesheet" media="screen" type="text/css" />
    <script src="scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
       
        function InitRules() {
            opts = {
                 rules:
                 {
                    <%=txtTest.UniqueID %>: 
                        {
                            required: true
                        }
                 },
                 messages:
                 {
                       <%=txtTest.UniqueID %>:
                        {
                            //required:"不输入怎么搞?"
                        }
                 }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <br />
        <asp:TextBox ID="txtTest" ToolTip="填上呗" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Show" runat="server" OnClick="Show_Click" Text="Button" CssClass="causesValidation" />
    </p>
    <asp:Panel ID="Panel1" runat="server">
        here is a
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        here is b
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <script type="text/javascript">
        InitRules();
        isValidationGroup = false;
    </script>
</asp:Content>
