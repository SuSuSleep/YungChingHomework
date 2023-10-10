using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;

namespace YungChingHomework.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderView> GetOrders(OrderSearchCondition orderSearchCondition);
        public OrderView GetOrder(long Id);
        public long CreateOrder(NewOrderInfo NewOrder);
        public bool UpdateOrder(OrderInfo UpdatedOrder);
        public bool DeleteOrder(long Id);
    }
}
