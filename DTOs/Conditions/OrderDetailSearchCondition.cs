namespace YungChingHomework.DTOs.Conditions
{
    public class OrderDetailSearchCondition
    {
        public long? OrderDetailId { get; set; }
        public long? OrderId { get; set; }
        public long[]? ProductIds { get; set; }
    }
}
