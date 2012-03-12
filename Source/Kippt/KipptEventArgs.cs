using System;

namespace Kippt
{
    /// <summary>
    /// Contains the event data and state of a request.
    /// </summary>
    public class KipptEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Returned object from the response.
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Gets or sets the exception indicating if any errors were presented during the processing of a request.
        /// </summary>
        public Exception Error { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptEventArgs"/> class.
        /// </summary>
        public KipptEventArgs() { }

        #endregion Constructors
    }
}