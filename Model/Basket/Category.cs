using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Category: BaseEntity
    {
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Name))]

        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
