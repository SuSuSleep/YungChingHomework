using YungChingHomework.DTOs.ViewModels;

namespace YungChingHomework.Services
{
    public interface ICustomerAnalysisService
    {
        public CustomerProductCash GetCustomerProductCash(long CustomerId, DateTime? StartDate, DateTime? EndDate);
        public ProductCash GetProductCash(long OrderId, long ProductId);
    }
}
