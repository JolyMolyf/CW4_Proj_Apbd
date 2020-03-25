using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("weatherforecast")]
    public class StudentsController : ControllerBase
    {


        [HttpGet]
        public List<Student> GetStudent()
        {
            
            List<Student> students= new List<Student>(); 
            string connetionString = null;
            SqlConnection cnn ;
            connetionString = "Data Source=db-mssql;Integrated Security=true;Initial Catalog=2019SBD";
            cnn = new SqlConnection(connetionString);
            var command = new SqlCommand();
            command.Connection = cnn; 
            command.CommandText  = "SELECT FirstName, LastName, BirthDate, Semester, IndexNumber FROM Student,Enrollment,Studies where Student.IdEnrollment= Enrollment.IdEnrollment and Enrollment.idstudy=Studies.idstudy";
            
                cnn.Open();
                Console.WriteLine("connected");
                var reader = command.ExecuteReader();
              

                while (reader.Read()) {
                    var student = new Student();
                   
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.BirthDate = DateTime.Parse(reader["BirthDate"].ToString());
                    student.Semester = int.Parse(reader["Semester"].ToString());
                    student.IndexNumber = reader["IndexNumber"].ToString();
                    students.Add(student);
                    
                    Console.WriteLine(student);

                }
              
                foreach (Student std in students)
                {
                    Console.WriteLine(std.FirstName);
                }
              
                cnn.Close();
           
            return students;
        }

   
    }
    
    
}