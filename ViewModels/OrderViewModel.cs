using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ViewModels
{
  public class OrderViewModel
    {

        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.RegisterDate))]
        [Required]
        public DateTime CreateDate { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.IsFinaly))]
        public bool IsFinaly { get; set; }


        //porsideh shavad
       
         public PersonViewModel Person { get; set; }
        public List<BasketItem> BasketItems { get; set; }
    }
}
