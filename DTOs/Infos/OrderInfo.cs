namespace YungChingHomework.DTOs.Infos
{
    public class NewOrderInfo
    {
        public long? CustomerId { get; set; }

        public long? EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public long? ShipperId { get; set; }
    }
    public class OrderInfo
    {
        public long OrderId { get; set; }
        public long? CustomerId { get; set; }

        public long? EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public long? ShipperId { get; set; }
    }
}
