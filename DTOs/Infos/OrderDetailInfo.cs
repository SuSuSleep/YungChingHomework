namespace YungChingHomework.DTOs.Infos
{
    public class NewOrderDetailInfo
    {

        public long? OrderId { get; set; }

        public long? ProductId { get; set; }

        public long? Quantity { get; set; }
    }
    public class OrderDetailInfo
    {
        public long OrderDetailId { get; set; }

        public long? OrderId { get; set; }

        public long? ProductId { get; set; }

        public long? Quantity { get; set; }
    }
}
