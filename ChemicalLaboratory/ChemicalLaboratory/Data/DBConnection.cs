using MongoDB.Driver;
using ChemicalLaboratory.Data;
using MongoDB.Bson;

namespace ChemicalLaboratory.Data
{
    public class DBConnection
    {
        public static void AddToDataBase(UserData user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            collection.InsertOne(user);
        }

        public static void DeleteUserFromDataBase(UserData userData)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            var user = collection.DeleteOne(x => x == userData);
        }

        public static void AddTaskToDataBase(TaskData task)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<TaskData>("CollectionOfTasks");
            collection.InsertOne(task);
        }

        public static void AddEquipmentToDataBase(EquipmentData equipment)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<EquipmentData>("CollectionOfEquipments");
            collection.InsertOne(equipment);
        }

        public static void DeleteEquipmnetFromDataBase(EquipmentData equipment)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<EquipmentData>("CollectionOfEquipments");
            var user = collection.DeleteOne(x => x == equipment);
        }

        public static void AddAnalyzeToDataBase(AnalyzeData analyze)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            collection.InsertOne(analyze);
        }

        public static AnalyzeData FindAnalyzeByTitle(string title)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            var analyze = collection.Find(x => x.Title == title).FirstOrDefault();
            return analyze;
        }

        public static UserData FindUserByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            var user = collection.Find(x => x.Login == login).FirstOrDefault();
            return user;
        }

        public static List<UserData> ImportAllWorkersWithoutAdmin()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName != "Администратор").ToList();
            return list;
        }

        public static List<UserData> ImportAllLabWorkers()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            var list = collection.Find(x => x.RoleName == "Лаборант").ToList();
            return list;
        }

        public static List<EquipmentData> ImportAllEquipments()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<EquipmentData>("CollectionOfEquipments");
            var list = collection.Find(new BsonDocument()).ToList();
            return list;
        }

        public static List<TaskData> ImportTasksOfWorker(UserData user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<TaskData>("CollectionOfTasks");
            var list = collection.Find(x => (x.User.Login == user.Login) && (x.isDone == false)).ToList();
            return list;
        }

        public static List<AnalyzeData> ImportOnlyApplications()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == false)).ToList();
            return list;
        }

        public static List<AnalyzeData> ImportOnlyAnalyzes()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == true)).ToList();
            return list;
        }

        public static List<AnalyzeData> ImportOnlyAnalyzesOfWorker(UserData user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            var list = collection.Find(x => (x.isFinished == true) && (x.WorkerData == user)).ToList();
            return list;
        }

        public static void ReplaceUser(UserData user)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var filter = new BsonDocument("_id", user.Id);
            var collection = database.GetCollection<UserData>("CollectionOfUsers");
            collection.ReplaceOne(filter, user);
        }

        public static void ReplaceTask(TaskData task)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var filter = new BsonDocument("_id", task.Id);
            var collection = database.GetCollection<TaskData>("CollectionOfTasks");
            collection.ReplaceOne(filter, task);
        }

        public static void ReplaceAnalyze(AnalyzeData analyze)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChemicalLab");
            var filter = new BsonDocument("_id", analyze.Id);
            var collection = database.GetCollection<AnalyzeData>("CollectionOfAnalyzes");
            collection.ReplaceOne(filter, analyze);
        }
    }
}
