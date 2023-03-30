using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ChemicalLaboratory.Data
{
    public class EquipmentData
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string Title { get; set; }
        public UserData User { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
