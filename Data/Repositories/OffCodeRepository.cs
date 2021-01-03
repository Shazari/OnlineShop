using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public class OffCodeRepository : Repository<OffCodes>, IOffCodeRepository
    {
        internal OffCodeRepository(ParsMarketDbContext databaseContext) : base(databaseContext)
        {

        }

        public Task<IEnumerable<OffCodes>> GetAllOffCodesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
