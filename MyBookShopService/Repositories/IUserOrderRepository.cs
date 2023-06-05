using MyBookShopService.Models;

namespace MyBookShopService.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}