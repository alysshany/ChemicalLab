﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChemicalLaboratory.Data
{
    public class AnalyzeData
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Deposit { get; set; }
        public string DefinedIndicatorData { get; set; }
        public string MethodData { get; set; }
        public DateTime? DateOfFinishing { get; set; }
        public UserData? WorkerData { get; set; }
        public string? ResultData { get; set; }
        public bool isFinished = false;
    }
}
