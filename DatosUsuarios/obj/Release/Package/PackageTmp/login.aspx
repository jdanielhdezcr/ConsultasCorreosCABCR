<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DatosUsuarios.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="ValidateUser">
    </asp:Login>
        </div>
    
        
</asp:Content>
