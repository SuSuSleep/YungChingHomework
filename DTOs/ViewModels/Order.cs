using System.Globalization;
using YungChingHomework.DBModels;

namespace YungChingHomework.DTOs.ViewModels
{
    public class OrderView
    {
        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public long EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public long ShipperId { get; set; }
        public OrderView(Order order) 
        {
            OrderId = order.OrderId;
            CustomerId = order.CustomerId ?? 0;
            EmployeeId = order.EmployeeId ?? 0;
            ShipperId = order.ShipperId ?? 0;
            if (order.OrderDate == null) OrderDate = DateTime.MinValue;
            else
            {
                string temp = "";
                foreach (byte b in order.OrderDate)
                {
                    temp += Convert.ToChar(b);
                }
                OrderDate = DateTime.ParseExact(temp, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }
    }
}
