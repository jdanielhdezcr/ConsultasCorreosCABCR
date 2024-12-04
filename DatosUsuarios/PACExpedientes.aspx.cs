using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace DatosUsuarios
{
    public partial class PACExpedientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void cmd_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            if (cell == null || cell.CellValue == null) return string.Empty;

            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[int.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        public static DataTable LeerExcel(string fileName)
        {
            var table = new DataTable();

            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = workbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                // Leer encabezados
                var headerRow = rows.ElementAt(0);
                foreach (Cell cell in headerRow)
                {
                    table.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                }

                // Leer datos
                foreach (Row row in rows.Skip(1)) // Saltar encabezados
                {
                    var tempRow = table.NewRow();
                    int columnIndex = 0;

                    foreach (Cell cell in row.Descendants<Cell>())
                    {
                        tempRow[columnIndex++] = GetCellValue(spreadSheetDocument, cell);
                    }

                    table.Rows.Add(tempRow);
                }
            }

            return table;
        }

        public static void GenerateReport(DataTable table, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        // Procesar iniciales del nombre
                        string initials = GetInitials(row[1].ToString());

                        // Procesar fecha de última cuota
                        string ultimaCuota = row[4].ToString();
                        string[] cuotaParts = ultimaCuota.Split(',');
                        string mesCuota = cuotaParts[0];
                        string anioCuota = cuotaParts[1];

                        // Generar la línea del archivo
                        file.WriteLine($"El (La) Lic(da). {initials} al mes de {mesCuota} del {anioCuota} debe {row[5]} cuotas, total de ₡ {row[3]} colones. Exp. {row[2]}");
                    }
                    catch (Exception ex)
                    {
                        // Escribir errores específicos en el archivo
                        file.WriteLine($"Error procesando la línea: {ex.Message}. Datos del afiliado: {row[1]}");
                    }
                }
            }

            // Descargar archivo como respuesta
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Charset = "utf-8";
            context.Response.AddHeader("content-disposition", "attachment; filename=" + Path.GetFileName(fileName));
            context.Response.WriteFile(fileName);
            context.Response.End();
        }

        public static string GetInitials(string name)
        {
            try
            {
                var names = name.Split(' ').Where(n => !string.IsNullOrWhiteSpace(n));
                return string.Join(".", names.Select(n => n[0]));
            }
            catch
            {
                return "ERROR";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string appPath = Request.PhysicalApplicationPath;

            if (FileUpload1.HasFile)
            {
                string extension = Path.GetExtension(FileUpload1.FileName);
                string[] validFileTypes = { ".xlsx" };

                if (validFileTypes.Contains(extension.ToLower()))
                {
                    string savePath = Path.Combine(appPath, FileUpload1.FileName);
                    FileUpload1.SaveAs(savePath);

                    try
                    {
                        DataTable table = LeerExcel(savePath);
                        string outputPath = Path.Combine(appPath, "PACs.txt");
                        GenerateReport(table, outputPath);
                        Label1.Text = "Archivo generado exitosamente.";
                    }
                    catch (Exception ex)
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Error al procesar el archivo: " + ex.Message;
                    }
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Formato de archivo no válido. Use un archivo .xlsx.";
                }
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "No se seleccionó ningún archivo.";
            }
        }
    }
}
