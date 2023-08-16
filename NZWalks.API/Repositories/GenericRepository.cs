using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;

namespace NZWalks.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WalksContext context;

        public GenericRepository(WalksContext context)
        {
            this.context = context;
        }
        public async Task<T> Create(T entity)
        {
           await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }
          return await context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
