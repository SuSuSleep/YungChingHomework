using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Update;
using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Repositories;

namespace YungChingHomework.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductView> GetProducts();
        public ProductView? GetProduct(long Id);
        public long CreateProduct(NewProductInfo NewProduct);
        public bool UpdateProduct(ProductInfo UpdatedProduct);
        public bool DeleteProduct(long Id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductView> GetProducts()
        {
            List<Product> products = _productRepository.GetList().ToList();
            List<ProductView> productViews = new List<ProductView>();
            foreach (Product product in products)
            {
                productViews.Add(new ProductView(product));
            }
            return productViews;
        }
        public ProductView? GetProduct(long Id)
        {
            Product? product = _productRepository.Get(Id);
            if (product == null) return null;
            return new ProductView(product);
        }
        public long CreateProduct(NewProductInfo NewProduct)
        {
            long NewProductId = _productRepository.Create(NewProduct);
            return NewProductId;
        }
        public bool UpdateProduct(ProductInfo UpdatedProduct)
        {
            bool updateSuccess = _productRepository.Update(UpdatedProduct);
            return updateSuccess;
        }
        public bool DeleteProduct(long Id)
        {
            bool deleteSuccess = _productRepository.Delete(Id);
            return deleteSuccess;
        }
    }
}
