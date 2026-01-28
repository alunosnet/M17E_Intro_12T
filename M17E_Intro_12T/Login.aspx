<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="M17E_Intro_12T.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Email:
    <asp:TextBox ID="tb_email" runat="server" type="email" required="true"></asp:TextBox>
    <br />
    Palavra passe:
    <asp:TextBox ID="tb_password" runat="server" type="password" required="true" ></asp:TextBox>
    <br />
    <asp:Button ID="bt_login" runat="server" Text="Login" OnClick="bt_login_Click" />
    <br />
    <asp:Label ID="lb_erro" runat="server" />
</asp:Content>
