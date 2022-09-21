using EducationCenter.Data.DbContexts;
using EducationCenter.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Data.Repositpries
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EducationCenterDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(EducationCenterDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await dbSet.AddAsync(entity);

            return entry.Entity;
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await GetAsync(expression);

            dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var query = expression is null ? dbSet : dbSet.Where(expression);

            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
            => await GetAll(expression).FirstOrDefaultAsync();

        public async Task<T> UpdateAsync(T entity)
            => dbSet.Update(entity).Entity;
    }
}