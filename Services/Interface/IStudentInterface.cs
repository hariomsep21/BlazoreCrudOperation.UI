using NewDemo.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDemo.Services.Interface
{
    public interface IStudentInterface
    {
        Task<IEnumerable<StudentModel>> GetStudents();
        Task<StudentModel> GetById(int id);
        Task<ServiceResponse> Create(StudentModel student);
        Task<ServiceResponse> Update(StudentModel student);
        Task<StudentModel> Delete(int id);


    }
}
