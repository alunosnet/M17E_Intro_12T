<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="M17E_Intro_12T.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="X"></asp:Label>
            <asp:TextBox ID="tb_x" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Y"></asp:Label>
            <asp:TextBox ID="tb_y" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="bt_somar" runat="server" Text="Somar" OnClick="bt_somar_Click" />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:Button ID="bt_resultado" runat="server" 
                Text="Mostrar resultado" OnClick="bt_resultado_Click" />
            <asp:Button ID="bt_cookies" runat="server" Text="Criar cookie"
                    OnClick="bt_cookies_Click"/>
        </div>
    </form>
</body>
</html>
