using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IrisFlowerCharts.Files
{
    /// <summary>Services that performs operations with CSV-formatted files.</summary>
    static public class CSVFileManager
    {
        /// <summary>
        /// Read CSV-formatted file and get its content.
        /// </summary>
        /// <param name="path">Path to CSV-formatted file.</param>
        /// <param name="separator">Separator that is used in file.</param>
        /// <returns>Content of the file - list of separated lines.</returns>
        /// <exception cref="FileNotFoundException">
        /// Raised if file with given path does not exist.
        /// </exception>
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
