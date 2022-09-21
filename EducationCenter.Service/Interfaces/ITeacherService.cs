using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Service.DTOs.Students;
using EducationCenter.Service.DTOs.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> AddAsync(TeacherForCreationDTO teacher);
        Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression);
        Task<IEnumerable<Teacher>> GetAllAync(PaginationParams @params, Expression<Func<Teacher, bool>> expression);
        Task<Teacher> UpdateAsync(long id, TeacherForCreationDTO teacher);
    }
}
