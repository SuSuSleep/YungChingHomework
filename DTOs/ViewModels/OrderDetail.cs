using YungChingHomework.DBModels;

namespace YungChingHomework.DTOs.ViewModels
{
    public class OrderDetailView
    {
        public long OrderDetailId { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public long Quantity { get; set; }
        public OrderDetailView(OrderDetail orderDetail)
        {
            OrderDetailId = orderDetail.OrderDetailId;
            OrderId = orderDetail.OrderId ?? 0;
            ProductId = orderDetail.ProductId ?? 0;
            Quantity = orderDetail.Quantity ?? 0;
        }
    }
}
