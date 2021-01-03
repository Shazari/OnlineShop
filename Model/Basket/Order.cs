﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Order:BaseEntity
    {
        
       
        [Required]


        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.RegisterDate))]
        public DateTime CreateDate { get; set; }


        [Display(ResourceType = typeof(Resources.DataDictionary),
            Name = nameof(Resources.DataDictionary.IsFinaly))]
        public bool IsFinaly { get; set; }

        [ForeignKey("UserId")]
        public Person Person { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
