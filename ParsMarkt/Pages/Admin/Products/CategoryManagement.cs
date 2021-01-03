using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Pages.Admin.Products
{
    public partial class CategoryManagement
    {
        public CategoryManagement()
        {
            Categories = new List<CategoriesViewModel>();
            categoryViewModel = new CategoriesViewModel();
        }
        [Inject]
        public ICategoryServices CategoryService { get; set; }

        [Inject]
        public NavigationManager Navigatemanager { get; set; }

        public IList<CategoriesViewModel> Categories;

        private CategoriesViewModel categoryViewModel;

        protected override async Task OnInitializedAsync()
        {
         Categories=await CategoryService.GetAsync();
        }

        private async Task<CategoriesViewModel> AddCategory()
        {
           var res= await CategoryService.PostAsync(categoryViewModel);
            Navigatemanager.NavigateTo("/ProductsManagement");
            return res;
  
        }
        private async Task<CategoriesViewModel> EditSubmitCategory()
        {
            var cat = await CategoryService.GetAsync();
            var id = categoryViewModel.Id;
            
            var res = await CategoryService.PutAsync(categoryViewModel);
            Navigatemanager.NavigateTo("/ProductsManagement");
            return res;
           
        }
        private async Task<CategoriesViewModel> RemoveCategory()
        {
            var res = await CategoryService.DeleteAsync(categoryViewModel);
            Navigatemanager.NavigateTo("/ProductsManagement");
            return res;
           
        }
    }
}
