<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DatosUsuarios.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div align="center">   
    <br />
            Sitio de consulta de agremiados y Actualización de sitios</div>
        <div style="text-align: center">

            <br class="auto-style1" />
            <span class="auto-style1">Seleccione la acción a realizar</span><br />
            
            
        </div>
        <table class="auto-style1" align="center">  
            <tr>  
                <td>  
                    <asp:Button ID="cmd_check" runat="server" Text="Actualizar Base de agremiados CIJUL" OnClick="cmd_check_Click" class="btn btn-primary" />  
                </td>  
                
                <td>
                    <asp:Button ID="cmd_reload" runat="server" Text="Consultar datos de agremiados" href="Verify.aspx" OnClick="cmd_reload_Click1" class="btn btn-light"/>
                    </td>
                <td>
                    <asp:Button ID="cmd_uploadweb" runat="server" Text="Actualizar Base de agremiados Sitio Web" OnClick="cmd_uploadweb_Click" class="btn btn-success" />
            
                    </td>                
            </tr>
            <tr>
                <td>
                    <asp:Button ID="cmd_deleteuser" runat="server" Text="Borrar Usuario" OnClick="cmd_deleteuser_Click" class="btn btn-danger" />
                </td>
                <td>
                    <asp:Button ID="cmd_add" runat="server" Text="Crear nuevo Usuario" OnClick="cmd_adduser_Click" class="btn btn-warning" />
                </td>
            </tr>
               </table>

</asp:Content>
