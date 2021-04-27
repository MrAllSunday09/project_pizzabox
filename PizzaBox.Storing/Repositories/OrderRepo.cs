using PizzaBox.Domain.Models;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepo
  {
    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    public OrderRepo(PizzaBoxContext context)
    {
      _context = context;
    }
    public void Create(Order order)
    {
      order.Store = _context.Stores.FirstOrDefault(s => s.Name == order.Store.Name);
      _context.Orders.Add(order);
      _context.SaveChanges();
    }
  }
}