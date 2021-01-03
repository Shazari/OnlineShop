using System;
using System.Collections.Generic;
using System.Text;
using Resources;
namespace Models
{
   public class Contact:BaseEntity
    {

       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Text { get; set; }
    }
}
