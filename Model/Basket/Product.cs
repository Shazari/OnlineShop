using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Product: BaseEntity
    {

    

        [Display(ResourceType =typeof(Resources.DataDictionary),
            Name =nameof(Resources.DataDictionary.ProductName))]
        public string Name { get; set; }

      

        [Display(ResourceType =typeof(Resources.DataDictionary)
            ,Name =nameof(Resources.DataDictionary.Price))]
        public int Price { get; set; }


        [Display(ResourceType =typeof(Resources.DataDictionary),
            Name =nameof(Resources.DataDictionary.LongDescription))]
        public string LongDescription { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ShortDescription))]
        public string ShortDescription { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ProductImage))]
       
        public string  Image { get; set; }

        public List<OffCodes> Codes { get; set; }

        public List<Category> Categories { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
