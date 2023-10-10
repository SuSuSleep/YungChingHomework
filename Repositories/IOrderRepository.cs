using System.Globalization;
using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repositories
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetList(OrderSearchCondition orderSearchCondition);
        public Order? Get(long Id);
        public long Create(NewOrderInfo NewOrder);
        public bool Update(OrderInfo Order);
        public bool Delete(long Id);
    }
    public class OrderRepository : IOrderRepository
    {
        private byte[] DateToBytes(DateTime date)
        {
            string dateStr = date.ToString("yyyy-MM-dd");
            byte[] res = new byte[dateStr.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Convert.ToByte(dateStr[i]);
            }
            return res;
        }
        private DateTime BytesToDate(byte[]? bytes)
        {
            string temp = "";
            if (bytes == null) return DateTime.MinValue;
            foreach (byte b in bytes)
            {
                temp += Convert.ToChar(b);
            }
            return DateTime.ParseExact(temp, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public IEnumerable<Order> GetList(OrderSearchCondition orderSearchCondition)
        {
            using var dbContext = new NorthwindContext();
            var orders = dbContext.Orders.Where(c => true);
            if (orderSearchCondition.OrderId != null)
            {
                return orders.Where(c => c.OrderId == orderSearchCondition.OrderId).ToList();
            }

            if (orderSearchCondition.CustomerId != null)
            {
                orders = orders.Where(c => c.CustomerId == orderSearchCondition.CustomerId);
            }
            if (orderSearchCondition.StartDate != null)
            {
                orders = orders.Where(c => DateTime.Compare(BytesToDate(c.OrderDate), (DateTime)orderSearchCondition.StartDate) >= 0);
            }
            if (orderSearchCondition.EndDate != null)
            {
                orders = orders.Where(c => DateTime.Compare(BytesToDate(c.OrderDate), (DateTime)orderSearchCondition.EndDate) <= 0);
            }

            return orders.ToList();
        }
        public Order? Get(long Id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Orders.Where(c => c.OrderId == Id).FirstOrDefault();
        }
        public long Create(NewOrderInfo NewOrder)
        {
            using var dbContext = new NorthwindContext();
            long currentMaxId = dbContext.Orders.Max(c => c.OrderId);
            currentMaxId += 1;
            Order order = new Order
            {
                OrderId = currentMaxId,
                CustomerId = NewOrder.CustomerId,
                EmployeeId = NewOrder.EmployeeId,
                OrderDate = DateToBytes(NewOrder.OrderDate),
                ShipperId = NewOrder.ShipperId
            };
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return currentMaxId;
        }
        public bool Update(OrderInfo OrderInfo)
        {
            using var dbContext = new NorthwindContext();
            var order = dbContext.Orders.Where(c => c.OrderId.Equals(OrderInfo.OrderId)).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            order.CustomerId = OrderInfo.CustomerId;
            order.EmployeeId = OrderInfo.EmployeeId;
            order.OrderDate = DateToBytes(OrderInfo.OrderDate);
            order.ShipperId = OrderInfo.ShipperId;
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(long Id)
        {
            using var dbContext = new NorthwindContext();
            var order = dbContext.Orders.Where(c => c.OrderId.Equals(Id)).FirstOrDefault();
            if (order == null)
            {
                return false;
            }
            dbContext.Orders.Remove(order);
            dbContext.SaveChanges();
            return true;
        }
    }
}
