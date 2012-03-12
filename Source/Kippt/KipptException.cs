using System;

namespace Kippt
{
    /// <summary>
    /// Handles Kippt api exceptions.
    /// </summary>
    public class KipptException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KipptException"/> class.
        /// </summary>
        public KipptException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptException"/> class.
        /// </summary>
        /// 
        /// <param name="message">Exception message.</param>
        public KipptException(string message) : base(message) { }
    }
}
