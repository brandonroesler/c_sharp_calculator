using Microsoft.VisualStudio.TestTools.UnitTesting;
using R365_Calculator;

namespace Calc_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddsTwoNumbers()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("1,20");

            //Assert
            int expected = 21;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddsMoreThanTwoNumbers()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("1,21,5");

            //Assert
            int expected = 27;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConvertsInvalidNumbersToZero()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("5,tytyt");

            //Assert
            int expected = 5;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DeliminatesCommaAndNewline()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("1\n2,3");

            //Assert
            int expected = 6;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NoNegatives()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() => calculator.Add("-1,20,-5"));
        }

        [TestMethod]
        public void IgnoreNumbersGreaterThan1000()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("2,1001,6");

            //Assert
            int expected = 8;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SingleCustomDelimiter()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("//;\n2;5");

            //Assert
            int expected = 7;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DelimitersOfAnyLength()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("//[***]\n11***22***33");

            //Assert
            int expected = 66;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultipleDelimiters()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.Add("//[*][!!][rrr]\n11rrr22*33!!44");

            //Assert
            int expected = 110;
            Assert.AreEqual(expected, result);
        }
    }
}
