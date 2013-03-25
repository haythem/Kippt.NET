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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Simple endpoint to check if user is authenticated correctly and get account data.
    /// </summary>
    [DataContract]
    public partial class KipptUser
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
        [DataMember(Name = "api_token", IsRequired = false)]
        public string ApiToken { get; set; }

        /// <summary>
        /// Gets or sets full name.
        /// </summary>
        [DataMember(Name = "full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets biography.
        /// </summary>
        [DataMember(Name = "bio")]
        public string Bio { get; set; }

        [DataMember(Name = "website_url")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets avatar url (Gravatar).
        /// </summary>
        [DataMember(Name = "avatar_url")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets whether the user has a pro account or not.
        /// </summary>
        [DataMember(Name = "is_pro")]
        public bool IsPro { get; set; }

        /// <summary>
        /// Gets or sets twitter username.
        /// </summary>
        [DataMember(Name = "twitter")]
        public string Twitter { get; set; }

        /// <summary>
        /// Gets or sets github username.
        /// </summary>
        [DataMember(Name = "github")]
        public string Github { get; set; }

        /// <summary>
        /// Gets or sets dribbble username.
        /// </summary>
        [DataMember(Name = "dribbble")]
        public string Dribbble { get; set; }

        /// <summary>
        /// Gets followings and followers count.
        /// </summary>
        [DataMember(Name = "counts")]
        public Counts Counts { get; set; }

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

    [DataContract]
    public class KipptUserCollection
    {
        [DataMember(Name = "meta")]
        public KipptMeta Meta { get; set; }

        [DataMember(Name = "objects")]
        public List<KipptUser> Users { get; set; }
    }

    /// <summary>
    /// Represents followings and followers count.
    /// </summary>
    [DataContract]
    public class Counts
    {
        /// <summary>
        /// Gets or sets followings count.
        /// </summary>
        [DataMember(Name = "follows")]
        public int Followings { get; set; }

        /// <summary>
        /// Gets or sets followers count.
        /// </summary>
        [DataMember(Name = "followed_by")]
        public int Followers { get; set; }
    }

    [DataContract]
    public class KipptRelationship
    {
        [DataMember(Name = "following")]
        public bool Following { get; set; }
    }

    [DataContract]
    internal class KipptAction
    {
        [DataMember(Name = "action")]
        public string Action { get; set; }

        public KipptAction(string action)
        {
            this.Action = action;
        }
    }
}