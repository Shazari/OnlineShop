using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using System.IO;

using Tewr.Blazor.FileReader;
using System.Net.Http;
using System.Net.Http.Json;

namespace ParsMarkt.Pages.Admin.Products
{
    public partial class ProductsManagement
    {

        public ProductsManagement()
        {
            Product = new ProductViewModel();
            Products = new List<ProductViewModel>();
            codes = new List<OffCodeViewModel>();
            categories = new List<CategoriesViewModel>();
            selectedCategories = new List<CategoriesViewModel>();
            selectedCodes = new List<OffCodeViewModel>();
        }
        [Inject]
        public IProductServices ProductService { get; set; }
        [Inject]
        public IFileReaderService fileReader { get; set; }
        [Inject]
        public ICategoryServices CategoryService { get; set; }
        [Inject]
        public IOffCodeServices OffCodeService { get; set; }
        [Inject]
        public HttpClient client { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public ProductViewModel Product;

        public IList<ProductViewModel> Products;

        public IList<CategoriesViewModel> categories;
        public IList<OffCodeViewModel> codes;
        private List<CategoriesViewModel> selectedCategories;
        private List<OffCodeViewModel> selectedCodes;
        public ElementReference inputRefrence;
        public string message = string.Empty;
        public string imagePath = null;
        string fileName = string.Empty;
        Stream fileStream;
        
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetAsync();
            codes = await OffCodeService.GetAsync();
            categories = await CategoryService.GetAsync();

        }

        public async Task OpenFileAsync()
        {
            //read the file
            var file = (await fileReader.CreateReference(inputRefrence).EnumerateFilesAsync()).FirstOrDefault();

            if (file == null)
                return;

            var fileInfo = await file.ReadFileInfoAsync();

            string extention = Path.GetExtension(fileInfo.Name);
            string[] allowExtentions = { ".jpg", ".jpeg", ".png" };
            if (!allowExtentions.Contains(extention))
                message="file is not a valid image";
            fileName = fileInfo.Name;
            //get the info of that file


            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {

               fileStream = new MemoryStream(ms.ToArray());
            }

        }
        private async Task AddProduct()
        {
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "image", fileName);
           
            
            var url = "https://localhost:44380";
            var respons = await client.PostAsync($"{url}/Images",content);
            if (respons.IsSuccessStatusCode)
            {
                var uploadedFileName =await respons.Content.ReadAsStringAsync();
                imagePath = url+'/'+uploadedFileName;
                message = "file has been uploaded successfully";
            }
            while (imagePath.Contains("/+"))
            {
                imagePath += imagePath.Replace("/+","/");
            }
            Product.CategoriesId = categories.Where(cat => cat.Selected).Select(cat => cat.Id).ToList();
            Product.Image = imagePath.ToString();
            await ProductService.PostAsync(Product);
            Products = await ProductService.GetAsync();
           
            navigationManager.NavigateTo("/ProductsManagement");
            
        }

        private void CheckboxChanged(ChangeEventArgs e, int key)
        {
            var i = this.categories.FirstOrDefault(i => i.Id == key);
            if (i != null)
            {
                i.Selected = (bool)e.Value;
            }
        }

        private void EditProduct()
        {

        }
        private void DeleteProduct()
        {

        }
    }
}
