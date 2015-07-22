using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace WebApi.Models
{
    public class Student
    {
		[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

		[BsonElement("firstname")]
		public string FirstName { get; set; }
		
		[BsonElement("lastname")]
		public string LastName { get; set; }

		[BsonElement("joinat")]
		public DateTime JoinAt { get; set; }
	}
}