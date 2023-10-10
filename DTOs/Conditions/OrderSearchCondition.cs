namespace YungChingHomework.DTOs.Conditions
{
    public class OrderSearchCondition
    {
        public long? OrderId { get; set; }
        public long? CustomerId { get; set; }
        public byte[]? StartDate { get; set; }
        public byte[]? EndDate { get; set; }
    }
}
