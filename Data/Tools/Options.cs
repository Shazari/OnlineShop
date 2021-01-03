using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
   public class Options
    {
        public Options()
        {

        }
        public Provider Provider { get; set; }
        public string ConnectionString { get; set; }
    }
}
