using System;
using System.Collections.Generic;

namespace YungChingHomework.DBModels;

public partial class Product
{
    public long ProductId { get; set; }

    public string? ProductName { get; set; }

    public long? SupplierId { get; set; }

    public long? CategoryId { get; set; }

    public string? Unit { get; set; }

    public byte[]? Price { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier? Supplier { get; set; }
}
