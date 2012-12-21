/*
    Kippt.NET Library for consuming Kippt APIs.
    Copyright (C) 2012-2013 Haythem Tlili
    
    Library : https://github.com/Haythem/Kippt.NET
    Documentation : http://haythem.github.com/Kippt.NET/

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
    public partial class KipptAccount
    {
        /// <summary>
        /// Gets or sets account id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets api token.
        /// </summary>
        [DataMember(Name = "api_token")]
        public string ApiToken { get; set; }

        /// <summary>
        /// Gets or sets avatar url (Gravatar).
        /// </summary>
        [DataMember(Name = "avatar_url")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets lists relative url.
        /// </summary>
        [DataMember(Name = "lists")]
        public string Lists { get; set; }

        /// <summary>
        /// Gets or sets relative url.
        /// </summary>
        [DataMember(Name = "app_url")]
        public string RelativeUrl { get; set; }

        /// <summary>
        /// Gets or sets resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }
    }
}