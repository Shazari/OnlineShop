using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IProductServices
    {
        Task<IList<ProductViewModel>> GetAsync();
        Task<FilterProduct> GetFilterProduct();
        Task<ProductViewModel> GetAsyncById(int id);
        Task<ProductViewModel> PostAsync(ProductViewModel viewModel);
        Task<ProductViewModel> PutAsync(ProductViewModel viewModel);
        Task<bool> DeleteAsync(int id);
    }
}
