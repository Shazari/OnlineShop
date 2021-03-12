
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class RegisterViewModel
    {
        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Email))]
        [MaxLength
           (length: Constant.Length.EMAIL_ADDRESS,
           ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string EmailAddress { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Password))]
        [MaxLength(30, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.ConfirmPassword))]
        [MaxLength(30, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
    public enum RegisterUserResult
    {
        Success,
        EmailExist,
    }
}
