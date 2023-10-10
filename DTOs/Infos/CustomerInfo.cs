namespace YungChingHomework.DTOs.Infos
{
    public class NewCustomerInfo
    {
        public string? CustomerName { get; set; }
        public string? ContactName { get; set;}
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }
    }

    public class CustomerInfo
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }
    }
    public class GetCustomerAmountInfo
    {
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long[]? ProductIds { get; set; } 
    }
}
