using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace ParsMarkt.Pages.Search
{
    public partial class SearchResult
    {
        public SearchResult()
        {
            Products = new List<ProductViewModel>();
        }
        [Inject]
      public IBasketServices BasketServces { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        
        [Parameter]
        public List<ProductViewModel> ContentValue { get; set; }
        public List<ProductViewModel> SearchResultContent;
        public List<ProductViewModel> Products;
        public List<ProductViewModel> Result;
        protected override async Task OnInitializedAsync()
        {
            
        }
        public async Task SearchResultAsync(string content)
        {
           
            SearchResultContent = new List<ProductViewModel>();
            SearchResultContent.AddRange(Products.Where(
                p => p.Name.Contains(content) || p.ShortDescription.Contains(content) || p.LongDescription.Contains(content)).ToList());

            Result = await Task.Run(() =>
                            SearchResultContent.Distinct().ToList());
            //if (Result.Any())
            //{
            //    //Navigation.NavigateTo($"/SearchResult{Result}");
            //}

        }


    }
}
