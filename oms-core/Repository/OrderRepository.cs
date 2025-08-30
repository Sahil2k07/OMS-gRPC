using oms_core.Context;
using oms_core.Entity;
using oms_core.Interface.Repository;

namespace oms_core.Repository
{
    public sealed class OrderRepository(AppDbContext appDbContext) : IOrderRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task SaveOrder(Order order)
        {
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task SaveOrderItems(List<OrderItem> orderItems)
        {
            await _appDbContext.OrderItems.AddRangeAsync(orderItems);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
