using Microsoft.EntityFrameworkCore;
using oms_core.Context;
using oms_core.Entity;
using oms_core.Interface.Repository;
using oms_core.Views;

namespace oms_core.Repository
{
    public sealed class OrderRepository(AppDbContext appDbContext) : IOrderRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<(int, List<OrderResponse>)> ListOrders(
            PaginatedRequest<ListOrdersRequest> req
        )
        {
            var orders = _appDbContext.Orders.Include(o => o.OrderItems).AsQueryable();

            if (req?.Filters?.OrderStatus is not null)
            {
                orders = orders.Where(o => o.Status == req.Filters.OrderStatus);
            }

            if (req?.Filters?.ProductCode is not null)
            {
                orders = orders.Where(o =>
                    o.OrderItems != null
                    && o.OrderItems.Any(o => o.ProductCode.Contains(req.Filters.ProductCode))
                );
            }

            if (req?.Filters?.ProductName is not null)
            {
                orders = orders.Where(o =>
                    o.OrderItems != null
                    && o.OrderItems.Any(o => o.ProductName.Contains(req.Filters.ProductName))
                );
            }

            int count = await orders.CountAsync();

            if (req != null && req.PageRequest.AllRecords != true)
            {
                int skip = (req.PageRequest.PageNumber - 1) * req.PageRequest.PageSize;
                orders = orders.Skip(skip).Take(req.PageRequest.PageSize);
            }

            var list = await orders
                .Select(o => new OrderResponse
                {
                    OrderID = o.ID,
                    OrderStatus = o.Status,
                    PrimaryIdentifier = o.PrimaryIdentifier,
                    OrderItems = o.OrderItems!.Select(oi => new OrderItemResponse
                        {
                            ProductCode = oi.ProductCode,
                            ProductName = oi.ProductName,
                            Quantity = (int)oi.Quantity,
                        })
                        .ToList(),
                })
                .ToListAsync();

            return (count, list);
        }

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
