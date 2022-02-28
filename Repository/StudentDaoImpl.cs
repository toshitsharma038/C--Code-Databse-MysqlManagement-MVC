using System;
using System.Collections.Generic;
using System.Linq;
using CoolApi.Models;

namespace CoolApi.Repository
{
    public class StudentDaoImpl : IStudentDao
    {
        private StudentContext _studentContext;

         public StudentDaoImpl(StudentContext context)
        {
            _studentContext = context;
        }
       
       public List<Student> GetAllData()
        {
          try
            {
                return _studentContext.Students.ToList();
            }
            catch(Exception ex)
               {
                 Console.WriteLine("I am Exception "+ ex);
                 return null;
                }
        }
    }
}