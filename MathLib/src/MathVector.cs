using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace MathLib
{
    /// <summary>Math vector implementation.</summary>
    /// <inheritdoc cref="IMathVector"/> 
    public class MathVector : IMathVector
    {
        private List<double> Coords;

        /// <exception cref="IndexOutOfRangeException">
        /// Raised if vector does not have coordinate with given index.
        /// </exception>
        public double this[int i] {
            get
            {
                if (i >= Dimensions || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                return Coords[i];
            }
            set
            {
                if (i >= Dimensions || i < 0)
                    throw new IndexOutOfRangeException();

                Coords[i] = value;
            }
        }

        public int Dimensions => Coords.Count;

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
        /// Constructor.
        /// </summary>
        /// <param name="coords">Initial vector coordinates.</param>
        public MathVector(List<double> coords)
        {
            Coords = coords;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coords">Initial vector coordinates.</param>
        public MathVector(List<String> coords)
        {
            Coords = new List<double>();
            foreach (String coord in coords)
            {
                Coords.Add(double.Parse(coord, CultureInfo.InvariantCulture));
            }
        }

        /// <inheritdoc cref="IMathVector.CalcDistance(IMathVector)"/>
        /// <exception cref="ArithmeticException">
        /// Raised if vectors' dimensions do not match.
        /// </exception>
        public double CalcDistance(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot calculate Euclidean distance between vectors with different dimensions.");

            double squareSum = 0;
            for (int i = 0; i < Dimensions; i++)
                squareSum += Math.Pow(this[i] - vector[i], 2);

            return Math.Sqrt(squareSum);
        }

        /// <summary>
        /// Returns enumerator for iterating through the vector. 
        /// </summary>
        /// <returns>Enumerator for iterating through the vector.</returns>
        public IEnumerator GetEnumerator()
        {
            return Coords.GetEnumerator();
        }

        /// <inheritdoc cref="IMathVector.Invert"/>
        /// <exception cref="DivideByZeroException">
        /// Raised if at least 1 coordinate equals to 0.
        /// </exception>
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

        /// <inheritdoc cref="IMathVector.Multiply(IMathVector)"/>
        /// <exception cref="ArithmeticException">
        /// Raised if vectors' dimensions do not match.
        /// </exception>
        public IMathVector Multiply(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot multiply vectors with different dimensions.");

            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] * vector[i]);

            return new MathVector(newCoords);
        }

        public IMathVector MultiplyNumber(double number)
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] * number);

            return new MathVector(newCoords);
        }

        public IMathVector Negate()
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(-this[i]);

            return new MathVector(newCoords);
        }

        /// <inheritdoc cref="IMathVector.ScalarMultiply(IMathVector)"/>
        /// <exception cref="ArithmeticException">
        /// Raised if vectors' dimesions do not match.
        /// </exception>
        public double ScalarMultiply(IMathVector vector)
        {
            IMathVector product = Multiply(vector);
            double coordSum = 0;
            foreach (double coord in product)
                coordSum += coord;

            return coordSum;
        }

        /// <inheritdoc cref="IMathVector.Sum(IMathVector)"/>
        /// <exception cref="ArithmeticException">
        /// Raised if vectors' dimensions do not match.
        /// </exception>
        public IMathVector Sum(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                throw new ArithmeticException("Cannot add vectors with different dimensions.");

            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] + vector[i]);

            return new MathVector(newCoords);
        }

        public IMathVector SumNumber(double number)
        {
            var newCoords = new List<double>();
            for (int i = 0; i < Dimensions; i++)
                newCoords.Add(this[i] + number);

            return new MathVector(newCoords);
        }

        public bool Equals(IMathVector vector)
        {
            if (Dimensions != vector.Dimensions)
                return false;

            for (int i = 0; i < Dimensions; i++)
            {
                if (this[i] != vector[i])
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Sum between 2 vectors componentwise. Same as Sum().
        /// </summary>
        /// <param name="operand1">First addend.</param>
        /// <param name="operand2">Second addend.</param>
        /// <returns>Sum of given vectors - new vector.</returns>
        public static IMathVector operator +(MathVector operand1, MathVector operand2)
        {
            return operand1.Sum(operand2);
        }

        /// <summary>
        /// Sum between vector and scalar componentwise. Same as SumNumber().
        /// </summary>
        /// <param name="vector">Vector addend.</param>
        /// <param name="number">Scalar addend.</param>
        /// <returns>Sum of given vector and scalar - new vector.</returns>
        public static IMathVector operator +(MathVector vector, double number)
        {
            return vector.SumNumber(number);
        }

        /// <summary>
        /// Negate vector componentwise. Same as Negate().
        /// </summary>
        /// <param name="operand">Vector to negate.</param>
        /// <returns>Negative vector - new vector.</returns>
        public static IMathVector operator -(MathVector operand)
        {
            return operand.Negate();
        }

        /// <summary>
        /// Subtract one vector from another componentwise. 
        /// </summary>
        /// <param name="operand1">Minuend vector.</param>
        /// <param name="operand2">Subtrahend vector.</param>
        /// <returns>Difference between given vectors - new vector.</returns>
        public static IMathVector operator -(MathVector operand1, MathVector operand2)
        {
            return operand1.Sum(operand2.Negate());
        }

        /// <summary>
        /// Subtract scalar from vector componentwise.
        /// </summary>
        /// <param name="vector">Vector minuend.</param>
        /// <param name="number">Scalar subtrahend.</param>
        /// <returns>Result of subtraction - new vector.</returns>
        public static IMathVector operator -(MathVector vector, double number)
        {
            return vector + (-number);
        }

        /// <summary>
        /// Multiply 2 vectors componentwise. Same as Multiply().
        /// </summary>
        /// <param name="operand1">Multiplier vector.</param>
        /// <param name="operand2">Multiplicant vector.</param>
        /// <returns>Componentwise product between vectors - new vector.</returns>
        public static IMathVector operator *(MathVector operand1, MathVector operand2)
        {
            return operand1.Multiply(operand2);
        }

        /// <summary>
        /// Multiply vector with scalar componentwise. Same as MultiplyNumber(). 
        /// </summary>
        /// <param name="vector">Vector multiplicant.</param>
        /// <param name="number">Scalar multiplier.</param>
        /// <returns>Componentwise product of vector and scalar - new vector.</returns>
        public static IMathVector operator *(MathVector vector, double number)
        {
            return vector.MultiplyNumber(number);
        }

        /// <summary>
        /// Divide 2 vectors componentwise.
        /// </summary>
        /// <param name="operand1">Dividend vector.</param>
        /// <param name="operand2">Divisor vector.</param>
        /// <returns>Componentwise ratio between vectors - new vector.</returns>
        /// <exception cref="DivideByZeroException">
        /// Raised if at least 1 coordinate of divisor vector equals to zero.
        /// </exception>
        public static IMathVector operator /(MathVector operand1, MathVector operand2)
        {
            return operand1.Multiply(operand2.Invert());
        }

        /// <summary>
        /// Divide vector by scalar componentwise.
        /// </summary>
        /// <param name="vector">Vector dividend.</param>
        /// <param name="number">Scalar divisor.</param>
        /// <returns>Componentwise ratio between vector and scalar - new vector.</returns>
        /// <exception cref="DivideByZeroException">
        /// Raised if given number equals to zero.
        /// </exception>
        public static IMathVector operator /(MathVector vector, double number)
        {
            if (number == 0)
                throw new DivideByZeroException("Cannot divide vector by zero.");
            return vector.MultiplyNumber(1 / number);
        }

        /// <summary>
        /// Calculate dot product between 2 vectors. Same as ScalarMultiply().
        /// </summary>
        /// <param name="operand1">First factor vector.</param>
        /// <param name="operand2">Second factor vector.</param>
        /// <returns>Dot product between vectors - a number.</returns>
        public static double operator %(MathVector operand1, MathVector operand2)
        {
            return operand1.ScalarMultiply(operand2);
        }

        /// <summary>
        /// Check if vectors are equal. Same as Equals().
        /// </summary>
        /// <param name="operand1">First compared vector.</param>
        /// <param name="operand2">Second compared vector.</param>
        /// <returns>Result of equality operation - boolean value.</returns>
        public static bool operator ==(MathVector operand1, MathVector operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Check if vectors are not equal.
        /// </summary>
        /// <param name="operand1">First compared vector.</param>
        /// <param name="operand2">Second compared vector.</param>
        /// <returns>Result of inequality operation - boolean value.</returns>
        public static bool operator !=(MathVector operand1, MathVector operand2)
        {
            return !operand1.Equals(operand2);
        }
    }
}
