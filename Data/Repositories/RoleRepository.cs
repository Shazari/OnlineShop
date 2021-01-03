using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
  public class RoleRepository:Repository<Roles>, IRoleRepository
    {
        public RoleRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }
    }
}
