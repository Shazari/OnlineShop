using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
namespace ParsMarkt.Shared.Header
{
    public partial class Search
    {
        public Search()
        {
            Products = new List<ProductViewModel>();
            Result = new List<ProductViewModel>();
        }

        [Inject]
        public IBasketServices BasketServices { get; set; }

        public List<ProductViewModel> Products;
        //be Event Niaz Darad
        [Parameter]
        public string Content { get; set; } = "";
        protected override async Task OnInitializedAsync()
        {
            var res = await BasketServices.GetAsync();
            Products = res.ToList();

        }
        public List<ProductViewModel> SearchResultContent;

        [Inject]
        public NavigationManager Navigation { get; set; }

        public List<ProductViewModel> Result;
        public async Task SearchResultAsync()
        {
            Navigation.NavigateTo($"/SearchResult");
            //content = Content;
            //SearchResultContent = new List<ProductViewModel>();
            //SearchResultContent.AddRange(Products.Where(
            //    p => p.Name.Contains(content) || p.ShortDescription.Contains(content) || p.LongDescription.Contains(content)).ToList());

            //Result=await Task.Run(()=>
            //                   SearchResultContent.Distinct().ToList());
            //if (Result.Any())
            //{
            //    Navigation.NavigateTo($"/SearchResult{Result}");
            //}

        }
    }
}
