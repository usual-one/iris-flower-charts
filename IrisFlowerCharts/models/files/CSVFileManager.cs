using System.Collections.Generic;
using System.Linq;

namespace IrisFlowerCharts.Files
{
    static public class CSVFileManager
    {
        /// <summary>
        /// Считывает разделенные значения из файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <param name="separator">Разделитель значений.</param>
        /// <returns></returns>
        static public List<List<string>> ReadCSVFile(string path, string separator)
        {
            List<string> lines = FileManager.ReadFile(path);
            var values = new List<List<string>>();
            
            foreach (string line in lines)
            {
                values.Add(line.Split(separator).ToList());
            }
            return values;
        }
    }
}
