using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
   public class CategoryToProductViewModel
    {
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public CategoriesViewModel Category { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
