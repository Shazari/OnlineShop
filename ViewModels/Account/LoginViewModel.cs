using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class LoginViewModel
    {

        [Display(ResourceType = typeof(Resources.DataDictionary),
         Name = nameof(Resources.DataDictionary.Email))]
        [DataType(DataType.EmailAddress)]
        [MaxLength
          (length: Constant.Length.EMAIL_ADDRESS,
          ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.ConfirmPassword))]
        [MaxLength(30, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
          ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string PasswordHash { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.RememberMe))]
        public bool RememberMe { get; set; }
        
       
    }
    public enum LoginUserResult
    {
        Success,
        IncorrectData,
        NotActivated
    }
}
