using IrisFlowerCharts.Files;
using System.Collections.Generic;
using System.Linq;

namespace IrisFlowerCharts.Models
{
    public class StatsCalculator
    {
        public List<Iris> Irises { get; private set; }

        public List<string> FeatureNames { get; set; }

        public bool IsLoaded()
        {
            return Irises.Count != 0;
        }

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
