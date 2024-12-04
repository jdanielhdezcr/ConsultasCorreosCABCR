<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="Adduser.aspx.cs" Inherits="DatosUsuarios.Adduser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">

            <br />
            Ingrese los datos solicitados del nuevo usuario<br />
            <table class="auto-style1" align="center">
                <tr>
                    <td>Usuario nuevo</td>
                    <td>
                        <asp:TextBox ID="Txt_username" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                <tr>
                    <td class="auto-style1">Número de carné</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="Txt_carnet" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            <br />
            <br />
            <%--<asp:TextBox ID="txt_codigocer" runat="server" Width="195px"></asp:TextBox>--%>
            <asp:Button ID="cmd_add" runat="server" Text="Agregar nuevo usuario" OnClick="cmd_add_Click" />

            <asp:Button ID="cmd_reload" runat="server" OnClick="cmd_reload_Click" Text="Limpiar campos" />

            &nbsp;&nbsp;
             <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="correo electrónico:" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="cmd_return" runat="server" OnClick="cmd_return_Click" Text="Volveer al inicio" />
            <br />
        </div>
</asp:Content>
