<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="reloaddb.aspx.cs" Inherits="DatosUsuarios.reloaddb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type ="text/javascript">

    var validFilesTypes=["csv"];

    function ValidateFile()

    {

      var file = document.getElementById("<%=FileUpload1.ClientID%>");

      var label = document.getElementById("<%=Label1.ClientID%>");

      var path = file.value;

      var ext=path.substring(path.lastIndexOf(".")+1,path.length).toLowerCase();

      var isValidFile = false;

      for (var i=0; i<validFilesTypes.length; i++)

      {

        if (ext==validFilesTypes[i])

        {

            isValidFile=true;

            break;

        }

      }

      if (!isValidFile)

      {

        label.style.color="red";

          label.innerHTML ="Archivo no válido. seleccione un archivo con" +

         " extension:\n\n"+validFilesTypes.join(", ");

      }

      return isValidFile;

     }

    </script>
    <div style="text-align: center">

            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
         <br />
            <asp:Button ID="cmd_check" runat="server" Text="Vaciar Tabla" OnClick="cmd_check_Click" class="btn btn-warning" />

            <br />
         <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
         <br />
            <asp:Button ID="cmd_upload" runat="server" OnClientClick = "return ValidateFile()" OnClick="Button2_Click" Text="Cargar Archivo" class="btn btn-success"/>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </div>
        <div>


            <br />


        </div>
        <div style="text-align: center">
        <asp:Button ID="cmd_return" runat="server" style="text-align: center" href="Default.aspx" Text="volver al incio" OnClick="cmd_return_Click" class="btn btn-secondary" />
            </div>
</asp:Content>
