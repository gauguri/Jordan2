namespace Jordan2.Server.Models;

public interface IOrderRepository
{
    Order CreateOrder(IEnumerable<OrderLine> lines);
    Order? GetById(int id);
}
