using System;
using WebApi.Repositories.Contracts;
using System.Collections.Generic;
using WebApi.Models;
using Microsoft.Framework.OptionsModel;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
namespace WebApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Settings _settings;
        private readonly MongoDatabase _database;
        
        public StudentRepository(IOptions<Settings> settings)  
        {
            _settings = settings.Options;
            _database = Connect();
        }
        
        private MongoDatabase Connect()
        {
            var client = new MongoClient(_settings.MongoConnection);
            var server = client.GetServer();
            var database = server.GetDatabase(_settings.Database);            
            return database;
        }

        public IEnumerable<Student> AllStudents()
        {
            var students = _database.GetCollection<Student>("students").FindAll();
            return students;
        }
    
        public Student GetById(string id)
        {
            var query = Query<Student>.EQ(e => e.Id, id);
            var student = _database.GetCollection<Student>("students").FindOne(query);

            return student;
        }
    
        public void Add(Student student)
        {
             _database.GetCollection<Student>("students").Save(student);
        }
    
        public void Update(Student student)
        {
            var query = Query<Student>.EQ(x => x.Id, student.Id);
            var update = Update<Student>.Replace(student);
            _database.GetCollection<Student>("students").Update(query, update);
        }
    
        public bool Remove(string id)
        {
            var query = Query<Student>.EQ(x => x.Id, id);
            _database.GetCollection<Student>("students").Remove(query);
            
            return GetById(id) == null;
        }
    }
}