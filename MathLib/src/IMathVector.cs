using System.Collections;

namespace MathLib
{
    /// <summary>
    /// Интерфейс математического вектора.
    /// </summary>
    public interface IMathVector : IEnumerable
    {
        /// <summary>
        /// Получить размерность вектора (количество координат).
        /// </summary>
        int Dimensions { get; }

        /// <summary>
        /// Рассчитать длину (модуль) вектора.
        /// </summary>
        double Length { get; }

        /// <summary>
        /// Индексатор для доступа к элементам вектора. Нумерация с нуля.
        /// </summary>
        /// <param name="i">Индекс для получения элемента.</param>
        /// <returns>Координату по указанному индексу.</returns>
        double this[int i] { get; set; }

        /// <summary>
        /// Покомпонентное сложение с числом.
        /// </summary>
        /// <param name="number">Число для сложения с вектором.</param>
        /// <returns>Вектор - сумму текущего вектора и числа.</returns>
        IMathVector SumNumber(double number);

        /// <summary>
        /// Покомпонентное умножение на число.
        /// </summary>
        /// <param name="number">Число для умножения с вектором.</param>
        /// <returns>Вектор - произведение текущего вектора и числа.</returns>
        IMathVector MultiplyNumber(double number);

        /// <summary>
        /// Сложение с другим вектором.
        /// </summary>
        /// <param name="vector">Вектор для сложения с данным.</param>
        /// <returns>Вектор - сумму текущего и данного векторов.</returns>
        IMathVector Sum(IMathVector vector);

        /// <summary>
        /// Покомпонентное умножение с другим вектором.
        /// </summary>
        /// <param name="vector">Вектор для умножения с данным.</param>
        /// <returns>Вектор - векторное произведение текущего и данного векторов.</returns>
        IMathVector Multiply(IMathVector vector);

        /// <summary>
        /// Скалярное умножение на другой вектор.
        /// </summary>
        /// <param name="vector">Вектор для умножения с данным.</param>
        /// <returns>Скалярное произведение текущего и данного векторов.</returns>
        double ScalarMultipy(IMathVector vector);

        /// <summary>
        /// Вычислить Евклидово расстояние до другого вектора.
        /// </summary>
        /// <param name="vector">Вектор для вычисления расстояния от текущего.</param>
        /// <returns>Евклидово расстояние до данного вектора.</returns>
        double CalcDistance(IMathVector vector);
    }
}
