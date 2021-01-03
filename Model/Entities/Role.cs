using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models
{
   public class Roles:BaseEntity
    {
     
        public string   Name { get; set; }
        public string   Title { get; set; }
        public ICollection<Person> Person { get; set; }



    }
}
