using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class User:IdentityUser
    {
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
           Name = nameof(Resources.DataDictionary.IsActive))]
        public bool IsActive { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.DataDictionary),
           Name = nameof(Resources.DataDictionary.IsAdmin))]
        public bool IsAdmin { get; set; }


        



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
    }
}
