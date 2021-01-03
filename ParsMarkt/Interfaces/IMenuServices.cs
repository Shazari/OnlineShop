using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public interface IMenuServices
    {
        Task<IList<MenuViewModel>> GetAsync();
        Task<MenuViewModel> GetByIdAsync(int id);
        Task<MenuViewModel> PostAsync(ViewModels.MenuViewModel viewModel);
        Task<MenuViewModel> PutAsync(MenuViewModel viewModel);
        Task<MenuViewModel> DeleteAsync(int id);
    }
}
