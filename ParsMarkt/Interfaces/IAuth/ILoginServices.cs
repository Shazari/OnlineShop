using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface ILoginServices
    {
        Task Login(string Token);
        Task LogOut();
        Task TryRenewToken();
    }
}
