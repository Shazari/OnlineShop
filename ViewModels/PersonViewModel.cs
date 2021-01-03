using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class PersonViewModel
    {
        public int Id { get; set; }

    
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.FirstName))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.LastName))]
        [MaxLength(20, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.PhoneNumber))]
        [MaxLength(15, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.MaxLength))]
        [MinLength(7, ErrorMessageResourceType = typeof(Resources.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.ErrorMessages.Minlegth))]
        public int PhoneNumber { get; set; }


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
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Address))]
        public string Address { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.City))]
        public string City { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.PostCode))]
        public int PostCode { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.CountryName))]
        public string Countries { get; set; }




     
       // public RoleViewModel Role { get; set; }

       // public List<OrderViewModel> Orders { get; set; }
    }
}

