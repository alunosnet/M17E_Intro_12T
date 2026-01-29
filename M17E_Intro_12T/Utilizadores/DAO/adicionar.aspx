<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adicionar.aspx.cs" Inherits="M17E_Intro_12T.Utilizadores.DAO.adicionar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView DefaultMode="Insert" ID="FormView1" runat="server" DataKeyNames="id" DataSourceID="SqlUtilizadores" CellPadding="4" ForeColor="#333333">
                <EditItemTemplate>
                    email:
                    <asp:TextBox Text='<%# Bind("email") %>' runat="server" ID="emailTextBox" /><br />
                    nome:
                    <asp:TextBox Text='<%# Bind("nome") %>' runat="server" ID="nomeTextBox" /><br />
                    palavra_passe:
                    <asp:TextBox Text='<%# Bind("palavra_passe") %>' runat="server" ID="palavra_passeTextBox" /><br />
                    perfil:
                    <asp:TextBox Text='<%# Bind("perfil") %>' runat="server" ID="perfilTextBox" /><br />
                    sal:
                    <asp:TextBox Text='<%# Bind("sal") %>' runat="server" ID="salTextBox" /><br />
                    id:
                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel1" /><br />
                    <asp:LinkButton runat="server" Text="Update" CommandName="Update" ID="UpdateButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" />
                </EditItemTemplate>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <InsertItemTemplate>
                    email:
                    <asp:TextBox Text='<%# Bind("email") %>' runat="server" ID="emailTextBox" ForeColor="#FF5050" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="O email é obrigatório."
                        ControlToValidate="emailTextBox" Display="Dynamic"
                        ></asp:RequiredFieldValidator>
                    <br />
                    nome:
                    <asp:TextBox Text='<%# Bind("nome") %>' runat="server" ID="nomeTextBox" /><br />
                    palavra_passe:
                    <asp:TextBox Text='<%# Bind("palavra_passe") %>' type="password" runat="server" ID="palavra_passeTextBox" /><br />
                    perfil:
                    <asp:DropDownList SelectedValue='<%# Bind("perfil") %>' runat="server" ID="perfilTextBox">
                        <asp:ListItem Value="0" Text="Admin"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Funcionário"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Cliente"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        MinimumValue="0" MaximumValue="2" ControlToValidate="perfilTextBox"
                        ErrorMessage="O perfil deve ser um valor entre 0 e 2"></asp:RangeValidator>
                    <br />

                    <asp:LinkButton runat="server" Text="Insert" CommandName="Insert" ID="InsertButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancel" CommandName="Cancel" ID="InsertCancelButton" CausesValidation="False" />
                </InsertItemTemplate>
                <ItemTemplate>
                    email:
                    <asp:Label Text='<%# Bind("email") %>' runat="server" ID="emailLabel" /><br />
                    nome:
                    <asp:Label Text='<%# Bind("nome") %>' runat="server" ID="nomeLabel" /><br />
                    palavra_passe:
                    <asp:Label Text='<%# Bind("palavra_passe") %>' runat="server" ID="palavra_passeLabel" /><br />
                    perfil:
                    <asp:Label Text='<%# Bind("perfil") %>' runat="server" ID="perfilLabel" /><br />
                    sal:
                    <asp:Label Text='<%# Bind("sal") %>' runat="server" ID="salLabel" /><br />
                    id:
                    <asp:Label Text='<%# Eval("id") %>' runat="server" ID="idLabel" /><br />
                    <asp:LinkButton runat="server" Text="Edit" CommandName="Edit" ID="EditButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="Delete" CommandName="Delete" ID="DeleteButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="New" CommandName="New" ID="NewButton" CausesValidation="False" />
                </ItemTemplate>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:FormView>
            <asp:SqlDataSource runat="server" ID="SqlUtilizadores" 
                ConnectionString='<%$ ConnectionStrings:ConnectionString %>' 
                DeleteCommand="DELETE FROM [utilizadores] WHERE [id] = @id" 
                InsertCommand="INSERT INTO [utilizadores] ([email], [nome], [palavra_passe], [perfil], [sal]) VALUES (@email, @nome, HASHBYTES('SHA2_512',concat(@palavra_passe,@sal)), @perfil, @sal)" 
                ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>' 
                SelectCommand="SELECT [email], [nome], [palavra_passe], [perfil], [sal], [id] FROM [utilizadores]" 
                UpdateCommand="UPDATE [utilizadores] SET [email] = @email, [nome] = @nome, [palavra_passe] = @palavra_passe, [perfil] = @perfil, [sal] = @sal WHERE [id] = @id">
                <DeleteParameters>
                    <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="email" Type="String"></asp:Parameter>
                    <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                    <asp:Parameter Name="palavra_passe" Type="String"></asp:Parameter>
                    <asp:Parameter Name="perfil" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="sal" Type="Int32" DefaultValue="0"></asp:Parameter>
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="email" Type="String"></asp:Parameter>
                    <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                    <asp:Parameter Name="palavra_passe" Type="String"></asp:Parameter>
                    <asp:Parameter Name="perfil" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="sal" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
