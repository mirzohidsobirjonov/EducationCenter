using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Teacher> Teachers { get; }
        IGenericRepository<Student> Students { get; }

        Task SaveChangesAsync();
    }
}
