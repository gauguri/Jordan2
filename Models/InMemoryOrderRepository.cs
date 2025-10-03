using System.Collections.Concurrent;
using System.Linq;
using System.Threading;

namespace Jordan2.Models;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly ConcurrentDictionary<int, Order> _orders = new();
    private int _lastId;

    public Order CreateOrder(IEnumerable<OrderLine> lines)
    {
        var orderLines = lines.ToList();
        var id = Interlocked.Increment(ref _lastId);
        var order = new Order
        {
            Id = id,
            CreatedAt = DateTime.UtcNow,
            Lines = orderLines,
            Total = orderLines.Sum(line => line.LineTotal)
        };

        _orders[id] = order;
        return order;
    }

    public Order? GetById(int id) => _orders.TryGetValue(id, out var order) ? order : null;
}
