using System;
using System.Collections.Generic;
using System.Text;
using Data;
using System.Threading.Tasks;
using Models;
namespace Data
{
   public interface IMenuRepository:IRepository<Menu>
    {
        Task<Menu> GetSubMenu(int id);
    }
}
