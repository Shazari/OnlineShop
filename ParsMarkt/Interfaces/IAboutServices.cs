using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IAboutServices
    {
        Task<IList<AboutUsViewModel>> GetAsync();
        Task<AboutUsViewModel> PostAsync(AboutUsViewModel viewModel);
        Task<AboutUsViewModel> PutAsync(AboutUsViewModel viewModel,int id);
        Task<AboutUsViewModel> DeleteAsync(int id);
    }
}
