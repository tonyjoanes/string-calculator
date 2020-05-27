// <copyright file="Calc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StringCalculator
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Calculator object.
    /// </summary>
    public static class Calc
    {
        private const int DefaultNumber = 0;
        private const string DelimiterSwitchIdentifier = "//";

        /// <summary>
        /// Sum the numbers contained in a string.
        /// </summary>
        /// <param name="numbers">The string of numbers to sum.</param>
        /// <returns>The sum of the numbers.</returns>
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return DefaultNumber;
            }

            var delimiter = GetDelimiter(numbers);

            var convertedNumbers = numbers
                .Split(delimiter)
                .Select(x => ConvertStringToInt(x));

            NegativeCheck(convertedNumbers);

            return convertedNumbers.Sum();
        }

        private static void NegativeCheck(IEnumerable<int> convertedNumbers)
        {
            var negatives = convertedNumbers.Where(x => x < 0);

            if (negatives.Any())
            {
                throw new NegativeNumberException(GetErrorString(negatives));
            }
        }

        private static string GetErrorString(IEnumerable<int> negatives)
        {
            var errorMessage = string.Join(",", negatives);

            return errorMessage;
        }

        private static string GetDelimiter(string numbers)
        {
            return numbers.StartsWith(DelimiterSwitchIdentifier, System.StringComparison.OrdinalIgnoreCase)
                ? numbers.Substring(2, 1)
                : ",";
        }

        private static int ConvertStringToInt(string testString)
        {
            if (!int.TryParse(testString, out int testResult))
            {
                return DefaultNumber;
            }

            return testResult;
        }
    }
}
