using EducationCenter.Data.DbContexts;
using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Data.Repositpries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationCenterDbContext dbContext;

        public IGenericRepository<User> Users { get;}
        public IGenericRepository<Teacher> Teachers { get;}
        public IGenericRepository<Student> Students { get; }

        public UnitOfWork(EducationCenterDbContext dbContext)
        {
            this.dbContext = dbContext;

            Users = new GenericRepository<User>(dbContext);
            Teachers =  new GenericRepository<Teacher>(dbContext);
            Students = new GenericRepository<Student>(dbContext);
        }

        public void Dispose()
            => GC.SuppressFinalize(this);

        public async Task SaveChangesAsync()
            => await dbContext.SaveChangesAsync();
    }
}
