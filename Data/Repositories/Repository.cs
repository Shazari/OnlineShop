using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Models;
namespace Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
        internal ParsMarketDbContext DatabaseContext { get; }
        internal Repository(ParsMarketDbContext databaseContxt)
        {
            DatabaseContext = databaseContxt ?? throw new System.ArgumentNullException(paramName: nameof(databaseContxt));

           DbSet= databaseContxt.Set<T>();

        }

        public virtual async Task Delete(T entity)
        {

            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await System.Threading.Tasks.Task.Run(() =>
            {
                DbSet.Remove(entity);
            });

        }

        public virtual async Task<T> GetById(long id)
        {
            var resault = await DbSet.FindAsync(keyValues:id);
            return resault;
        }
        public virtual async Task<IList<T>> GetAllAsync()
        {
            //return await DbSet.ToListAsync();

            var result =
                await
                DbSet.ToListAsync()
                ;

            return result;

        }

        public virtual async Task Insert(T entity)
        {

            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() => {
                DbSet.Add(entity);
            });
        }

        public virtual async Task Update(T entity)
        {
            
            if (entity == null)
            {
                throw new System.ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(()=>
            {
                //DatabaseContext.Attach(entity);
                DbSet.Update(entity);
            }
            );
        }

        //public async Task<bool> IsExist(Guid id)
        //{
        //    return await DbSet.AnyAsync(e=>e.Id==id);
        //}

        bool IRepository<T>.IsExist(long id)
        {

            var b=DbSet.Any(e => e.Id == id);
            return true;
        }

      
    }
}
