using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetList();
        public Order Get(long Id);
        public long Create(NewOrderInfo NewCustomer);
        public bool Update(OrderInfo Customer);
        public bool Delete(long Id);
    }
}
