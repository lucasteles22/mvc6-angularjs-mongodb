using WebApi.Models;
using System.Collections.Generic;
namespace WebApi.Repositories.Contracts
{
    public interface IStudentRepository
    {
        IEnumerable<Student> AllStudents();
    
        Student GetById(string id);
    
        void Add(Student student);
    
        void Update(Student student);
    
        bool Remove(string id);
    }
}