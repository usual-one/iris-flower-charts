using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IrisFlowerCharts.References.Files
{
    /// <summary>Service that performs file operations.</summary>
    static public class FileManager
    {
        /// <summary>
        /// Read file and get its lines.
        /// </summary>
        /// <param name="path">Path to file.</param>
        /// <returns>List of read file lines.</returns>
        /// <exception cref="FileNotFoundException">
        /// Raised if file with given path does not exist.
        /// </exception>
        static public List<string> ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File does not exist");
            }
            return File.ReadAllLines(path).ToList();
        }
    }
}
