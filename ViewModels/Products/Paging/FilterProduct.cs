using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace ViewModels
{
    public class FilterProduct : BasePaging
    {
        public string Title { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }

        public List<Product> Products { get; set; }
        public FilterProduct SetPaging(BasePaging paging)
        {
            return this;
        }

        public FilterProduct SetProducts(List<Product> products)
        {
            this.Products = products;
            return this;
        }
    }
}
