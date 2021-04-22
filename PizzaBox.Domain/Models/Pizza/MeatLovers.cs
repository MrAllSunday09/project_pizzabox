using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizza
{
  /// <summary>
  /// 
  /// </summary>
  public class MeatLovers : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust = null)
    {
      Crust = new Crust() { Name = "Stuffed" };
      Crust = new Crust() { Name = "Neapolitan" };
      Crust = new Crust() { Name = "Original" };
      Crust = new Crust() { Name = "Thin" };
      Crust = new Crust() { Name = "Brooklyn" };

    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size = null)
    {
      Size = new Size() { Name = "Small" };
      Size = new Size() { Name = "Medium" };
      Size = new Size() { Name = "Large" };
      Size = new Size() { Name = "X-Large" };
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