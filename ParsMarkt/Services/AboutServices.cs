﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;
    
namespace ParsMarkt
{
    public class AboutServices:BaseServices,IAboutServices
    {
        public AboutServices(HttpClient client):base(client)
        {

        }
        protected override string GetApiUrl()
        {
            return "Abouts";        }

        public Task<IList<AboutUsViewModel>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsViewModel> PostAsync(AboutUsViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsViewModel> PutAsync(AboutUsViewModel viewModel, int id)
        {
            throw new NotImplementedException();
        }

        public Task<AboutUsViewModel> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}