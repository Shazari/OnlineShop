using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Models;
namespace Data
{
   public class MenuRepository:Repository<Menu>,IMenuRepository
    {
        internal MenuRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {
            
        }
        public virtual async Task<Menu> GetSubMenu(int id)
        {

            var Resault =await DbSet.Where(current => current.Parent.Id == id).FirstOrDefaultAsync();
            return Resault;
        }

    }
}
