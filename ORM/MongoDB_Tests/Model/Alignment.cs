using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB_Tests.Model
{
    [BsonIgnoreExtraElements]
    class Alignment
    {
        [BsonElement("id")]
        public int ID { get; set; }
        [BsonElement("alignment_name")]
        public string AlignmentName { get; set; }
    }
}
