using System;
using System.Collections.Generic;
using Realms;

namespace BloodPressureTracker.Models
{
    public class User : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        [Required]
        public string Id { get; set; }

        [MapTo("_partition")]
        [Required]
        public string Partition { get; set; }

        [MapTo("readings")]
        public IList<BloodPressureReading> Readings {get;} 

        [MapTo("name")]
        [Required]
        public string Name { get; set; }
    }
}
