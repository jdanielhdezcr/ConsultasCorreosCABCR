<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="DatosUsuarios.Verify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center">

            <br />
            Ingrese el carné del agremiado y haga clic en Verificar<br />
            <br />
            <div>
            <table class="auto-style1" align="center">
                <tr>
                    <td>
            
            <asp:TextBox ID="txt_codigocer" runat="server" Width="195px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="Txt_cedula" runat="server" Width="195px"></asp:TextBox>
                    </td>
                     <td>
                        <asp:TextBox ID="Txtusername" runat="server" Width="195px"></asp:TextBox>
                    </td>
                        </tr>
                <tr>
                    <td>
            <asp:Button ID="cmd_check" runat="server" Text="Verificar por carné" OnClick="cmd_check_Click" class="btn btn-light"/>
                    </td>
                    <td>
                        <asp:Button ID="cmd_cedula" runat="server" Text="Verificar por cédula" OnClick="cmd_cedula_Click" class="btn btn-light"/>
                    </td>
                    <td>
                        <asp:Button ID="cmd_username" runat="server" Text="Verificar por usuario de correo" OnClick="cmd_username_Click" class="btn btn-light"/>
                    </td>
                    </tr>
                </table>
            
            <asp:Button ID="cmd_reload" runat="server" OnClick="cmd_reload_Click" Text="Limpiar campos" />
            </div>
        </div>
        <div>


            <table class="auto-style1" align="center">
               <tr>
                   <td>
                       <asp:Label ID="Label5" runat="server" Text="Nombre: "></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                        </td>
                   </tr>
                    <tr>
                   <td>
                       <asp:Label ID="Label6" runat="server" Text="Cédula: "></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                        </td>
                   </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label7" runat="server" Text="Fecha de Incorporación: "></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        </td>
                   </tr>
                 <tr>
                   <td>
                        <asp:Label ID="Label8" runat="server" Text="Condición profesional: "></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                        </td>
                   </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label1" runat="server" Text="Carnet:" Visible="False"></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                   </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label3" runat="server" Text="Correo electrónico: " Visible="False"></asp:Label>
                   </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                   </tr>
            </table>
                      
           

        </div>
</asp:Content>
