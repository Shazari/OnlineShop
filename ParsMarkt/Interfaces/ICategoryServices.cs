using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface ICategoryServices
    {
        Task<IList<CategoriesViewModel>> GetAsync();
        Task<CategoriesViewModel> PostAsync(CategoriesViewModel viewModel);
        Task<CategoriesViewModel> PutAsync(CategoriesViewModel viewModel);
       
        Task<CategoriesViewModel> DeleteAsync(CategoriesViewModel viewModel);
        Task<bool> DeleteAsy(int id);
        Task<bool> PutAsy(CategoriesViewModel viewModel);
    }
}
