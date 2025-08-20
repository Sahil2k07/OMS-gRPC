using oms_core.Context;
using oms_core.Interface.Repository;

namespace oms_core.Repository
{
    public sealed class OrderRepository(AppDbContext appDbContext) : IOrderRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
    }
}
