using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Words;
using Models;
using OfficeOpenXml;

namespace LerArquivoExcel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo arquivoBase = new FileInfo(@"C:\Users\Everton Fabricio\Desktop\Gerador.xlsx"); //caminho para ler o arquivo xlsx
            var saida = new StreamWriter(@"C:\Users\Everton Fabricio\Desktop\teste.txt"); //caminho onde será salvo o txt que to usando pra teste

            DataTable tabela = new DataTable(); // classe que vou usar pra ordenar a tabela pelo campo CEP


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //declaração da licença do EPPlus

            using (ExcelPackage package = new ExcelPackage(arquivoBase))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(); //pego a primeira planilha do arquivo base

                int colCount = worksheet.Dimension.End.Column; // conta quantas colunas tem a planilha
                int rowCount = worksheet.Dimension.End.Row; //conta quantas linhas tem a planilha

                string[,] matriz = new string[rowCount - 1, colCount - 1]; //matriz pra salvar as informações da planilha. Declarei o tamanho com linha e coluna menos 1, pq a contagem começa em 0


                //esse for preenche minha matriz toda com as informaçoes da planilha.
                for (int i = 0; i < rowCount - 1; i++)
                {

                    for (int j = 0; j < colCount - 1; j++)
                    {
                        matriz[i, j] = worksheet.Cells[i + 1, j + 1].Value == null ? "" : worksheet.Cells[i + 1, j + 1].Value.ToString();
                    }
                }


                //esse for inclui as colunas de uma tabela, com o "cabeçalho" dela, com as informações que estão na minha matriz.
                //Daria pra fazer a inclusão direto da planilha e não pela matriz, mas eu vou usar a matriz mais tarde, então deixa assim.
                for (int i = 1; i <= colCount; i++)
                {
                    var col = worksheet.Cells[1, i].Value.ToString();
                    tabela.Columns.Add(col);
                }

                //esse for inclui as linhas da tabela, de acordo com as colunas que foram preenchidas no for anterior.
                for (int l = 2; l <= rowCount; l++)
                {
                    var d = new string[colCount];
                    int index = 0;
                    for (int i = 1; i <= colCount; i++)
                    {
                        d[index] = worksheet.Cells[l, i].Value == null ? "" : worksheet.Cells[l, i].Value.ToString();
                        index++;
                    }
                    tabela.Rows.Add(d);
                }


                //Como eu criei o cabeçalho da minha tabela, eu consigo ordenar ela por cep informando a coluna CEP aqui
                tabela.DefaultView.Sort = "CEP";
                tabela = tabela.DefaultView.ToTable();



                StringBuilder sbArquivo = new StringBuilder(); //metodo usado pra concatenar varios textos. Como são 40 colunas, fica mais facil fazer assim do que na mão.

                for (int i = 0; i < tabela.Rows.Count; i++) //for pra selecionar a linha que será preenchida, começando da linha 0 (obvio)
                {
                    var j = 0;
                    foreach (var item in matriz) //foreach pra pegar o item da minha matriz de acordo com a posição dele, e preencher as informações pra exibição.
                    {
                        if (j < colCount)
                        {
                            sbArquivo.Append(item + ">> " + tabela.Rows[i][j] + Environment.NewLine);
                            j++;
                        }
                        else
                            break;

                    }
                }
                saida.WriteLine(sbArquivo); //salvei um arquivo txt pra testar e poder verificar se salvou tudo certo!!
                saida.Close();
            }






            // a partir daqui, exporto pra word de acordo com o template do documento. Não ta funcionando ainda.



            Document word = new Document();
            DocumentBuilder builder = new DocumentBuilder(word);

            Font font = builder.Font;
            font.Size = 14;
            font.Bold = true;
            font.Color = System.Drawing.Color.Black;
            font.Name = "Segoe UI";
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            builder.Writeln("ROTA DE TRABALHO - " + DateTime.Now.ToString("dd/MM/yyyy") + "\n\n");
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            font.Size = 11;
            builder.Writeln("Nome da Equipe: EQP-0001 \n");

            for (int i = 0; i < tabela.Rows.Count; i++)
            {

                font.Underline = Underline.Single;
                font.Size = 9;
                builder.Writeln($"Contrato:    {i * 2}      - Assinante:   {i * 3}        ");

                font.Underline = Underline.None;
                font.Bold = false;
                builder.Writeln($"Endereço:     - CEP:  {i}   -000");
                builder.Writeln($"O.S:   {i * 5}         -   TIPO O.S:     {i}                  ");
                builder.Writeln("\n\n\n");

            }
            word.Save("Teste.docx");







        }
    }
}
