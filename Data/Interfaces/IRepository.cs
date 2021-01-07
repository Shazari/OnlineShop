using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public interface IRepository<T> where T:class
    {
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IList<T>> GetAllAsync();
        bool IsExist(int id);
    }
}
