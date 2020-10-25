namespace IrisFlowerCharts.Files
{
    /// <summary>
    /// Класс, работающий с файлами (чтение и т. д.)
    /// </summary>
    class FileManager
    {
        public System.Collections.Generic.List<System.String> ReadFile(System.String path)
        {
            if (!System.IO.File.Exists(path))
            {
                throw new Exceptions.FileNotFoundException("File does not exist");
            }
            return new System.Collections.Generic.List<System.String>(System.IO.File.ReadAllLines(path));
        }
    }
}
