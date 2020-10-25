using System;

namespace IrisFlowerCharts
{
    /// <summary>
    /// Класс, представляющий Ирис Фишера
    /// </summary>
    class Iris
    {
        /// <summary>
        /// Свойства Ириса
        /// </summary>
        public MathLib.MathVector Features { get; }

        /// <summary>
        /// Тип Ириса
        /// </summary>
        public System.String Type { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="features">Вектор свойств Ириса</param>
        /// <param name="type">Тип Ириса</param>
        Iris(MathLib.MathVector features, System.String type)
        {
            Features = features;
            Type = type;
        }
    }
}
