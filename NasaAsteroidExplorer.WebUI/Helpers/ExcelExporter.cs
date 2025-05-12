using ClosedXML.Excel;
using NasaAsteroidExplorer.Application.DTOs;


namespace NasaAsteroidExplorer.Helpers
{
    public static class ExcelExporter
    {
        public static MemoryStream ExportToExcel(List<NeoAsteroidDto> asteroids)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.AddWorksheet("Asteroids");

    
            ws.Cell(1, 1).Value = "Name";
            ws.Cell(1, 2).Value = "URL";
            ws.Cell(1, 3).Value = "Magnitude";
            ws.Cell(1, 4).Value = "Hazardous";

            var headerRange = ws.Range("A1:D1");
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

         
            for (int i = 0; i < asteroids.Count; i++)
            {
                var a = asteroids[i];
                int row = i + 2;

                ws.Cell(row, 1).Value = a.Name;
                ws.Cell(row, 2).Value = a.Url;
                ws.Cell(row, 3).Value = a.Magnitude;
                ws.Cell(row, 4).Value = a.IsHazardous ? "Yes" : "No";
            }

            
            ws.Columns().AdjustToContents();

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }
    }
}
