using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IRoleServices
    {
        Task<IList<RoleViewModel>> GetAsync();
        Task<RoleViewModel> GetAsyncById(int id);
        Task<RoleViewModel> PostAsync(RoleViewModel viewModel);
        Task<RoleViewModel> PutAsync(RoleViewModel viewModel);
        Task<RoleViewModel> DeleteAsync(int id);
    }
}
