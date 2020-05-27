// <copyright file="NegativeNumberException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StringCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Negative number exception.
    /// </summary>
    public class NegativeNumberException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public NegativeNumberException(string message)
            : base($"Negative numbers {message} not permitted")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception messange.</param>
        public NegativeNumberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeNumberException"/> class.
        /// </summary>
        public NegativeNumberException()
        {
        }
    }
}
