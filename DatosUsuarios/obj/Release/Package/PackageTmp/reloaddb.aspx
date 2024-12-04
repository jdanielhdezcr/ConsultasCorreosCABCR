<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="reloaddb.aspx.cs" Inherits="DatosUsuarios.reloaddb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">

            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="cmd_check" runat="server" Text="Vaciar Tabla" OnClick="cmd_check_Click" />

            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="cmd_upload" runat="server" OnClick="Button2_Click" Text="Cargar Archivo" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
        <div>


            <br />


        </div>
        <div style="text-align: center">
        <asp:Button ID="cmd_return" runat="server" style="text-align: center" href="Default.aspx" Text="volver al incio" OnClick="cmd_return_Click" />
            </div>
</asp:Content>
