using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class WeekDayRepository:Repository<Models.DayWeek>,IWeekDayRepository
    {
        public WeekDayRepository(Data.ParsMarketDbContext databaseContext):base(databaseContext)
        {
                
        }
    }
}
