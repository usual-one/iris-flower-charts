using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;
using System.Collections.Generic;
using System;

namespace MathLibUnitTest
{
    [TestClass]
    public class MathVectorTest
    {

        [TestMethod]
        public void TestDimensionsEmpty()
        {
            var vector = new MathVector(new List<double>());
            int assumed = 0;

            int result = vector.Dimensions;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestDimensionsSingle()
        {
            var vector = new MathVector(new List<double>()
            {
                1
            });
            int assumed = 1;

            int result = vector.Dimensions;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestDimensionsMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                1,
                1
            });
            int assumed = 3;

            int result = vector.Dimensions;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestLengthEmpty()
        {
            var vector = new MathVector(new List<double>());
            double assumed = 0;

            double result = vector.Length;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestLengthSingle()
        {
            var vector = new MathVector(new List<double>()
            {
                7
            });
            double assumed = 7;

            double result = vector.Length;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestLengthMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                4,
                -4,
                2
            });
            double assumed = 6;

            double result = vector.Length;

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestEqualsEmpty()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());

            bool vector1Result = vector1.Equals(vector2);
            bool vector2Result = vector2.Equals(vector1);

            Assert.IsTrue(vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestEqualsDifferentDimensions()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });

            bool vector1Result = vector1.Equals(vector2);
            bool vector2Result = vector2.Equals(vector1);

            Assert.IsFalse(vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestEqualsTrue()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });

            bool vector1Result = vector1.Equals(vector2);
            bool vector2Result = vector2.Equals(vector1);

            Assert.IsTrue(vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestEqualsFalse()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });

            bool vector1Result = vector1.Equals(vector2);
            bool vector2Result = vector2.Equals(vector1);

            Assert.IsFalse(vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestInvertEmpty()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector.Invert();

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestInvertMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4
            });
            var assumedVector = new MathVector(new List<double>()
            {
                1,
                0.5,
                0.25
            });

            var resultVector = (MathVector) vector.Invert();

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestInvertException()
        {
            var vector = new MathVector(new List<double>()
            {
                0,
                1
            });

            Assert.ThrowsException<DivideByZeroException>(() => vector.Invert());
        }

        [TestMethod]
        public void TestNegateEmpty()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector.Negate();

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestNegateMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var assumedVector = new MathVector(new List<double>()
            {
                -1,
                -2,
                -4,
                0
            });

            var resultVector = (MathVector) vector.Negate();

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestSumNumberEmpty()
        { 
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector.SumNumber(1);

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestSumNumberMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var assumedVector = new MathVector(new List<double>()
            {
                3,
                4,
                6,
                2
            });

            var resultVector = (MathVector) vector.SumNumber(2);

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestMultiplyNumberEmpty()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector.MultiplyNumber(2);

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestMultiplyNumberMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var assumedVector = new MathVector(new List<double>()
            {
                2,
                4,
                8,
                0
            });

            var resultVector = (MathVector) vector.MultiplyNumber(2);

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestDivideNumberEmpty()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector / 2;
            
            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestDivideNumberMultiple()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var assumedVector = new MathVector(new List<double>()
            {
                0.5,
                1,
                2,
                0
            });

            var resultVector = (MathVector) vector / 2;

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestDivideNumberException()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            Assert.ThrowsException<DivideByZeroException>(() => vector / 0);
        }

        [TestMethod]
        public void TestSumEmpty()
        {   
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector1 = (MathVector) vector1.Sum(vector2);
            var resultVector2 = (MathVector) vector2.Sum(vector1);

            Assert.IsTrue(assumedVector.Equals(resultVector1));
            Assert.IsTrue(resultVector1.Equals(resultVector2));
        }

        [TestMethod]
        public void TestSumMultiple()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                3,
                5,
                3,
                1
            });
            var assumedVector = new MathVector(new List<double>()
            {
                4,
                7,
                7,
                1
            });

            var resultVector1 = (MathVector) vector1.Sum(vector2);
            var resultVector2 = (MathVector) vector2.Sum(vector1);

            Assert.IsTrue(assumedVector.Equals(resultVector1));
            Assert.IsTrue(resultVector1.Equals(resultVector2));
        }

        [TestMethod]
        public void TestSumException()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.Sum(vector2));
            Assert.ThrowsException<ArithmeticException>(() => vector2.Sum(vector1));
        }

        [TestMethod]
        public void TestSubtractionEmpty()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) (vector1 - vector2);

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestSubtractionMultiple()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                3,
                5,
                3,
                1
            });
            var assumedVector = new MathVector(new List<double>()
            {
                -2,
                -3,
                1,
                -1
            });

            var resultVector1 = (MathVector) (vector1 - vector2);
            var resultVector2 = (MathVector) (vector2 - vector1);

            Assert.IsTrue(assumedVector.Equals(resultVector1));
            Assert.IsFalse(resultVector1.Equals(resultVector2));
        }

        [TestMethod]
        public void TestSubtractionException()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1 - vector2);
        }

        [TestMethod]
        public void TestMultiplyEmpty()
        {   
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector1 = (MathVector) vector1.Multiply(vector2);
            var resultVector2 = (MathVector) vector2.Multiply(vector1);

            Assert.IsTrue(assumedVector.Equals(resultVector1));
            Assert.IsTrue(resultVector1.Equals(resultVector2));
        }

        [TestMethod]
        public void TestMultiplyMultiple()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                4,
                5,
                2,
                1
            });
            var assumedVector = new MathVector(new List<double>()
            {
                4,
                10,
                8,
                0
            });

            var resultVector1 = (MathVector) vector1.Multiply(vector2);
            var resultVector2 = (MathVector) vector2.Multiply(vector1);

            Assert.IsTrue(assumedVector.Equals(resultVector1));
            Assert.IsTrue(resultVector1.Equals(resultVector2));
        }

        [TestMethod]
        public void TestMultiplyArithmeticException()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.Multiply(vector2));
            Assert.ThrowsException<ArithmeticException>(() => vector2.Multiply(vector1));
        }

        [TestMethod]
        public void TestDivisionEmpty()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());

            var resultVector = (MathVector) vector1 / vector2;

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestDivisionMultiple()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                4,
                5,
                2,
                1
            });
            var assumedVector = new MathVector(new List<double>()
            {
                0.25,
                0.4,
                2,
                0
            });

            var resultVector = (MathVector) vector1 / vector2;

            Assert.IsTrue(assumedVector.Equals(resultVector));
        }

        [TestMethod]
        public void TestDivisionDivisionException()
        {
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                0,
                1,
                3,
                0
            });
            Assert.ThrowsException<DivideByZeroException>(() => vector1 / vector2);
        }

        [TestMethod]
        public void TestDivisionArithmeticException()
        { 
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1 / vector2);
        }

        [TestMethod]
        public void TestScalarMultiplyEmpty()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            double assumed = 0;

            double vector1Result = vector1.ScalarMultiply(vector2);
            double vector2Result = vector2.ScalarMultiply(vector1);

            Assert.AreEqual(assumed, vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestScalarMultiplyMultiple()
        { 
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            var vector2 = new MathVector(new List<double>()
            {
                3,
                4,
                5
            });
            double assumed = 26;

            double vector1Result = vector1.ScalarMultiply(vector2);
            double vector2Result = vector2.ScalarMultiply(vector1);

            Assert.AreEqual(assumed, vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestScalarMultiplyException()
        { 
            var vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            var vector2 = new MathVector(new List<double>()
            {
                1,
                2
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.ScalarMultiply(vector2));
        }

        [TestMethod]
        public void TestCalcDistanceEmpty()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            double assumed = 0;

            double vector1Result = vector1.CalcDistance(vector2);
            double vector2Result = vector2.CalcDistance(vector1);

            Assert.AreEqual(assumed, vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestCalcDistanceSingle()
        {
            var vector1 = new MathVector(new List<double>()
            {
                2
            });
            var vector2 = new MathVector(new List<double>()
            {
                3
            });
            double assumed = 1;

            double vector1Result = vector1.CalcDistance(vector2);
            double vector2Result = vector2.CalcDistance(vector1);

            Assert.AreEqual(assumed, vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        [TestMethod]
        public void TestCalcDistanceMultiple()
        {
            var vector1 = new MathVector(new List<double>()
            {
                10,
                8,
                9
            });
            var vector2 = new MathVector(new List<double>()
            {
                6,
                4,
                7
            });
            double assumed = 6;

            double vector1Result = vector1.CalcDistance(vector2);
            double vector2Result = vector2.CalcDistance(vector1);

            Assert.AreEqual(assumed, vector1Result);
            Assert.AreEqual(vector1Result, vector2Result);
        }

        public void TestCalcDistanceEqual()
        {
            var vector1 = new MathVector(new List<double>()
            {
                2
            });
            double assumed = 0;

            double result = vector1.CalcDistance(vector1);

            Assert.AreEqual(assumed, result);
        }

        [TestMethod]
        public void TestCalcDistanceException()
        {
            var vector1 = new MathVector(new List<double>()
            {
                2
            });
            var vector2 = new MathVector(new List<double>());

            Assert.ThrowsException<ArithmeticException>(() => vector1.CalcDistance(vector2));
        }
    }
}
