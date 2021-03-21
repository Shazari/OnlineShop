using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class SliderViewModel
    {

        #region Properties
        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.ImageName))]
       // [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(200, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        public string ImageName { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.SmallSliderImage))]
        //[Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(200, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]

        public string SmallImageName { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.TitleOff))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(100, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Title { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Description))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(250, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Description { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary), Name = nameof(Resources.DataDictionary.Link))]
        [Required(ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.Required))]
        [MaxLength(200, ErrorMessageResourceType = typeof(Resources.ErrorMessages), ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Link { get; set; }
        #endregion
    }
}
