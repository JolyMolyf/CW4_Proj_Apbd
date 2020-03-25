using System.Collections;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public interface IdbService
    {
        public IEnumerable<Student> GetStudents();


    }
}