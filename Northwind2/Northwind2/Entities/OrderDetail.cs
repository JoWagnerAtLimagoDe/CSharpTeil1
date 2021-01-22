using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Northwind2.Entities
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        // [NotMapped]
        // public decimal Total {
        //     get
        //     {
        //         return UnitPrice * Quantity;
        //     }
        // }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"{nameof(UnitPrice)}: {UnitPrice}, {nameof(Quantity)}: {Quantity}";
        }
    }
}
