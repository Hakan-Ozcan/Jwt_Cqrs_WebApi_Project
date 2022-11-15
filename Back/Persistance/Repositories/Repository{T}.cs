using Back.Core.Application.Interfaces;
using Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly Jwt_CqrsContext jwt_CqrsContext;

        public Repository(Jwt_CqrsContext jwt_CqrsContext)
        {
            this.jwt_CqrsContext = jwt_CqrsContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.jwt_CqrsContext.Set<T>().AddAsync(entity);
            await this.jwt_CqrsContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.jwt_CqrsContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.jwt_CqrsContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.jwt_CqrsContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.jwt_CqrsContext.Set<T>().Remove(entity);
            await this.jwt_CqrsContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.jwt_CqrsContext.Set<T>().Update(entity);
            await this.jwt_CqrsContext.SaveChangesAsync();
        }
    }
}
