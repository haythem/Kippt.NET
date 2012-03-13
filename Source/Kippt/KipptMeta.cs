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
    /// Provides pagination information of executed query.
    /// </summary>
    [DataContract]
    public class KipptMeta
    {
        /// <summary>
        /// The number of returned items.
        /// </summary>
        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Next page link.
        /// </summary>
        [DataMember(Name = "next")]
        public string Next { get; set; }

        /// <summary>
        /// Start index.
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Previous page link.
        /// </summary>
        [DataMember(Name = "previous")]
        public string Previous { get; set; }

        /// <summary>
        /// Number of rows affected by the query.
        /// </summary>
        [DataMember(Name = "total_count")]
        public int TotalCount { get; set; }
    }
}