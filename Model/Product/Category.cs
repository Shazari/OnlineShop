using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Description { get; set; }

        [ForeignKey("ParentId")]
        public long? ParentId{ get; set; }

        public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }
    }
}
