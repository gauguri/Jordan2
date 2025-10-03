namespace Jordan2.Models;

public interface IOrderRepository
{
    Order CreateOrder(IEnumerable<OrderLine> lines);
    Order? GetById(int id);
}
