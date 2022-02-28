using System.Collections.Generic;
using CoolApi.Models;

namespace CoolApi.Services
{
    public interface IStudentService
    {
        List<Student> GetAllData();
    }
}