﻿
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class ProductComment : BaseEntity
    {
        #region properties

        public long ProductId { get; set; }

        public long UserId { get; set; }

        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Text { get; set; }

        #endregion

        #region relations

        public Product Product { get; set; }

        public User User { get; set; }

        #endregion

    }
}
