using System.Collections;

namespace MathLib
{
    /// <summary>Math vector interface</summary>
    public interface IMathVector : IEnumerable
    {
        /// <summary>Get the dimension of the vector (number of cooridnates).</summary>
        int Dimensions { get; }

        /// <summary>Calculate magnitude (size) of the vector.</summary>
        double Length { get; }

        /// <summary>
        /// Index (access elements by index). Numbering starts at 0.
        /// </summary>
        /// <param name="i">Element index.</param>
        /// <returns>Vector coordinate with given index number.</returns>
        double this[int i] { get; set; }

        /// <summary>
        /// Inverts the vector componentwise (divides 1 over each component).
        /// </summary>
        /// <returns>Inverted vector - new vector.</returns>
        IMathVector Invert();

        /// <summary>
        /// Negates the vector componentwise.
        /// </summary>
        /// <returns>Negative vector - new vector.</returns>
        IMathVector Negate();

        /// <summary>
        /// Sum with scalar componentwise.
        /// </summary>
        /// <param name="number">Scalar to sum with.</param>
        /// <returns>Sum of current vector and given scalar - new vector.</returns>
        IMathVector SumNumber(double number);

        /// <summary>
        /// Multiply by scalar componentwise.
        /// </summary>
        /// <param name="number">Scalar to multiply by.</param>
        /// <returns>Product of current vector and given scalar - new vector.</returns>
        IMathVector MultiplyNumber(double number);

        /// <summary>
        /// Sum with another vector.
        /// </summary>
        /// <param name="vector">Vector to sum with.</param>
        /// <returns>Sum of current vector and given vector - new vector.</returns>
        IMathVector Sum(IMathVector vector);

        /// <summary>
        /// Multiply with another vector componentwise.
        /// </summary>
        /// <param name="vector">Vector to multiply by.</param>
        /// <returns>Product of current vector and given vector - new vector.</returns>
        IMathVector Multiply(IMathVector vector);

        /// <summary>
        /// Calculate dot product with another vector.
        /// </summary>
        /// <param name="vector">Vector to calculate product with.</param>
        /// <returns>Dot product between current vector and given vector - a number.</returns>
        double ScalarMultiply(IMathVector vector);

        /// <summary>
        /// Calculate euclidean distance with another vector.
        /// </summary>
        /// <param name="vector">Vector to calculate distance with.</param>
        /// <returns>Euclidean distance between current vector and given vector - a number.</returns>
        double CalcDistance(IMathVector vector);
    }
}
