using IrisFlowerCharts.Files;
using System.Collections.Generic;
using System.Linq;

namespace IrisFlowerCharts.Models
{
    /// <summary>Statistics metrics calculator.</summary>
    public class StatsCalculator
    {
        /// <summary>Get loaded list of Iris flowers.</summary>
        public List<Iris> Irises { get; private set; }

        /// <summary>Get list of Iris flowers' feature names.</summary>
        public List<string> FeatureNames { get; set; }

        /// <summary>Constructor.</summary>
        public StatsCalculator()
        {
            Irises = new List<Iris>();
        }

        /// <summary>
        /// Check if Iris flowers are loaded.
        /// </summary>
        /// <returns>True if flowers are loaded otherwise false.</returns>
        public bool IsLoaded()
        {
            return Irises.Count != 0;
        }

        /// <summary>
        /// Load Iris flowers from given file.
        /// </summary>
        /// <param name="path">Path of file containing Iris flowers.</param>
        /// <exception cref="Files.Exceptions.FileNotFoundException">
        /// Raised if file with given path does not exist.
        /// </exception>
        public void LoadIrises(string path)
        {
            List<List<string>> csv = CSVFileManager.ReadCSVFile(path, ",");

            FeatureNames = csv[0];
            FeatureNames.RemoveAt(FeatureNames.Count - 1);

            csv.RemoveAt(0);
            Irises = new List<Iris>();
            foreach (List<string> line in csv)
                Irises.Add(new Iris(line));
        }

        /// <summary>
        /// Calculate average Iris flowers' features based on type.
        /// </summary>
        /// <returns>List of flowers with average features among same type flowers.</returns>
        public List<Iris> CalculateAverageIrises()
        {
            var averageIrises = new Dictionary<string, Iris>();
            
            foreach (KeyValuePair<string, List<Iris>> irises in SortIrisesByType())
            {
                var averageFeatures = irises.Value[0].Features;
                for (int i = 1; i < irises.Value.Count; i++)
                    averageFeatures = (MathLib.MathVector)(averageFeatures + irises.Value[i].Features); 
                averageFeatures = (MathLib.MathVector) (averageFeatures / irises.Value.Count);

                averageIrises.Add(irises.Key, new Iris(averageFeatures, irises.Key));
            }

            return averageIrises.Values.ToList();
        }

        /// <summary>
        /// Calculate euclidean distances between flowers' average features vectors.
        /// </summary>
        /// <returns>Dictionary with flowers' types as key and euclidean distance as value.</returns>
        public Dictionary<List<string>, double> CalculateEuclideanDistances()
        {
            var euclideanDistances = new Dictionary<List<string>, double>();

            List<Iris> averageIrises = CalculateAverageIrises();
            for (int i = 0; i < averageIrises.Count; i++)
            {
                var secondIrisIndex = i + 1;
                if (secondIrisIndex == averageIrises.Count)
                    secondIrisIndex = 0;

                euclideanDistances.Add(new List<string>() { averageIrises[i].Type, averageIrises[secondIrisIndex].Type }, 
                                       averageIrises[i].Features.CalcDistance(averageIrises[secondIrisIndex].Features)); 
            }

            return euclideanDistances;
        }

        /// <summary>
        /// Sort Iris flowers basing on their type.
        /// </summary>
        /// <returns>Dictionary with type as key and list of flowers as value.</returns>
        private Dictionary<string, List<Iris>> SortIrisesByType()
        {
            var sortedIrises = new Dictionary<string, List<Iris>>();
            
            foreach (Iris iris in Irises)
            {
                if (!sortedIrises.ContainsKey(iris.Type))
                    sortedIrises.Add(iris.Type, new List<Iris>());
                sortedIrises[iris.Type].Add(iris);
            }

            return sortedIrises;
        }
    }
}
