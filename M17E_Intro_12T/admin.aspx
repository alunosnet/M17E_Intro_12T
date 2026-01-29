<%@ Page Title="" Language="C#" MasterPageFile="~/MP_Admin.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="M17E_Intro_12T.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<% Response.Write(Session["nome"]);  %>
    <% if (Session["perfil"]!=null && Session["perfil"].ToString() == "0") {%>
        <h1>Olá administrador 0</h1>
    <% } else {  %>
        <h1>Olá administrador 1</h1>
    <% } %>
    <asp:Button ID="bt_logout" runat="server" Text="Terminar sessão" OnClick="bt_logout_Click" />
</asp:Content>
