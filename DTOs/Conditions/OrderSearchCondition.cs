namespace YungChingHomework.DTOs.Conditions
{
    public class OrderSearchCondition
    {
        public long? OrderId { get; set; }
        public long? CustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
