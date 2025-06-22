using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Order.Domain.Entities;

namespace Order.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order.Domain.Entities.Order order, CancellationToken ct = default);
        Task<Order.Domain.Entities.Order?> GetByIdAsync(Guid id, CancellationToken ct = default);

        Task<IEnumerable<Order.Domain.Entities.Order>> GetAllOrdersAsync(CancellationToken cancellationToken);

        IUnitOfWork UnitOfWork { get; }
    }
}
