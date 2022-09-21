using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Data.DbContexts
{
    public class EducationCenterDbContext : DbContext
    {
        public EducationCenterDbContext(DbContextOptions<EducationCenterDbContext> option) 
            : base(option)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
