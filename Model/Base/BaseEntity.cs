using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class BaseEntity:Object
    {
        public BaseEntity()
        {
      
            InsertDateTime = DateTime.Now;

        }

        public int Id { get; set; }

        //Insert Date time
        public DateTime InsertDateTime { get; set; }

    }
}
