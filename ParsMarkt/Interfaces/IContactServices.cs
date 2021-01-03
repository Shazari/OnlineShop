using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt
{
   public interface IContactServices
    {
        Task<IList<ContactViewModel>> GetAsync();
        Task<ContactViewModel> PostAsync(ContactViewModel viewModel);
    }
}
