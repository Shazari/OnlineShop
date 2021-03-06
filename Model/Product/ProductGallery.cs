using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ProductGallery : BaseEntity
    {
        #region Properties
        public long ProductId { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.ProductImage))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string ImageName { get; set; }

        #endregion

        #region Relations
        public Product Product { get; set; }
        #endregion
    }
}
