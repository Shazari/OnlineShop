using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt
{
    public class ContactServices : BaseServices, IContactServices
    {
        public ContactServices(HttpClient client):base(client)
        {

        }
        protected override string GetApiUrl()
        {
            return "Contacts";
        }
        public async Task<IList<ContactViewModel>> GetAsync()
        {

            var result = await GetAsync<IList<ContactViewModel>>();

            return result;
        }

        public async Task<ContactViewModel> PostAsync(ContactViewModel viewModel)
        {
            var result = await PostAsync<ContactViewModel, ContactViewModel>(viewModel);

            return result;
        }

       
    }
}
