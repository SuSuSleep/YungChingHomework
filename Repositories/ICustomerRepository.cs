using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repository
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetList();
        public Customer Get(int Id);
        public long Create(NewCustomerInfo NewCustomer);
        public bool Update(CustomerInfo Customer);
        public bool Delete(long Id);
    }
}
