using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ProductSelectedCategory:BaseEntity
    {
        public long  Id { get; set; }
        #region Properties
        public long ProductId { get; set; }

        public long CategoryId { get; set; }
        #endregion

        #region Relations
        public Product product { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}
