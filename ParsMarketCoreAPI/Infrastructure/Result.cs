using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsMarketCoreAPI
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
