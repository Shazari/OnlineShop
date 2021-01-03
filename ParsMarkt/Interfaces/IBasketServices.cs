using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IBasketServices
    {
        Task<IList<ProductViewModel>> GetAsync();
        Task<ProductViewModel> PostAsync(ProductViewModel viewModel);
    }
}
