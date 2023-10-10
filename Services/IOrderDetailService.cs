using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;

namespace YungChingHomework.Services
{
    public interface IOrderDetailService
    {
        public IEnumerable<OrderDetailView> GetOrderDetails(OrderDetailSearchCondition OrderDetailSearchCondition);
        public OrderDetailView GetOrderDetail(long Id);
        public long CreateOrderDetail(NewOrderDetailInfo NewOrderDetail);
        public bool UpdateOrderDetail(OrderDetailInfo UpdatedOrderDetail);
        public bool DeleteOrderDetail(long Id);
    }
}
