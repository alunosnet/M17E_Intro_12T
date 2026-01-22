<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compras.aspx.cs" Inherits="M17E_Intro_12T.compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Comprar PC</h1>
            <!-- Nome -->
           Nome: <asp:TextBox ID="tb_nome" runat="server"  
                placeholder="Nome do Cliente" required MaxLength="50" />
            <br />
            <!-- Data Nascimento -->
            Data Nascimento: 
            <asp:Calendar ID="c_data_nasc" runat="server"></asp:Calendar>
            <br />
            <!-- Email -->
            Email:
            <asp:TextBox ID="tb_email" runat="server" type="email"
                required placeholder="Inserir um email" />
            <br />
            <!-- Marca -->
            Marca:
            <asp:DropDownList OnSelectedIndexChanged="dd_marcas_SelectedIndexChanged" ID="dd_marcas" runat="server" AutoPostBack="True">
                <asp:ListItem Text="Escolhe uma marca" Value="-1"></asp:ListItem>
                <asp:ListItem Text="HP" Value="0"></asp:ListItem>
                <asp:ListItem Text="ASUS" Value="1"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <!-- Modelo -->
            Modelo:
            <asp:DropDownList ID="dd_modelos" runat="server"></asp:DropDownList>
            <br />
            <!-- Processador -->
            Processador:<br />
            <asp:RadioButton GroupName="processador" ID="rb_intel" runat="server" Text="Intel" /><br />
            <asp:RadioButton GroupName="processador" ID="rb_amd" runat="server" Text="AMD" /><br />
            <asp:RadioButton GroupName="processador" ID="rb_outro" runat="server" Text="Outro" /><br />
            <!-- Aceitar condições -->
            <asp:CheckBox ID="cb_aceitar" runat="server" Text="Aceito as condições." />
            <br />
            <!-- Foto perfil -->
            <asp:FileUpload ID="fu_foto" runat="server" />
            <br />
            <asp:Button ID="bt_comprar" runat="server" Text="Comprar" />
            <% Response.Write(DateTime.Now); %>
            <!-- Aviso dos cookies -->
        </div>
    </form>
</body>
</html>
