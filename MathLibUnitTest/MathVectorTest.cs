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
        public void TestIndexing()
        {
            var vector = new MathVector(new List<double>()
            {
                1,
                2,
                3,
                4
            });
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(4, vector[3]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => vector[-1]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => vector[4]);
        }

        [TestMethod]
        public void TestDimensions()
        {
            var vector = new MathVector(new List<double>());
            Assert.AreEqual(0, vector.Dimensions);

            vector = new MathVector(new List<double>()
            {
                1
            });
            Assert.AreEqual(1, vector.Dimensions);

            vector = new MathVector(new List<double>()
            {
                1,
                1,
                1
            });
            Assert.AreEqual(3, vector.Dimensions);

        }

        [TestMethod]
        public void TestLength()
        {
            var vector = new MathVector(new List<double>());
            Assert.AreEqual(0, vector.Length);
            
            vector = new MathVector(new List<double>()
            {
                7
            });
            Assert.AreEqual(7, vector.Length);

            vector = new MathVector(new List<double>()
            {
                3,
                4
            });
            Assert.AreEqual(5, vector.Length);

            vector = new MathVector(new List<double>()
            {
                4,
                -4,
                2
            });
            Assert.AreEqual(6, vector.Length);
        }

        [TestMethod]
        public void TestEquals()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            Assert.IsTrue(vector1.Equals(vector2));
            Assert.IsTrue(vector1 == vector2);
            Assert.IsFalse(vector1 != vector2);
            Assert.AreEqual(vector1.Equals(vector2), vector2.Equals(vector1));

            vector2 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            Assert.IsFalse(vector1.Equals(vector2));
            Assert.IsFalse(vector1 == vector2);
            Assert.IsTrue(vector1 != vector2);
            Assert.AreEqual(vector1.Equals(vector2), vector2.Equals(vector1));

            vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4
            });
            Assert.IsFalse(vector1.Equals(vector2));
            Assert.IsFalse(vector1 == vector2);
            Assert.IsTrue(vector1 != vector2);
            Assert.AreEqual(vector1.Equals(vector2), vector2.Equals(vector1));

            vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            Assert.IsTrue(vector1.Equals(vector2));
            Assert.IsTrue(vector1 == vector2);
            Assert.IsFalse(vector1 != vector2);
            Assert.AreEqual(vector1.Equals(vector2), vector2.Equals(vector1));
        }

        [TestMethod]
        public void TestInvert()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector.Invert()));

            vector = new MathVector(new List<double>()
            {
                1,
                2,
                4
            });
            assumedVector = new MathVector(new List<double>()
            {
                1,
                0.5,
                0.25
            });
            Assert.IsTrue(assumedVector.Equals(vector.Invert()));

            vector = new MathVector(new List<double>()
            {
                0,
                1
            });
            Assert.ThrowsException<DivideByZeroException>(() => vector.Invert());
        }

        [TestMethod]
        public void TestNegate()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector.Negate()));
            Assert.IsTrue(assumedVector.Equals(-vector));

            vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            assumedVector = new MathVector(new List<double>()
            {
                -1,
                -2,
                -4,
                0
            });
            Assert.IsTrue(assumedVector.Equals(vector.Negate()));
            Assert.IsTrue(assumedVector.Equals(-vector));

            assumedVector = new MathVector(new List<double>()
            {
                1,
                -2,
                4,
                0
            });
            Assert.IsFalse(assumedVector.Equals(vector.Negate()));
            Assert.IsFalse(assumedVector.Equals(-vector));
        }

        [TestMethod]
        public void TestSumNumber()
        { 
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector.SumNumber(1)));
            Assert.IsTrue(assumedVector.Equals(vector + 1));

            vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            assumedVector = new MathVector(new List<double>()
            {
                3,
                4,
                6,
                2
            });
            Assert.IsTrue(assumedVector.Equals(vector.SumNumber(2)));
            Assert.IsTrue(assumedVector.Equals(vector + 2));
            
            assumedVector = new MathVector(new List<double>()
            {
                -1,
                0,
                2,
                -2
            });
            Assert.IsTrue(assumedVector.Equals(vector.SumNumber(-2)));
            Assert.IsTrue(assumedVector.Equals(vector - 2));

            assumedVector = new MathVector(new List<double>()
            {
                1,
                -2,
                4,
                0
            });
            Assert.IsFalse(assumedVector.Equals(vector.SumNumber(2)));
            Assert.IsFalse(assumedVector.Equals(vector + 2));
        }

        [TestMethod]
        public void TestMultiplyNumber()
        {
            var vector = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector.MultiplyNumber(2)));
            Assert.IsTrue(assumedVector.Equals(vector * 2));

            vector = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            assumedVector = new MathVector(new List<double>()
            {
                2,
                4,
                8,
                0
            });
            Assert.IsTrue(assumedVector.Equals(vector.MultiplyNumber(2)));
            Assert.IsTrue(assumedVector.Equals(vector * 2));
            

            assumedVector = new MathVector(new List<double>()
            {
                1,
                -2,
                4,
                0
            });
            Assert.IsFalse(assumedVector.Equals(vector.MultiplyNumber(2)));
            Assert.IsFalse(assumedVector.Equals(vector * 2));

            assumedVector = new MathVector(new List<double>()
            {
                0.5,
                1,
                2,
                0
            });
            Assert.IsTrue(assumedVector.Equals(vector / 2));

            assumedVector = new MathVector(new List<double>()
            {
                0.5,
                3,
                8,
                9
            });
            Assert.IsFalse(assumedVector.Equals(vector / 2));

            Assert.ThrowsException<DivideByZeroException>(() => vector / 0);
        }

        [TestMethod]
        public void TestSum()
        {   
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector1.Sum(vector2)));
            Assert.IsTrue(assumedVector.Equals(vector1 + vector2));
            Assert.IsTrue((vector1 + vector2).Equals(vector2 + vector1));

            vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            vector2 = new MathVector(new List<double>()
            {
                3,
                5,
                3,
                1
            });
            assumedVector = new MathVector(new List<double>()
            {
                4,
                7,
                7,
                1
            });
            Assert.IsTrue(assumedVector.Equals(vector1.Sum(vector2)));
            Assert.IsTrue(assumedVector.Equals(vector1 + vector2));
            Assert.IsTrue((vector1 + vector2).Equals(vector2 + vector1));

            assumedVector = new MathVector(new List<double>()
            {
                8,
                3,
                2,
                0
            });
            Assert.IsFalse(assumedVector.Equals(vector1.Sum(vector2)));
            Assert.IsFalse(assumedVector.Equals(vector1 + vector2));

            assumedVector = new MathVector(new List<double>()
            {
                -2,
                -3,
                1,
                -1
            });
            Assert.IsTrue(assumedVector.Equals(vector1 - vector2));
            Assert.IsFalse((vector1 - vector2).Equals(vector2 - vector1));

            assumedVector = new MathVector(new List<double>()
            {
                -8,
                -7,
                2,
                -1
            });
            Assert.IsFalse(assumedVector.Equals(vector1 - vector2));

            vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.Sum(vector2));
            Assert.ThrowsException<ArithmeticException>(() => vector2.Sum(vector1));
            Assert.ThrowsException<ArithmeticException>(() => vector1 + vector2);
            Assert.ThrowsException<ArithmeticException>(() => vector1 - vector2);
        }

        [TestMethod]
        public void TestMultiply()
        {   
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            var assumedVector = new MathVector(new List<double>());
            Assert.IsTrue(assumedVector.Equals(vector1.Multiply(vector2)));
            Assert.IsTrue(assumedVector.Equals(vector1 * vector2));
            Assert.IsTrue((vector1 * vector2).Equals(vector2 * vector1));

            vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                4,
                0
            });
            vector2 = new MathVector(new List<double>()
            {
                4,
                5,
                2,
                1
            });
            assumedVector = new MathVector(new List<double>()
            {
                4,
                10,
                8,
                0
            });
            Assert.IsTrue(assumedVector.Equals(vector1.Multiply(vector2)));
            Assert.IsTrue(assumedVector.Equals(vector1 * vector2));
            Assert.IsTrue((vector1 * vector2).Equals(vector2 * vector1));

            assumedVector = new MathVector(new List<double>()
            {
                8,
                3,
                2,
                0
            });
            Assert.IsFalse(assumedVector.Equals(vector1.Multiply(vector2)));
            Assert.IsFalse(assumedVector.Equals(vector1 * vector2));

            assumedVector = new MathVector(new List<double>()
            {
                0.25,
                0.4,
                2,
                0
            });
            Assert.IsTrue(assumedVector.Equals(vector1 / vector2));

            assumedVector = new MathVector(new List<double>()
            {
                -8,
                -7,
                2,
                -1
            });
            Assert.IsFalse(assumedVector.Equals(vector1 / vector2));

            vector2 = new MathVector(new List<double>()
            {
                0,
                1,
                3,
                0
            });
            Assert.ThrowsException<DivideByZeroException>(() => vector1 / vector2);

            vector2 = new MathVector(new List<double>()
            {
                1,
                1
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.Multiply(vector2));
            Assert.ThrowsException<ArithmeticException>(() => vector2.Multiply(vector1));
            Assert.ThrowsException<ArithmeticException>(() => vector1 * vector2);
            Assert.ThrowsException<ArithmeticException>(() => vector1 / vector2);
        }

        [TestMethod]
        public void TestScalarMultiply()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            Assert.AreEqual(0, vector1.ScalarMultiply(vector2));
            Assert.AreEqual(0, vector1 % vector2);
            Assert.AreEqual(vector2.ScalarMultiply(vector1), vector1.ScalarMultiply(vector2));
            Assert.AreEqual(vector1 % vector2, vector2 % vector2);

            vector1 = new MathVector(new List<double>()
            {
                1,
                2,
                3
            });
            vector2 = new MathVector(new List<double>()
            {
                3,
                4,
                5
            });
            Assert.AreEqual(26, vector1.ScalarMultiply(vector2));
            Assert.AreEqual(26, vector1 % vector2);
            Assert.AreEqual(vector2.ScalarMultiply(vector1), vector1.ScalarMultiply(vector2));
            Assert.AreEqual(vector1 % vector2, vector2 % vector1);

            vector2 = new MathVector(new List<double>()
            {
                4,
                2,
                1
            });
            Assert.AreNotEqual(26, vector1.ScalarMultiply(vector2));
            Assert.AreNotEqual(26, vector1 % vector2);

            vector2 = new MathVector(new List<double>()
            {
                1,
                2
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.ScalarMultiply(vector2));
            Assert.ThrowsException<ArithmeticException>(() => vector1 % vector2);
        }

        [TestMethod]
        public void TestCalcDistance()
        {
            var vector1 = new MathVector(new List<double>());
            var vector2 = new MathVector(new List<double>());
            Assert.AreEqual(0, vector1.CalcDistance(vector2));

            vector1 = new MathVector(new List<double>()
            {
                2
            });
            Assert.ThrowsException<ArithmeticException>(() => vector1.CalcDistance(vector2));

            vector2 = new MathVector(new List<double>()
            {
                3
            });
            Assert.AreEqual(1, vector2.CalcDistance(vector1));
            Assert.AreEqual(vector2.CalcDistance(vector1), vector1.CalcDistance(vector2));
            Assert.AreEqual(0, vector1.CalcDistance(vector1));

            vector1 = new MathVector(new List<double>()
            {
                10,
                8,
                9
            });
            vector2 = new MathVector(new List<double>()
            {
                6,
                4,
                7
            });
            Assert.AreEqual(6, vector2.CalcDistance(vector1));
            Assert.AreEqual(vector2.CalcDistance(vector1), vector1.CalcDistance(vector2));
        }

    }
}
