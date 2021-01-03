using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IOrderServices
    {
        Task<IList<OrderViewModel>> GetAsync();
        Task<OrderViewModel> GetByIdAsync();
        Task<OrderViewModel> PostAsync(OrderViewModel viewModel);
        Task<OrderViewModel> PutAsync(OrderViewModel viewModel);
        Task<bool> DeleteAsync(int id);
       

    }
}
