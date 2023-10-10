using System;
using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetList();
        public Product? Get(long Id);
        public long Create(NewProductInfo NewProductInfo);
        public bool Update(ProductInfo ProductInfo);
        public bool Delete(long Id);
    }
    public class ProductRepository : IProductRepository
    {
        private byte[] convertPrice(double price)
        {
            string priceStr = Convert.ToString(price);
            byte[] res = new byte[priceStr.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Convert.ToByte(priceStr[i]);
            }
            return res;
        }
        public IEnumerable<Product> GetList()
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Products.ToList();
        }
        public Product? Get(long Id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Products.Where(c => c.ProductId == Id).FirstOrDefault();
        }
        public long Create(NewProductInfo NewProductInfo)
        {
            using var dbContext = new NorthwindContext();
            long currentMaxId = dbContext.Products.Max(c => c.ProductId);
            currentMaxId += 1;
            Product product = new Product
            {
                ProductId = currentMaxId,
                ProductName = NewProductInfo.ProductName,
                SupplierId = NewProductInfo.SupplierId,
                CategoryId = NewProductInfo.CategoryId,
                Unit = NewProductInfo.Unit,
                Price = convertPrice(NewProductInfo.Price)
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return currentMaxId;
        }
        public bool Update(ProductInfo ProductInfo)
        {
            using var dbContext = new NorthwindContext();
            var product = dbContext.Products.Where(c => c.ProductId.Equals(ProductInfo.ProductId)).FirstOrDefault();
            if (product == null)
            {
                return false;
            }
            product.ProductName = ProductInfo.ProductName;
            product.SupplierId = ProductInfo.SupplierId;
            product.CategoryId = ProductInfo.CategoryId;
            product.Unit = ProductInfo.Unit;
            product.Price = convertPrice(ProductInfo.Price);
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(long Id)
        {
            using var dbContext = new NorthwindContext();
            var product = dbContext.Products.Where(c => c.ProductId.Equals(Id)).FirstOrDefault();
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return true;
        }
    }
}
