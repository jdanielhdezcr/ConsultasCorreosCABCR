<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="Deleteuser.aspx.cs" Inherits="DatosUsuarios.deleteuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">

            <br />
            Ingrese el usuario de correo y haga clic en eliminar<br />
            <asp:TextBox ID="txt_codigocer" runat="server" Width="195px"></asp:TextBox>
            <asp:Button ID="cmd_delete" runat="server" Text="Borrar usuario" OnClick="cmd_delete_Click" class="btn btn-danger btn-lg" />

            <asp:Button ID="cmd_reload" runat="server" OnClick="cmd_reload_Click" Text="Limpiar campos" />

            &nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="correo electrónico:" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="cmd_return" runat="server" OnClick="cmd_return_Click" Text="Volver al inicio" />
            <br />
        </div>
</asp:Content>
