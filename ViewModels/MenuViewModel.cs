using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModels
{
    public class MenuViewModel
    {
        //public string Name { get; set; }

        ////public Guid? ParentId { get; set; }
        //public MenuViewModel Parent { get; set; }

        //public ICollection<MenuViewModel> SubMenus { get; set; }

        //public string PageUrl { get; set; }

        public int Id { get; set; }
        [Display(ResourceType = typeof(Resources.DataDictionary),
          Name = nameof(Resources.DataDictionary.Name))]
        public string Name { get; set; }

        public string PageUrl { get; set; }
        public MenuViewModel Parent { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
