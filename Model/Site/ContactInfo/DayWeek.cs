using System;
using System.Collections.Generic;
using System.Text;
using Resources;
namespace Models
{
   public class DayWeek:BaseEntity
    {
        public string  Day { get; set; }
        public string  StartTime { get; set; }
        public string  EndTime { get; set; }

    }
}
