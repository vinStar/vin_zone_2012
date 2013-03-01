<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PDFtest.aspx.cs" Inherits="PDFtest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<iframe src="ATS-Plan.pdf" style="width:718px; height:700px;" frameborder="0"></iframe>
</asp:Content>

