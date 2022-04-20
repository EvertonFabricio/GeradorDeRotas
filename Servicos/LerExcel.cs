using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace Servicos
{
    public class LerExcel
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                FileInfo arquivoBase = new FileInfo(@"C:\Users\Everton Fabricio\Desktop\GeradorDeRotas 2.0\GeradorDeRotas\bin\Debug\net5.0\DataBase\Gerador.xlsx");
                var saida = new StreamWriter(@"C:\Users\Everton Fabricio\Desktop\GeradorDeRotas\GeradorDeRotas 2.0\bin\Debug\net5.0\DataBase\Saida.docx");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(arquivoBase))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    int colCount = worksheet.Dimension.End.Column;

                    for (int coluna = 1; coluna < colCount; coluna++)
                    {
                        saida.WriteLine(worksheet.Cells[1, coluna].Value.ToString());
                    }
                    saida.Close();
                }
            }
        }
    }
}
