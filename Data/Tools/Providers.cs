
using System;
using System.Collections.Generic;
using System.Text;
using Models;
namespace Data
{
    public enum Provider:int
    {
        SqlServer=0,
        MySql=1,
        PostgreSQL = 2,
        Oracle = 3,
        InMemory = 4,
    }
}
