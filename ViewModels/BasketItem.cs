using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModels;
namespace ViewModels
{
    public class BasketItem
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Price))]
        public decimal Price { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Count))]
        public int Count { get; set; }

        public ProductViewModel Product { get; set; }
        public OrderViewModel   Order { get; set; }

        //*****************************************************************************

       

       




    }
}


