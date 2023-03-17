using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChemicalLaboratory.Data
{
    public class UserData
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Telephone { get; set; }

        public string RoleName { get; set; }
    }
}
