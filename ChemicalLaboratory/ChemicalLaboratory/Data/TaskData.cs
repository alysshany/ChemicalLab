using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChemicalLaboratory.Data
{
    public class TaskData
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string Task { get; set; }
        public UserData User { get; set; }
        public bool isDone = false;
    }
}
