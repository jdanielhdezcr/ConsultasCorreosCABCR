<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeBehind="suspenmorosidad.aspx.cs" Inherits="DatosUsuarios.suspenmorosidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type ="text/javascript">

    var validFilesTypes=["xlsx"];

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

            
<h5>Cargue el archivo Excel con el siguiente orden de columnas y en formato XLSX: CARNET, NOMBRE AGREMIADO,EXPEDIENTE,SALDO,ULTIMA CUOTA,CANTIDAD CUOTAS</h5>

            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
        <br />
        <br />
            <asp:Button ID="cmd_upload" runat="server" OnClientClick = "return ValidateFile()" OnClick="generarlineas" Text="Cargar Archivo" class="btn btn-success" />
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
