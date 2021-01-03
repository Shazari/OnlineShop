using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Menu : BaseEntity
    {
        public Menu()
        {
            SubMenus = new List<Menu>();
        }


            public string Name { get; set; }

       //public Guid? ParentId { get; set; }
        public Menu Parent { get; set; }

            public ICollection<Menu> SubMenus { get; set; }

        public string PageUrl { get; set; }



        //[Display(Name = "نام منو در سیستم")]
        //public string Name { get; set; }

        //[Required(AllowEmptyStrings = true)]
        //[Display(Name = "آدرس صفحه")]
        //public string PageUrl { get; set; }

        //public Guid ParentId { get; set; }

        //public virtual ICollection<Menu> MenuId { get; set; }

    }
}
