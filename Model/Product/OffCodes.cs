using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class OffCodes:BaseEntity
    {
        
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.TitleOff))]
        public string Title { get; set; }
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.ProductCode))]
        public int Code { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
