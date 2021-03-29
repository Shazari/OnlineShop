using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Collections;

namespace ViewModels
{
    public class ProductViewModel
    {
      
        public long Id { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ProductName))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.Price))]
        public int Price { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.LongDescription))]
        [DataType(DataType.MultilineText)]
        public string LongDescription { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.ShortDescription))]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.ProductImage))]

        public bool IsExist { get; set; }
        public string Image { get; set; }
        // public IFormFile Picture { get; set; }
       

        public List<CategoriesViewModel> Categories { get; set; }
        public List<long> CategoriesId { get; set; }
        // public CartItemViewModel CartItem { get; set; }

       
}
    }
