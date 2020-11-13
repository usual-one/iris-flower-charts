using System.Collections.Generic;

namespace IrisFlowerCharts
{
    /// <summary>Fisher's Iris flower.</summary>
    public class Iris
    {
        /// <summary>Get flower's features.</summary>
        public MathLib.MathVector Features { get; }

        /// <summary>Get flower's type.</summary>
        public string Type { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="features">Flower's features.</param>
        /// <param name="type">Flower's type.</param>
        public Iris(MathLib.MathVector features, string type)
        {
            Features = features;
            Type = type;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="initList">Initializer list that contains features and type.</param>
        public Iris(List<string> initList)
        {
            Type = initList[^1];

            initList.RemoveAt(initList.Count - 1);
            Features = new MathLib.MathVector(initList);
        }
    }
}
