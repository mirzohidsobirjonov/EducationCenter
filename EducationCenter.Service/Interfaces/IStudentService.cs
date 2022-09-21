
using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Service.DTOs.Students;
using EducationCenter.Service.DTOs.Users;
using System.Linq.Expressions;

namespace EducationCenter.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> AddAsync(StudentForCreationDTO student);
        Task<bool> DeleteAsync(Expression<Func<Student, bool>> student);
        Task<Student> GetAync(Expression<Func<Student, bool>> expression);
        Task<IEnumerable<Student>> GetAllAync(PaginationParams @params, Expression<Func<Student, bool>> expression);
        Task<Student> UpdateAsync(long id, StudentForCreationDTO student);
    }
}