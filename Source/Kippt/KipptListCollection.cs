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