using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ViewModels;
using static System.Net.WebRequestMethods;
namespace ParsMarkt.Pages.Admin.Contacts
{
    public partial class ContactManagement
    {
       
        public IList<ContactViewModel> messages;
        public PersonViewModel message;

        [Inject]
        public IContactServices ContactServices { get; set; }

        [Inject]
        public NavigationManager NavigationService { get; set; }

        [Inject]
        protected System.Net.Http.HttpClient Http { get; set; }
        string viewMessage = "";
        protected override async Task OnInitializedAsync()
        {
            messages =await ContactServices.GetAsync();
            if (messages!=null)
            {
                this.StateHasChanged();
            }
        }
    }
}
