using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizza
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatLovers : APizza
  {
    public Size Sizes;
    public Crust Crusts;
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust = null)
    {
      Crust = new Crust();

    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size = null)
    {
      Size = new Size();
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(params Toppings[] toppings)
    {
      Toppings = new List<Toppings>()
      {
        new Toppings() { Name = "Ricotta" },
        new Toppings() { Name = "Bolognese" },
        new Toppings() { Name = "Mozzarella" },
        new Toppings() { Name = "Marinara" },
        new Toppings() { Name = "Pepperoni" },
        new Toppings() { Name = "Bacon" },
        new Toppings() { Name = "Ham" },
        new Toppings() { Name = "Sausage" }
      };
    }
  }
}