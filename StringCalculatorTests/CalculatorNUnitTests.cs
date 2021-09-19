using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    [TestFixture]
    class CalculatorNUnitTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new();
        }

        [Test]
        public void Add_InputEmptyString_ReturnZero()
        {
            int result = calculator.Calculate("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_InputSingleDigitOf5_Return5()
        {
            int result = calculator.Calculate("5");

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Add_InputFourAndTwo_ReturnSix()
        {
            int result = calculator.Calculate("4,2");

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_InputFourTwoAndOne_ReturnSeven()
        {
            int result = calculator.Calculate("4,2,1");

            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Add_InputNegativeNumber_GetException()
        {
            var result = Assert.Throws<InvalidOperationException>(() => calculator.Calculate("5,-2"));

            Assert.That(result.Message, Is.EqualTo("Negatives not allowed. You passed: -2"));
        }

        [Test]
        public void Add_InputAdditionOperand_ReturnNumbersAdded()
        {
            int result = calculator.Calculate("4,2,+");

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_InputSubtractionOperand_ReturnNumbersSubtracted()
        {
            int result = calculator.Calculate("4,2,-");

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Add_InputMultiplicationOperand_ReturnNumbersMultiplied()
        {
            int result = calculator.Calculate("4,2,*");

            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Add_InputDivisionOperand_ReturnNumbersDivided()
        {
            int result = calculator.Calculate("4,2,/");

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
