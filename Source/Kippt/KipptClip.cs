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
    /// Clips are items stored to Kippt. If you create a new clip without defining the list, it will be saved to user's Inbox.
    /// Title will be fetched automatically if it's not provided.
    /// </summary>
    [DataContract]
    public partial class KipptClip
    {
        /// <summary>
        /// Gets or sets clip id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets clip title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets clip notes.
        /// </summary>
        [DataMember(Name = "notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets clip url.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets clip url domain.
        /// </summary>
        [DataMember(Name = "url_domain")]
        public string UrlDomain { get; set; }

        /// <summary>
        /// Gets clip favicon url.
        /// </summary>
        [DataMember(Name = "favicon_url")]
        public string FavIconUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the clip is marked for read later or not.
        /// </summary>
        [DataMember(Name = "is_read_later")]
        public bool IsReadLater { get; set; }

        /// <summary>
        /// Gets or sets whether the clip is starred or not.
        /// </summary>
        [DataMember(Name = "is_starred")]
        public bool IsStarred { get; set; }

        /// <summary>
        /// Gets clip likes.
        /// </summary>
        [DataMember(Name = "likes")]
        public KipptLikeCollection Likes { get; set; }

        /// <summary>
        /// Gets clip comments.
        /// </summary>
        [DataMember(Name = "comments")]
        public KipptCommentCollection Comments { get; set; }

        /// <summary>
        /// Gets clip saves.
        /// </summary>
        [DataMember(Name = "saves")]
        public KipptSaveCollection Saves { get; set; }

        /// <summary>
        /// Gets clip owner.
        /// </summary>
        [DataMember(Name = "user")]
        public KipptAccount User { get; set; }

        /// <summary>
        /// Gets clip list relative uri.
        /// </summary>
        [DataMember(Name = "list")]
        public KipptList List { get; set; }

        /// <summary>
        /// Gets clip article.
        /// </summary>
        [DataMember(Name = "article")]
        public string Article { get; set; }

        /// <summary>
        /// Gets clip original owner.
        /// </summary>
        [DataMember(Name = "via")]
        public KipptAccount Via { get; set; }

        /// <summary>
        /// Gets clip creation date (Unix Time).
        /// </summary>
        [DataMember(Name = "created")]
        public long Created { get; set; }

        /// <summary>
        /// Gets clip creation date (Universal Time).
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
        /// Gets clip relative url.
        /// </summary>
        [DataMember(Name = "app_url")]
        public string RelativeUrl { get; set; }

        /// <summary>
        /// Gets clip resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }
    }
}