using Announcements.data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Announcements.data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task Edit(T entity);
        Task<bool> DeleteAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetDetailsAsync(long id);
    }
}
