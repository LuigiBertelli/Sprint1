namespace Sprint1ApiProject.Models
{
    public class FileHandler
    {
        private string Path {  set; get; } = string.Empty;

        public FileHandler(string path)
        {
            Path = path;
        }

        // Função que acrescenta texto [txt] no arquivo que se encontra no caminho passado em path
        public void Append(string txt)
        {
            var file = File.AppendText(Path); //Abre arquivo no modo Append

            file.Write(txt); //Acrescenta o texto

            file.Close(); //Fecha o arquivo
        }
    }
}
