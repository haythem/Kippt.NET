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
        /// Gets or sets whether the clip is favorited or not.
        /// </summary>
        [DataMember(Name = "is_starred")]
        public bool IsStarred { get; set; }

        /// <summary>
        /// Gets or sets whether the clip is favorited or not.
        /// </summary>
        [DataMember(Name = "is_favorite")]
        public bool IsFavorite { get; set; }

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
        public KipptUser User { get; set; }

        /// <summary>
        /// Gets clip list relative uri.
        /// </summary>
        [DataMember(Name = "list")]
        public KipptList List { get; set; }

        /// <summary>
        /// Gets clip article.
        /// </summary>
        [DataMember(Name = "article")]
        public KipptArticle Article { get; set; }

        /// <summary>
        /// Gets media associated with the clip.
        /// </summary>
        [DataMember(Name = "media")]
        public KipptMedia Media { get; set; }

        /// <summary>
        /// Gets clip original owner.
        /// </summary>
        [DataMember(Name = "via")]
        public string Via { get; set; }

        /// <summary>
        /// Gets clip type.
        /// </summary>
        /// 
        /// <remarks>
        ///     * Link
        ///     * Note
        ///     * Image
        ///     * File
        /// </remarks>
        [DataMember(Name = "type")]
        public string Type { get; set; }

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

    /// <summary>
    /// Represents a collection of <see cref="KipptClip"/> entity.
    /// </summary>
    [DataContract]
    public class KipptClipCollection
    {
        /// <summary>
        /// Gets pagination informations.
        /// </summary>
        [DataMember(Name = "meta")]
        public KipptMeta Meta { get; set; }

        /// <summary>
        /// Gets the list of <see cref="KipptClip"/> objects.
        /// </summary>
        [DataMember(Name = "objects")]
        public List<KipptClip> Clips { get; set; }
    }

    #region Comments, Likes and Saves

    /// <summary>
    /// Represents a comment entity.
    /// </summary>
    [DataContract]
    public class KipptComment
    {
        /// <summary>
        /// Gets or sets comment id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets comment body.
        /// </summary>
        [DataMember(Name = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets comment creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public long Created { get; set; }

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets comment user.
        /// </summary>
        [DataMember(Name = "user")]
        public KipptUser User { get; set; }

        /// <summary>
        /// Gets or sets resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }
    }

    /// <summary>
    /// Represents a collection of <see cref="KipptComment"/> entity.
    /// </summary>
    [DataContract]
    public class KipptCommentCollection
    {
        /// <summary>
        /// Gets comments count.
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets comments.
        /// </summary>
        [DataMember(Name = "data")]
        public List<KipptComment> Comments { get; set; }
    }

    /// <summary>
    /// Represents likes of a clip.
    /// </summary>
    [DataContract]
    public class KipptLikeCollection
    {
        /// <summary>
        /// Gets likes count.
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets the users who liked a clip.
        /// </summary>
        [DataMember(Name = "data", IsRequired = false)]
        public List<KipptUser> Likes { get; set; }
    }

    /// <summary>
    /// Represents saves of a clip.
    /// </summary>
    [DataContract]
    public class KipptSaveCollection
    {
        /// <summary>
        /// Gets saves count.
        /// </summary>
        [DataMember(Name = "count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets the users who saved a clip.
        /// </summary>
        [DataMember(Name = "data")]
        public List<KipptUser> Saves { get; set; }
    }

    /// <summary>
    /// Represents kippt article.
    /// </summary>
    [DataContract]
    public class KipptArticle
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "updated")]
        public long Updated { get; set; }

        public DateTime DateUpdated
        {
            get { return Utils.ToUniversalTime(Updated); }
        }

        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }

        [DataMember(Name = "html")]
        public string Html { get; set; }
    }

    #endregion

    #region Media

    [DataContract]
    public class KipptMedia
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "provider")]
        public KipptMediaProvider Provider { get; set; }

        [DataMember(Name = "images", IsRequired = false)]
        public KipptImageCollection Images { get; set; }

        [DataMember(Name = "embed", IsRequired = false)]
        public KipptEmbed Embed { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class KipptImage
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "width")]
        public int Width { get; set; }

        [DataMember(Name = "height")]
        public int Height { get; set; }
    }

    [DataContract]
    public class KipptImageCollection
    {
        [DataMember(Name = "original")]
        public KipptImage Original { get; set; }

        [DataMember(Name = "tile")]
        public KipptImage Tile { get; set; }
    }

    [DataContract]
    public class KipptMediaProvider
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class KipptEmbed
    {
        [DataMember(Name = "html")]
        public string Html { get; set; }

        [DataMember(Name = "width")]
        public int? Width { get; set; }

        [DataMember(Name = "height")]
        public int? Height { get; set; }
    }

    #endregion
}