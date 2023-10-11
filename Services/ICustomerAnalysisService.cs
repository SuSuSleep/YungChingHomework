using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DBModels;
using YungChingHomework.Service;
using Microsoft.CodeAnalysis;

namespace YungChingHomework.Services
{
    public interface ICustomerAnalysisService
    {
        public CustomerProductCash GetCustomerProductCash(long CustomerId);
    }
    public class CustomerAnalysisService : ICustomerAnalysisService
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public CustomerAnalysisService(IOrderDetailService orderDetailService, IProductService productService, IOrderService orderService, ICustomerService customerService)
        {
            _orderDetailService = orderDetailService;
            _productService = productService;
            _orderService = orderService;
            _customerService = customerService;
        }

        public CustomerProductCash? GetCustomerProductCash(long CustomerId)
        {
            CustomerView? customer = _customerService.GetCustomer(CustomerId);
            if (customer == null) { return null; }
            CustomerProductCash customerProductCash = new CustomerProductCash
            {
                Name = customer.CustomerName,
                ProductCashs = new List<ProductCash>()
            };
            OrderSearchCondition orderCondition = new OrderSearchCondition
            {
                CustomerId = CustomerId,
            };
            List<OrderView> orders = _orderService.GetOrders(orderCondition).ToList();
            IDictionary<long, string> productNameTable = new Dictionary<long, string>();
            IDictionary<long, double> productPriceTable = new Dictionary<long, double>();
            IDictionary<long, double> productCashTable = new Dictionary<long, double>();
            foreach (OrderView orderView in orders)
            {
                OrderDetailSearchCondition orderDetailCondition = new OrderDetailSearchCondition
                {
                    OrderId = orderView.OrderId
                };
                List<OrderDetailView> orderDetails = _orderDetailService.GetOrderDetails(orderDetailCondition).ToList();
                foreach (OrderDetailView orderDetail in orderDetails)
                {
                    if (!productPriceTable.ContainsKey(orderDetail.ProductId))
                    {
                        ProductView? product = _productService.GetProduct(orderDetail.ProductId);
                        if (product == null) continue;
                        productPriceTable[orderDetail.ProductId] = product.Price;
                        productNameTable[orderDetail.ProductId] = product.ProductName;
                    }
                    if (!productPriceTable.ContainsKey(orderDetail.ProductId)) continue;
                    if (productCashTable.ContainsKey(orderDetail.ProductId))
                    {
                        productCashTable[orderDetail.ProductId] += orderDetail.Quantity * productPriceTable[orderDetail.ProductId];
                    }
                    else
                    {
                        productCashTable[orderDetail.ProductId] = orderDetail.Quantity * productPriceTable[orderDetail.ProductId];
                    }
                }
            }
            List<ProductCash> productCashes = new List<ProductCash>();
            foreach (var prodcutCashPair in productCashTable)
            {
                productCashes.Add(new ProductCash
                {
                    ProductName = productNameTable[prodcutCashPair.Key],
                    CashAmount = prodcutCashPair.Value
                });
            }
            customerProductCash.ProductCashs = productCashes;
            return customerProductCash;
        }
    }
}
