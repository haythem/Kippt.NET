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
    /// Class used to hold the user credentials.
    /// </summary>
    public class KipptSession
    {
        #region Properties

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets token.
        /// </summary>
        /// 
        /// <remarks>
        /// Token can be found here https://kippt.com/api/ (Authentication is required).
        /// </remarks>
        public string Token { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KipptSession"/> class.
        /// </summary>
        /// 
        /// <param name="userName">User name.</param>
        /// <param name="token">Token.</param>
        public KipptSession(string userName, string token)
        {
            this.UserName = userName;
            this.Token = token;
        }

        #endregion Constructors
    }
}