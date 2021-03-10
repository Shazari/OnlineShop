using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class BaseEntity: Object
    {
        public BaseEntity()
        {
      
            CreateDate = DateTime.Now;

        }

        public long Id { get; set; }
        public bool  IsDelete { get; set; }
        //Insert Date time
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
