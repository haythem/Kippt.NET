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
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Simple endpoint to check if user is authenticated correctly and get account data.
    /// </summary>
    [DataContract]
    public class KipptAccount
    {
        #region Properties

        /// <summary>
        /// Gets the user id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets the api token.
        /// </summary>
        [DataMember(Name = "api_token")]
        public string ApiToken { get; set; }

        /// <summary>
        /// Gets or sets the avatar url (Gravatar).
        /// </summary>
        [DataMember(Name = "avatar_url")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets the lists relative uri.
        /// </summary>
        [DataMember(Name = "lists")]
        public string Lists { get; set; }

        /// <summary>
        /// Gets the resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }

        #endregion Properties

        #region Shared Methods

        /// <summary>
        /// Returns the username and api token of the logged in user.
        /// </summary>
        public static KipptAccount Authenticate()
        {
            return KipptApi.ApiAction<KipptAccount>(ApiCommand.Account, HttpMethod.Get);
        }

        #endregion Shared Methods
    }
}