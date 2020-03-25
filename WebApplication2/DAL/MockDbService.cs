using System;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class MockDbService : IdbService
    {
        public IEnumerable<Student> GetStudents()
        {
         Console.Error
        }
    }
}
