using System;
using System.Collections.Generic;


namespace Models

{
    public class Order : BaseEntity
    {
        #region properties

        public string UserId { get; set; }

        public bool IsPay { get; set; }

        public DateTime? PaymentDate { get; set; }

        #endregion

        #region relations

        public User User { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
