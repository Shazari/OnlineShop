using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace Data
{
    public interface IPersonRepository:IRepository<Person>
    {
        bool IsPersonExist(string id);

    }
}
