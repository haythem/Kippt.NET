/*
    Kippt.NET Library for consuming Kippt APIs.
    Copyright (C) 2012 Haythem Tlili

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
 */

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