
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
        public string Email { get; set; }


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

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.FirstName))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(3, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string FirstName { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.LastName))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(3, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Address))]
        public string Street_Number { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
         Name = nameof(Resources.DataDictionary.PhoneNumber))]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.City))]
        public string City { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.PostCode))]
        public int PostCode { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.CountryName))]
        public string Countries { get; set; }
    }
    public enum RegisterUserResult
    {
        Success,
        EmailExist,
    }
}
