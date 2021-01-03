using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Pages.Admin.Products
{
    public partial class EditCategory
    {
        public EditCategory()
        {
            Categories = new List<CategoriesViewModel>();
        }
        [Inject]
        public ICategoryServices CategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManage { get; set; }
        IList<CategoriesViewModel> Categories;
        [Parameter]
        public int Id { get; set; }

        public CategoriesViewModel Category;
        protected override async Task OnInitializedAsync()
        {
            Category = new CategoriesViewModel();
            Categories = await CategoryService.GetAsync();
            Category = Categories.Where(c=>c.Id==Id).FirstOrDefault();
        }

        protected async Task SubmitEdit()
        {
            var res = await CategoryService.PutAsync(Category);


            NavigationManage.NavigateTo("/ProductsManagement");
            
        }
        }
    }
