using EducationCenter.Domain.Configurations;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Users;
using EducationCenter.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> AddAsync(UserForCrerationDTO user);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<User> GetAync(Expression<Func<User, bool>> expression);
        Task<IEnumerable<User>> GetAllAync(PaginationParams @params, Expression<Func<User, bool>> expression = null);
        Task<User> UpdateAsync(long id, UserForCrerationDTO user);
    }
}
