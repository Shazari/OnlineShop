using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Product : BaseEntity
    {


        #region Properties

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Name))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Name { get; set; }



        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Price))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public int Price { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.LongDescription))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string LongDescription { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.ShortDescription))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string ShortDescription { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.ProductImage))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        public string Image { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.IsExist))]
        public bool IsExist { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.IsSpecial))]
        public bool IsSpecial { get; set; }
        #endregion

        #region Relations

        public ICollection<ProductGallery> productGalleries { get; set; }
        public ICollection<ProductVisit> productVisits { get; set; }
        public List<OffCodes> Codes { get; set; }

        public List<Category> Categories { get; set; }

        public List<Cart> Carts { get; set; }


        #endregion
    }
}
