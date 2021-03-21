using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;
using ViewModels;

namespace ParsMarkt.Pages.Admin.Sliders.Add
{
    public partial class AddNewSlider
    {
        public AddNewSlider()
        {

        }

        [Inject]
        public IFileReaderService fileReader { get; set; }

        [Inject]
        public ISliderServices sliderServices { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public HttpClient client { get; set; }
        public SliderViewModel sliderViewModel { get; set; }


        public ElementReference inputRefrence;
        public string message = string.Empty;
        public string imagePath = null;
        string fileName = string.Empty;
        string fileName2 = string.Empty;
        Stream fileStream;
        protected override async Task OnInitializedAsync()
        {
            sliderViewModel = new SliderViewModel();
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
                message = "file is not a valid image";
            fileName = fileInfo.Name;
            //get the info of that file


            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {

                fileStream = new MemoryStream(ms.ToArray());
            }

        }
        public async Task OpenSecondFileAsync()
        {
            //read the file
            var file = (await fileReader.CreateReference(inputRefrence).EnumerateFilesAsync()).FirstOrDefault();

            if (file == null)
                return;

            var fileInfo = await file.ReadFileInfoAsync();

            string extention = Path.GetExtension(fileInfo.Name);
            string[] allowExtentions = { ".jpg", ".jpeg", ".png" };
            if (!allowExtentions.Contains(extention))
                message = "file is not a valid image";
            fileName2 = fileInfo.Name;
            //get the info of that file


            using (var ms = await file.CreateMemoryStreamAsync((int)fileInfo.Size))
            {

                fileStream = new MemoryStream(ms.ToArray());
            }

        }
        private async Task AddNew()
        {
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "image", fileName);


            var url = "https://localhost:44380";
            var respons = await client.PostAsync($"{url}/Images/SliderImage", content);
            if (respons.IsSuccessStatusCode)
            {
                var uploadedFileName = await respons.Content.ReadAsStringAsync();
                imagePath = url + '/' + uploadedFileName;
                message = "file has been uploaded successfully";
            }
            while (imagePath.Contains("\""))
            {
                imagePath = imagePath.Replace("\"", "");
            }
            sliderViewModel.ImageName = imagePath;
            sliderViewModel.SmallImageName = fileName2;
            await sliderServices.AddSlider(sliderViewModel);
        }
    }
}
