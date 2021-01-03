using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Cart : BaseEntity
    {
     

        [Required]
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Price))]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public int Count { get; set; }
        
       

       

        public Product Product { get; set; }
        public Order Order { get; set; }







    }
}
