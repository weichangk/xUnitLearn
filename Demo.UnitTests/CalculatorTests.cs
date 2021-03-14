using System;
using Xunit;

namespace Demo.UnitTests
{
    public class CalculatorTests
    {
        [Fact]//Fact���Ϊ���Է���
        public void ShouldAddEquals()
        {
            //Arrange
            var sut = new Calculator(); //sut-system under test
            //Act
            var result = sut.Add(1,2);
            //Assert
            Assert.Equal(3, result);
        }

        /// <summary>
        /// ���ò�����ʹ��[Theory]���������Լ�����ͬ����������
        /// ������Դ[InlineData]
        /// </summary>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 6)]
        public void ShouldAddEquals1(int operand1, int operand2, int expected)
        {
            //Arrange
            var sut = new Calculator(); //sut-system under test
            //Act
            var result = sut.Add(operand1, operand2);
            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// ���ݹ���-MemberData
        /// </summary>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(CalculatorTestData.TestData), MemberType = typeof(CalculatorTestData))]
        public void ShouldAddEquals2(int operand1, int operand2, int expected)
        {
            //Arrange
            var sut = new Calculator(); //sut-system under test
            //Act
            var result = sut.Add(operand1, operand2);
            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// ���ݹ���-MemberData-�ⲿ����
        /// </summary>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(CalculatorCsvData.TestData), MemberType = typeof(CalculatorCsvData))]
        public void ShouldAddEquals3(int operand1, int operand2, int expected)
        {
            //Arrange
            var sut = new Calculator(); //sut-system under test
            //Act
            var result = sut.Add(operand1, operand2);
            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// ���ݹ���-�Զ������Լ̳���DataAttribute
        /// </summary>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <param name="expected"></param>
        [Theory]
        [CalculatorDataAttribute]
        public void ShouldAddEquals4(int operand1, int operand2, int expected)
        {
            //Arrange
            var sut = new Calculator(); //sut-system under test
            //Act
            var result = sut.Add(operand1, operand2);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}
