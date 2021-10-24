using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Realms;

namespace BloodPressureTracker.Models
{
    public class BloodPressureReading : RealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [Required]
        [MapTo("_partition")]
        public string PartitionKey { get; set; }

        [MapTo("date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]        
        public DateTimeOffset Date { get; set; }

        [MapTo("timeOfDay")]
        public string TimeOfDay { get; set; }

        [MapTo("systolic")]
        public int Systolic { get; set; }

        [MapTo("diastolic")]
        public int Diastolic { get; set; }

        [MapTo("pulse")]
        public int Pulse { get; set; }

        public string BloodPressure => $"{Systolic}/{Diastolic}";
    }
}
