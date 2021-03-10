using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public interface IRepository<T> where T:BaseEntity
    {
        Task<T> GetById(long id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IList<T>> GetAllAsync();
        bool IsExist(long id);
    }
}
