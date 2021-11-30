using Announcements.data.Entities;
using Announcements.data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Announcements.data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _applicationContext;
        private readonly DbSet<T> _entityDbSet;

        public Repository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _entityDbSet = applicationContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            await _entityDbSet.AddAsync(entity);            
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var found = await _entityDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
            if (found != null)
            {
                _entityDbSet.Remove(found);
                return true;
            }
            return false;
        }

        public async Task EditAsync(T entity)
        {
            _applicationContext.Entry(entity).State = EntityState.Modified;
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entityDbSet.ToListAsync();
        }

        public async Task<T> GetDetailsAsync(long id)
        {
            return await _entityDbSet.FirstOrDefaultAsync(entity => entity.Id == id);
        }
    }
}
