namespace Sprint1ApiProject.Models
{
    public class FileHandler
    {
        // Função que acrescenta texto [txt] no arquivo que se encontra no caminho passado em path
        public static void Append(string txt, string path)
        {
            var file = File.AppendText(path); //Abre arquivo no modo Append

            file.Write(txt); //Acrescenta o texto

            file.Close(); //Fecha o arquivo
        }
    }
}
