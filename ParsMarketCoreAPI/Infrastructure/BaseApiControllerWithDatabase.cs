using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParsMarketCoreAPI
{
   
    public class BaseApiControllerWithDatabase : BaseApiController
    {
        public BaseApiControllerWithDatabase(Data.IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public Data.IUnitOfWork UnitOfWork { get;  }




        //public string sample()
        //{
   
        //}
        
    }
}
