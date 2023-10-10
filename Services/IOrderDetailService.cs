using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;

namespace YungChingHomework.Services
{
    public interface IOrderDetailService
    {
        public IEnumerable<OrderDetailView> GetOrderDetails(OrderDetailSearchCondition OrderDetailSearchCondition);
        public OrderDetailView? GetOrderDetail(long Id);
        public long CreateOrderDetail(NewOrderDetailInfo NewOrderDetail);
        public bool UpdateOrderDetail(OrderDetailInfo UpdatedOrderDetail);
        public bool DeleteOrderDetail(long Id);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetailView> GetOrderDetails(OrderDetailSearchCondition OrderDetailSearchCondition)
        {
            List<OrderDetail> orderDetails = _orderDetailRepository.GetList(OrderDetailSearchCondition).ToList();
            List<OrderDetailView> orderDetailViews = new List<OrderDetailView>();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                orderDetailViews.Add(new OrderDetailView(orderDetail));
            }
            return orderDetailViews;
        }
        public OrderDetailView? GetOrderDetail(long Id)
        {
            OrderDetail? orderDetail = _orderDetailRepository.Get(Id);
            if (orderDetail == null) return null;
            return new OrderDetailView(orderDetail);
        }
        public long CreateOrderDetail(NewOrderDetailInfo NewOrderDetail)
        {
            long NewOrderDetailId = _orderDetailRepository.Create(NewOrderDetail);
            return NewOrderDetailId;
        }
        public bool UpdateOrderDetail(OrderDetailInfo UpdatedOrderDetail)
        {
            bool updateSuccess = _orderDetailRepository.Update(UpdatedOrderDetail);
            return updateSuccess;
        }
        public bool DeleteOrderDetail(long Id)
        {
            bool deleteSuccess = _orderDetailRepository.Delete(Id);
            return deleteSuccess;
        }
    }
}
