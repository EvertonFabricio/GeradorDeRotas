//using System.Collections.Generic;
//using System.IO;

//namespace MVC.Models
//{
//    public class Arquivos
//    {
//        public int arquivoID { get; set; }
//        public string arquivoNome { get; set; }
//        public string arquivoCaminho { get; set; }

//    }



//    public List<Arquivos> GetArquivos()
//    {
//        List<Arquivos> lstArquivos = new List<Arquivos>();
//        DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Everton Fabricio\Desktop\GeradorDeRotas\MVC\");

//        int i = 0;
//        foreach (var item in dirInfo.GetFiles())
//        {
//            lstArquivos.Add(new Arquivos()
//            {
//                arquivoID = i + 1,
//                arquivoNome = item.Name,
//                arquivoCaminho = dirInfo.FullName + @"\" + item.Name
//            });
//            i = i + 1;
//        }
//        return lstArquivos;
//    }
//}
