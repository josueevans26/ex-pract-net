using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Ex1.Controllers
{
    public class ExportController : Controller
    {
        private readonly AppDbContext _context;

        public ExportController(AppDbContext context)
        {
            _context = context;
        }

        // Exportar encuestas a un archivo Excel
        public async Task<IActionResult> ExportarEncuestasToExcel()
        {
            // 1. Obtener los datos de la tabla Encuestas desde la base de datos
            var encuestas = await _context.Encuestas.ToListAsync();

            // 2. Crear un objeto DataTable y llenarlo con los datos de Encuestas
            DataTable dataTable = new DataTable("Encuestas");
            // Agregar las columnas
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("Respuesta 1", typeof(string)),
                new DataColumn("Respuesta 2", typeof(string)),
                new DataColumn("Respuesta 3", typeof(string)),
                new DataColumn("Respuesta 4", typeof(string)),
                new DataColumn("Respuesta 5", typeof(string)),
                new DataColumn("Respuesta 5_1", typeof(string)),
                new DataColumn("Respuesta 5_2", typeof(string)),
                new DataColumn("Respuesta 6", typeof(decimal)),
                new DataColumn("Respuesta 7", typeof(string)),
                new DataColumn("Respuesta 8", typeof(string))
            });
            // Llenar las filas
            foreach (var encuesta in encuestas)
            {
                dataTable.Rows.Add(encuesta.Id, encuesta.Respuesta1, encuesta.Respuesta2, encuesta.Respuesta3,
                    encuesta.Respuesta4, encuesta.Respuesta5, encuesta.Respuesta6, encuesta.Respuesta7, encuesta.Respuesta8);
            }

            // 3. Exportar los datos a Excel
            var memoryStream = new System.IO.MemoryStream();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(dataTable);
                workbook.SaveAs(memoryStream);
            }
            memoryStream.Position = 0;

            // 4. Devolver el archivo Excel como un FileResult
            return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "encuestas.xlsx");
        }
    }
}