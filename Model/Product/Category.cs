using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Category: BaseEntity
    {
        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.TitleOff))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Title { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.UrlTitle))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string UrlTitle { get; set; }

       
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.Description))]
        public long? ParentId{ get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
