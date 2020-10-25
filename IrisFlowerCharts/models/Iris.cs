using System;
using System.Collections.Generic;

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
        public String Type { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="features">Вектор свойств Ириса</param>
        /// <param name="type">Тип Ириса</param>
        public Iris(MathLib.MathVector features, String type)
        {
            Features = features;
            Type = type;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="initList">Список строк для инициализации.</param>
        public Iris(List<String> initList)
        {
            Type = initList[^1];

            initList.RemoveAt(initList.Count - 1);
            Features = new MathLib.MathVector(initList);
        }
    }
}
