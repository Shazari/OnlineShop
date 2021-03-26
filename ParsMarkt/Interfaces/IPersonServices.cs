using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
    public interface IPersonServices
    {
        Task<IList<PersonViewModel>> GetAsync();
        Task<PersonViewModel> GetByIdAsync(long id);
        Task<PersonViewModel> PostAsync(PersonViewModel viewModel);
        Task<PersonViewModel> PutAsync(PersonViewModel viewModel);

        Task<bool> DeleteAsync(int id);
        Task<PersonViewModel> PostPersonAsync(PersonViewModel viewModel);
        Task<PersonViewModel> PutPersonAsync<PersonViewModel>(PersonViewModel viewModel, long id);
    }
}
