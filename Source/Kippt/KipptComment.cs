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
        public KipptAccount User { get; set; }

        /// <summary>
        /// Gets or sets resource uri.
        /// </summary>
        [DataMember(Name = "resource_uri")]
        public string ResourceUri { get; set; }
    }
}