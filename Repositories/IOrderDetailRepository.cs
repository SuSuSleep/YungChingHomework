using YungChingHomework.DBModels;
using YungChingHomework.DTOs.Infos;

namespace YungChingHomework.Repository
{
    public interface IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetList();
        public OrderDetail Get(long Id);
        public long Create(NewOrderDetailInfo NewOrderDetailInfo);
        public bool Update(OrderDetailInfo OrderDetailInfo);
        public bool Delete(long Id);
    }
}
