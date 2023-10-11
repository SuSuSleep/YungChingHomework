using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repositories
{
    public interface IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetList(OrderDetailSearchCondition OrderDetailSearchCondition);
        public OrderDetail? Get(long Id);
        public long Create(NewOrderDetailInfo NewOrderDetailInfo);
        public bool Update(OrderDetailInfo OrderDetailInfo);
        public bool Delete(long Id);
    }
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetList(OrderDetailSearchCondition OrderDetailSearchCondition)
        {
            using var dbContext = new NorthwindContext();
            var orderDetails = dbContext.OrderDetails.Where(c => true);
            if (OrderDetailSearchCondition.OrderDetailId != null)
            {
                return orderDetails.Where(c => c.OrderDetailId == OrderDetailSearchCondition.OrderDetailId).ToList();
            }

            if (OrderDetailSearchCondition.OrderId != null)
            {
                orderDetails = orderDetails.Where(c => c.OrderId.Equals(OrderDetailSearchCondition.OrderId));
            }
            if (OrderDetailSearchCondition.ProductIds != null)
            {
                orderDetails = orderDetails.Where(c => Array.Exists(OrderDetailSearchCondition.ProductIds, id => id == c.ProductId));
            }

            return orderDetails.ToList();
        }
        public OrderDetail? Get(long Id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.OrderDetails.Where(c => c.OrderDetailId == Id).FirstOrDefault();
        }
        public long Create(NewOrderDetailInfo NewOrderDetailInfo)
        {
            using var dbContext = new NorthwindContext();
            long currentMaxId = dbContext.OrderDetails.Max(c => c.OrderDetailId);
            currentMaxId += 1;
            OrderDetail orderDetail = new OrderDetail
            {
                OrderDetailId = currentMaxId,
                OrderId = NewOrderDetailInfo.OrderId,
                ProductId = NewOrderDetailInfo.ProductId,
                Quantity = NewOrderDetailInfo.Quantity
            };
            dbContext.OrderDetails.Add(orderDetail);
            dbContext.SaveChanges();
            return currentMaxId;
        }
        public bool Update(OrderDetailInfo OrderDetailInfo)
        {
            using var dbContext = new NorthwindContext();
            var orderDetail = dbContext.OrderDetails.Where(c => c.OrderDetailId.Equals(OrderDetailInfo.OrderDetailId)).FirstOrDefault();
            if (orderDetail == null)
            {
                return false;
            }
            orderDetail.OrderId = OrderDetailInfo.OrderId;
            orderDetail.ProductId = OrderDetailInfo.ProductId;
            orderDetail.Quantity = OrderDetailInfo.Quantity;
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(long Id)
        {
            using var dbContext = new NorthwindContext();
            var orderDetail = dbContext.OrderDetails.Where(c => c.OrderDetailId.Equals(Id)).FirstOrDefault();
            if (orderDetail == null)
            {
                return false;
            }
            dbContext.OrderDetails.Remove(orderDetail);
            dbContext.SaveChanges();
            return true;
        }
    }
}
