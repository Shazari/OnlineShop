using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
    public interface IAccountsServices
    {
        Task<RegisterViewModel> Resister(RegisterViewModel viewModel);
        Task<UserToken> Login(LoginViewModel viewModel);
        Task Logout();
    }
}
