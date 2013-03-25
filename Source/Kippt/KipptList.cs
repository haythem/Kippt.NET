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
    /// Lists are used to organize and categorize clips.
    /// Clips will have a list associated to them.
    /// Every user has one list predefined, inbox, which can't be deleted.
    /// </summary>
    /// 
    /// <remarks>
    /// Accepted Scopes :
    ///     * User
    /// </remarks>
    [DataContract]
    public partial class KipptList
    {
        /// <summary>
        /// Gets or sets list id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets list title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets list description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether a list is private or not.
        /// </summary>
        [DataMember(Name = "is_private")]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Gets or sets list owner.
        /// </summary>
        [DataMember(Name = "user")]
        public KipptUser User { get; set; }

        /// <summary>
        /// Gets or sets list collaborators.
        /// </summary>
        [DataMember(Name = "collaborators")]
        public KipptCollaborators Collaborators { get; set; }

        /// <summary>
        /// Gets list creation date (Unix Time).
        /// </summary>
        [DataMember(Name = "created")]
        public long Created { get; set; }

        /// <summary>
        /// Gets list creation date (Universal Time).
        /// </summary>
        public DateTime DateCreated
        {
            get { return Utils.ToUniversalTime(Created); }
        }

        /// <summary>
        /// Gets clip update date (Unix Time).
        /// </summary>
        [DataMember(Name = "updated")]
        public long Updated { get; set; }

        /// <summary>
        /// Gets clip update date (Universal Time).
        /// </summary>
        public DateTime DateUpdated
        {
            get { return Utils.ToUniversalTime(Updated); }
        }

        /// <summary>
        /// Gets or sets list slug.
        /// </summary>
        [DataMember(Name = "slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets list relative url.
        /// </summary>
        [DataMember(Name = "app_url")]
        public string RelativeUrl { get; set; }

        /// <summary>
        /// Gets or sets list resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets list rss url.
        /// </summary>
        [DataMember(Name = "rss_url")]
        public string RssUrl { get; set; }
    }

    /// <summary>
    /// Represents a collection of <see cref="KipptList"/> entity.
    /// </summary>
    [DataContract]
    public class KipptListCollection
    {
        /// <summary>
        /// Gets pagination informations.
        /// </summary>
        [DataMember(Name = "meta")]
        public KipptMeta Meta { get; set; }

        /// <summary>
        /// Gets the list of <see cref="KipptList"/> objects.
        /// </summary>
        [DataMember(Name = "objects")]
        public List<KipptList> Lists { get; set; }
    }

    [DataContract]
    public class KipptCollaborators
    {
        /// <summary>
        /// Gets users count.
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets users.
        /// </summary>
        [DataMember(Name = "data")]
        public List<KipptUser> Users { get; set; }
    }
}