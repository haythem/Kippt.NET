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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Kippt
{
    /// <summary>
    /// Represents a collection of <see cref="KipptList"/> objects.
    /// </summary>
    [DataContract]
    public class KipptListCollection
    {
        /// <summary>
        /// Gets the pagination informations.
        /// </summary>
        [DataMember(Name = "meta")]
        public KipptMeta Meta { get; set; }

        /// <summary>
        /// Gets the list of <see cref="KipptList"/> objects.
        /// </summary>
        [DataMember(Name = "objects")]
        public List<KipptList> Lists { get; set; }
    }
}