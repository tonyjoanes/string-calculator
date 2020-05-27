using System;
using System.Runtime.InteropServices;
using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void WhenEmptyString_ShouldReturnZero()
        {
            var actual = Calc.Add(string.Empty);
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("4,8,1,2,3,7", 25)]
        [InlineData("1", 1)]
        public void WhenCsvNumbers_ShouldReturnSum(string testNumbers, int expected)
        {
            var actual = Calc.Add(testNumbers);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1\n,2", 3)]
        [InlineData("4,8\n,1,2\n,3,7", 25)]
        [InlineData("1\n", 1)]
        [InlineData("1,\n", 1)]
        public void WhenNewLineCharacter_ShouldHandleAndSum(string testNumbers, int expected)
        {
            var actual = Calc.Add(testNumbers);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//-\n5-5", 10)]
        [InlineData("//^\n5^6", 11)]
        [InlineData("//^\n13^7", 20)]
        public void WhenNewDelimiterUsed_ShouldReturnSum(string testNumbers, int expected)
        {
            var actual = Calc.Add(testNumbers);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-1,2")]
        [InlineData("1,2,-10")]
        public void WhenNegativeNumbersIncluded_ShouldThrowError(string numbers)
        {
            Assert.Throws<NegativeNumberException>(() => Calc.Add(numbers));
        }

        [Theory]
        [InlineData("-1,-2", "-1,-2")]
        public void WhenMultipleNegativeNumbers_ShouldReturnErrorWithDetailsOfNumbers(string numbers, string expected)
        {
            var exception = Assert.Throws<NegativeNumberException>(() => Calc.Add(numbers));

            Assert.Equal($"Negative numbers {expected} not permitted", exception.Message);
        }
    }
}
