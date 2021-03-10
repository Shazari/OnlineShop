using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Resources;
namespace ViewModels
{
   public class ContactViewModel
    {
        public long Id { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.LastName))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string Name { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Email))]
        [MaxLength
           (length: Constant.Length.EMAIL_ADDRESS,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.PhoneNumber))]
        [MaxLength(15, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(7, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string Telephone { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
       Name = nameof(Resources.DataDictionary.ShortDescription))]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
