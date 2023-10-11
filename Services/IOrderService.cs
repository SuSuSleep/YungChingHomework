using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;

namespace YungChingHomework.Services
{
    public interface IOrderService
    {
        public IEnumerable<OrderView> GetOrders(OrderSearchCondition orderSearchCondition);
        public OrderView? GetOrder(long Id);
        public long CreateOrder(NewOrderInfo NewOrder);
        public bool UpdateOrder(OrderInfo UpdatedOrder);
        public bool DeleteOrder(long Id);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailService _orderDetailService;
        public OrderService(IOrderRepository orderRepository, IOrderDetailService orderDetailService)
        {
            _orderRepository = orderRepository;
            _orderDetailService = orderDetailService;
        }

        public IEnumerable<OrderView> GetOrders(OrderSearchCondition orderSearchCondition)
        {
            List<Order> orders = _orderRepository.GetList(orderSearchCondition).ToList();
            List<OrderView> orderViews = new List<OrderView>();
            foreach (Order order in orders)
            {
                orderViews.Add(new OrderView(order));
            }
            return orderViews;
        }
        public OrderView? GetOrder(long Id)
        {
            Order? order = _orderRepository.Get(Id);
            if (order == null) return null;
            return new OrderView(order);
        }
        public long CreateOrder(NewOrderInfo NewOrder)
        {
            long NewOrderId = _orderRepository.Create(NewOrder);
            return NewOrderId;
        }
        public bool UpdateOrder(OrderInfo UpdatedOrder)
        {
            bool updateSuccess = _orderRepository.Update(UpdatedOrder);
            return updateSuccess;
        }
        public bool DeleteOrder(long Id)
        {
            OrderDetailSearchCondition orderDetailSearchCondition = new OrderDetailSearchCondition
            {
                OrderId = Id
            };
            List<OrderDetailView> orderDetailViews = _orderDetailService.GetOrderDetails(orderDetailSearchCondition).ToList();
            foreach (OrderDetailView view in orderDetailViews)
            {
                _orderDetailService.DeleteOrderDetail(view.OrderDetailId);
            }
            bool deleteSuccess = _orderRepository.Delete(Id);
            return deleteSuccess;
        }
    }
}
