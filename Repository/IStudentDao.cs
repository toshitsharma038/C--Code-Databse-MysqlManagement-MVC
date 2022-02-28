using System.Collections.Generic;
using CoolApi.Models;

namespace CoolApi.Repository
{
    public interface IStudentDao
    {
        List<Student> GetAllData();
    }
}