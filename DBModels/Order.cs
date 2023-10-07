using System;
using System.Collections.Generic;

namespace YungChingHomework.DBModels;

public partial class Order
{
    public long OrderId { get; set; }

    public long? CustomerId { get; set; }

    public long? EmployeeId { get; set; }

    public byte[]? OrderDate { get; set; }

    public long? ShipperId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper? Shipper { get; set; }
}
