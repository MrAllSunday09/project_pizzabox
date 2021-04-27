using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AModel
  {
    public Customer Customers { get; set; }
    public AStore Store { get; set; }
    public long StoreEntityId { get; set; }
    public APizza Pizza { get; set; }
    public decimal TotalCost
    {
      get
      {
        return Pizza.Crust.Price + Pizza.Size.Price + Pizza.Toppings.Sum(t => t.Price);
      }
    }
    public void Save()
    {

    }
  }
}