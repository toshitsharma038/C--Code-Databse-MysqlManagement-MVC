using System;
using System.Collections.Generic;
using System.Linq;
using CoolApi.Models;
using CoolApi.Repository;

namespace CoolApi.Services
{
    public class StudentServiceImpl : IStudentService
    {

        private IStudentDao _studentDao;

        public StudentServiceImpl(IStudentDao  context)
        {
           _studentDao = context;     
        }

        public List<Student> GetAllData()
        {
            List<Student> s1  = _studentDao.GetAllData();
            return s1;
        }
    }
}
