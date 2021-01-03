using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Contact
{
    public partial class Contact
    {
        public Contact()
        {

            ObjContact = new ContactViewModel();
        }
        [Inject]
        public NavigationManager Navigation { get; set; }
        public ContactViewModel ObjContact;
        [Inject]
        public IContactServices ContactServic { get; set; }
        string message = "";
        private async Task ContactFormValidator()
        {
         
            var res=await ContactServic.PostAsync(ObjContact);
            if (res==null)
            {
                message = "Not send";
                Navigation.NavigateTo("/ContactUs");

            }
            message = "پیام شما با موفقیت ارسال شد";
            this.StateHasChanged();
            Navigation.NavigateTo("/ContactUs");

           
        }
    }
}
