using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Customer : AModel
  {
    public string Name { get; set; }
    
    public Customer()
    {
      Name = "Customer";
    }
  }
}