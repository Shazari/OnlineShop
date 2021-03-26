using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
   public class BasePaging
    {
        public BasePaging()
        {
            PageID = 1;
            TakeEntity = 10;
        }
        public int PageID { get; set; }
        public int  PageCount { get; set; }
        public int  ActivePage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }

    }
}
