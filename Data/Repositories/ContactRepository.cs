using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
   public class ContactRepository:Repository<Contact>,IContactRepository
    {
        internal ContactRepository(ParsMarketDbContext databaseContext):base(databaseContext)
        {

        }
    }
}
