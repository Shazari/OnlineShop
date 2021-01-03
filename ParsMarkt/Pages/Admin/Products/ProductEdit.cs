using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using System.IO;
using Tewr.Blazor.FileReader;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;

namespace ParsMarkt.Pages.Admin.Products
{
    public partial class ProductEdit
    {
        public ProductEdit()
        {
            Product = new ProductViewModel();
            Products = new List<ProductViewModel>();
            codes = new List<OffCodeViewModel>();
            categories = new List<CategoriesViewModel>();
            selectedCategories = new List<CategoriesViewModel>();
            selectedCodes = new List<OffCodeViewModel>();
            Product = new ProductViewModel();
        }

        [Inject]
        public IFileReaderService fileReader { get; set; }
        [Inject]
        public IProductServices ProductService { get; set; }
        [Inject]
        public ICategoryServices CategoryService { get; set; }
        [Inject]
        public IOffCodeServices OffCodeService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public HttpClient client { get; set; }

        public ProductViewModel Product;

        public IList<ProductViewModel> Products;

        public IList<CategoriesViewModel> categories;
        public IList<OffCodeViewModel> codes;
        private List<CategoriesViewModel> selectedCategories;
        private List<OffCodeViewModel> selectedCodes;

        [Parameter]
        public int Id { get; set; }

       
        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetAsync();
            Product = Products.Where(p => p.Id == Id).FirstOrDefault();
           // codes = await OffCodeService.GetAsync();
            categories = await CategoryService.GetAsync();

        }

        public ElementReference inputRefrence;
        public string message = string.Empty;
        public string imagePath = null;
        string fileName = string.Empty;
        Stream fileStream = null;

        public async Task OpenFileAsync()
        {
            //read the file
            var file = (await fileReader.CreateReference(inputRefrence).EnumerateFilesAsync()).FirstOrDefault();
            if (file == null)
                return;
            //get the info of that file
            var fileInfo = await file.ReadFileInfoAsync();
            fileName = fileInfo.Name;
            imagePath = fileName;
            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {
                fileStream = new MemoryStream(ms.ToArray());
            }
        }

       

        private async Task EditProduct()
        {
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "image", fileName);


            var url = "https://localhost:44380";
            var respons = await client.PutAsync($"{url}/Images", content);
            if (respons.IsSuccessStatusCode)
            {
                var uploadedFileName = await respons.Content.ReadAsStringAsync();
                imagePath = url + '/' + uploadedFileName;
                message = "file has been uploaded successfully";
            }
            while (imagePath.Contains("/+"))
            {
                imagePath += imagePath.Replace("/+", "/");
            }
            Product.CategoriesId = categories.Where(cat => cat.Selected).Select(cat => cat.Id).ToList();
            Product.Id = Id;
            Product.Image = imagePath;
            

            await  ProductService.PutAsync(Product);

            Products = await ProductService.GetAsync();

            navigationManager.NavigateTo("/ProductsManagement");
            this.StateHasChanged();

        }
        private void CheckboxChanged(ChangeEventArgs e, int key)
        {
            var i = this.categories.FirstOrDefault(i => i.Id == key);
            if (i != null)
            {
                i.Selected = (bool)e.Value;
            }
        }

    }
}
