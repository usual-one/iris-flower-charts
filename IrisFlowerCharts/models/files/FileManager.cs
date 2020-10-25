using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IrisFlowerCharts.Files
{
    /// <summary>
    /// Класс, работающий с файлами (чтение и т. д.)
    /// </summary>
    static public class FileManager
    {
        /// <summary>
        /// Считывает файл и возвращает строки из него.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns></returns>
        static public List<string> ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exceptions.FileNotFoundException("File does not exist");
            }
            return File.ReadAllLines(path).ToList();
        }
    }
}
