using System;
using System.Collections;
using System.Collections.Generic;

namespace MathLib
{
    /// <summary>
    /// Реализация интерфейса IMathVector.
    /// </summary>
    public class MathVector : IMathVector
    {
        /// <summary>
        /// Список координат (элементов вектора).
        /// </summary>
        private List<double> Coords;

        /// <summary>
        /// Индексатор для доступа к элементам вектора. Нумерация с нуля.
        /// </summary>
        /// <param name="i">Индекс для получения элемента.</param>
        /// <returns>Координату по указанному индексу.</returns>
        public double this[int i] {
            get
            {
                if (i >= Length || i < 0)
                    throw new IndexOutOfRangeException();

                return Coords[i];
            }
            set
            {
                if (i >= Length || i < 0)
                    throw new IndexOutOfRangeException();

                Coords[i] = value;
            }
        }

        /// <summary>
        /// Получить размерность вектора (количество координат).
        /// </summary>
        public int Dimensions => Coords.Count;

        /// <summary>
        /// Рассчитать длину (модуль) вектора.
        /// </summary>
        public double Length {
            get
            {
                double squareSum = 0;
                foreach (double coord in Coords)
                    squareSum += Math.Pow(coord, 2);

                return Math.Sqrt(squareSum);
            }
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coords">Координаты для вектора.</param>
        public MathVector(List<double> coords)
        {
            Coords = coords;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="coords">Координаты для вектора.</param>
        public MathVector(List<String> coords)
        {
            foreach (String coord in coords)
            {
                Coords.Add(double.Parse(coord));
            }
        }

        /// <summary>
        /// Вычислить Евклидово расстояние до другого вектора.
        /// </summary>
        /// <param name="vector">Вектор для вычисления расстояния от текущего.</param>
        /// <returns>Евклидово расстояние до данного вектора.</returns>
        public double CalcDistance(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot calculate Euclidean distance between vectors with different dimensions.");

            double squareSum = 0;
            for (int i = 0; i < Dimensions; i++)
                squareSum = Math.Pow(this[i] - vector[i], 2);

            return Math.Sqrt(squareSum);
        }

        /// <summary>
        /// Возвращает енумератор, с помощью которого можно проитерироваться по вектору. 
        /// </summary>
        /// <returns>Енумератор для итерации по вектору.</returns>
        public IEnumerator GetEnumerator()
        {
            return Coords.GetEnumerator();
        }

        public IMathVector Invert()
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
            {
                if (this[i] == 0)
                    throw new DivideByZeroException("Cannot invert vector with coordinate equal to zero");

                newCoords.Add(1 / this[i]);
            }
            return new MathVector(newCoords);
        }

        /// <summary>
        /// Покомпонентное умножение с другим вектором.
        /// </summary>
        /// <param name="vector">Вектор для умножения с данным.</param>
        /// <returns>Вектор - векторное произведение текущего и данного векторов.</returns>
        public IMathVector Multiply(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot multiply vectors with different dimensions.");

            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] * vector[i]);

            return new MathVector(newCoords);
        }

        /// <summary>
        /// Покомпонентное умножение на число.
        /// </summary>
        /// <param name="number">Число для умножения с вектором.</param>
        /// <returns>Вектор - произведение текущего вектора и числа.</returns>
        public IMathVector MultiplyNumber(double number)
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] * number);

            return new MathVector(newCoords);
        }

        /// <summary>
        /// Покомпонентное отрицание.
        /// </summary>
        /// <returns>Вектор с координатами противоположными изначальным.</returns>
        public IMathVector Negate()
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i]);

            return new MathVector(newCoords);
        }

        /// <summary>
        /// Скалярное умножение на другой вектор.
        /// </summary>
        /// <param name="vector">Вектор для умножения с данным.</param>
        /// <returns>Скалярное произведение текущего и данного векторов.</returns>
        public double ScalarMultipy(IMathVector vector)
        {
            IMathVector product = Multiply(vector);
            double coordSum = 0;
            foreach (double coord in product)
                coordSum += coord;

            return coordSum;
        }

        /// <summary>
        /// Сложение с другим вектором.
        /// </summary>
        /// <param name="vector">Вектор для сложения с данным.</param>
        /// <returns>Вектор - сумму текущего и данного векторов.</returns>
        public IMathVector Sum(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot add vectors with different dimensions.");

            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] + vector[i]);

            return new MathVector(newCoords);
        }

        /// <summary>
        /// Покомпонентное сложение с числом.
        /// </summary>
        /// <param name="number">Число для сложения с вектором.</param>
        /// <returns>Вектор - сумму текущего вектора и числа.</returns>
        public IMathVector SumNumber(double number)
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] + number);

            return new MathVector(newCoords);
        }

        /// <summary>
        /// Покомпонентное сложение с другим вектором.
        /// </summary>
        public static IMathVector operator +(MathVector operand1, MathVector operand2)
        {
            return operand1.Sum(operand2);
        }

        /// <summary>
        /// Покомпонентное сложение с числом.
        /// </summary>
        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        /// <summary>
        /// Покомпонентное отрицание.
        /// </summary>
        public static IMathVector operator -(MathVector operand)
        {
            return operand.Negate();
        }

        /// <summary>
        /// Покомпонентное вычитание с другим вектором.
        /// </summary>
        public static IMathVector operator -(MathVector operand1, MathVector operand2)
        {

            return operand1.Sum(operand2.Negate());
        }

        /// <summary>
        /// Покомпонентное вычитание с числом.
        /// </summary>
        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector + (-number);
        }

        /// <summary>
        /// Покомпонентное умножение с другим вектором.
        /// </summary>
        public static IMathVector operator *(MathVector operand1, MathVector operand2)
        {
            return operand1.Multiply(operand2);
        }

        /// <summary>
        /// Покомпонентное умножение с числом.
        /// </summary>
        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        /// <summary>
        /// Покомпонентное деление с другим вектором.
        /// </summary>
        public static IMathVector operator /(MathVector operand1, MathVector operand2)
        {
            return operand1.Multiply(operand2.Invert());
        }

        /// <summary>
        /// Покомпонентное деление с числом.
        /// </summary>
        public static IMathVector operator /(MathVector vector, double number)
        {
            return vector.MultiplyNumber(1 / number);
        }

        /// <summary>
        /// Скалярное умножение двух векторов.
        /// </summary>
        public static double operator %(MathVector operand1, MathVector operand2)
        {
            return operand1.ScalarMultipy(operand2);
        }

    }
}
