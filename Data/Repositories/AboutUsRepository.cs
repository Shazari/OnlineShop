using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
   public class AboutUsRepository:Repository<AboutUs>,IAboutUsRepository
    {
        public AboutUsRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }
    }
}
