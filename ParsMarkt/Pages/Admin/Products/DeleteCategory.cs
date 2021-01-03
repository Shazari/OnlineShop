using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParsMarkt.Pages.Admin.Products
{
    public partial class DeleteCategory
    {
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public ICategoryServices CategoryService { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await CategoryService.DeleteAsy(Id);
            Navigation.NavigateTo("/ProductsManagement");
        }
    }
}
