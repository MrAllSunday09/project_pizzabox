using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Customer : AComponent
  {
    public int Id { get; set; }
    
    public Customer()
    {
      Name = "Customer";
    }
  }
}