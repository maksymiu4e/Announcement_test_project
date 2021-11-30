using Announcements.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task EditAsync(T entity);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetDetailsAsync(long id);
    }
}
