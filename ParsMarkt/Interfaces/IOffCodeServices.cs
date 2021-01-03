using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IOffCodeServices
    {
        Task<IList<OffCodeViewModel>> GetAsync();
        Task<OffCodeViewModel> PostAsync(OffCodeViewModel viewModel);
    }
}
