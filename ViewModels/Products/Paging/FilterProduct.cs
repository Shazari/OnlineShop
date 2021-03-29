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
        public List<long> Categories { get; set; }
        public FilterProduct SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.PageCount = paging.PageCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.ActivePage = paging.ActivePage;
            return this;
        }

        public FilterProduct SetProducts(List<Product> products)
        {
            this.Products = products;
            return this;
        }
    }
}
