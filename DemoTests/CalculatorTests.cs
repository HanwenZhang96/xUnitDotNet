using DemoTests.Data;
using System;
using Xunit;
using xUnitDotNetTest;

namespace DemoTests
{
    [Collection("Long Time Task Collection")]
    public class CalculatorTests
    {
        [Theory]
        [CalculatorData]
        public void ShouldAdd(int x,int y,int expected)
        {
            // Arrange
            var sut = new Calculator(); // sut - System Under Test

            // Act
            var result = sut.Add(x, y);

            // Assert  
            Assert.Equal(expected, result);
        }


        // Fact ���attribute ��ʹ test runner ʶ���������һ�����Է���
        [Fact]
        public void ShouldStayTheSameWhenAddZero()
        {
            // Arrange
            var sut = new Calculator();

            // Act
            var result = sut.Add(2, 0);

            // Assert
            Assert.Equal(2, result);
        }
    }
}