using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Pages.Category
{
    public partial class Category
    {
        public Category()
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
            try
            {
                Categories = await CategoryService.GetAsync();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           

        }
        private int id;
        private void IdChanged(int newId)
        {
            id = newId;
        }
    }
}
