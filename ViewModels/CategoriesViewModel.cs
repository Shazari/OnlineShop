using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
   public class CategoriesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType =typeof(Resources.ErrorMessages),ErrorMessageResourceName =nameof(Resources.ErrorMessages.Required))]
        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Name))]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Description))]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        public string Description { get; set; }
        public bool Selected { get; set; }
        //public List<ProductViewModel> ProductViewModel { get; set; }
    }
}
