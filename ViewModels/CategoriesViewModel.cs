using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
   public class CategoriesViewModel
    {
        public long Id { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.TitleOff))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Title { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.UrlTitle))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string UrlTitle { get; set; }
        public string? Description { get; set; }

       
        public long? ParentId { get; set; }
        public bool Selected { get; set; }
        //public List<ProductViewModel> ProductViewModel { get; set; }
    }
}
