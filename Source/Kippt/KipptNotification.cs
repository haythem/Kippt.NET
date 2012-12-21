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
    /// Represents a kippt notification entity.
    /// </summary>
    [DataContract]
    public partial class KipptNotification
    {
        /// <summary>
        /// Gets notification id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets whether a notification has been seen or not.
        /// </summary>
        [DataMember(Name = "is_seen")]
        public bool IsSeen { get; set; }

        /// <summary>
        /// Gets notification clip.
        /// </summary>
        [DataMember(Name = "clip")]
        public KipptClip Clip { get; set; }

        /// <summary>
        /// Gets notification user.
        /// </summary>
        [DataMember(Name = "item")]
        public KipptAccount User { get; set; }

        /// <summary>
        /// Gets creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public long Created { get; set; }

        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets item relative url.
        /// </summary>
        [DataMember(Name = "item_url")]
        public string ItemUrl { get; set; }

        /// <summary>
        /// Gets notification type.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}