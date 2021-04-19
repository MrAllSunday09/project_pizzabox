using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizzas
{
  /// <summary>
  /// 
  /// </summary>
  public class VeggiePizza : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    protected override void AddCrust()
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
    protected override void AddSize()
    {
      Size = new Size() { Name = "Small" };
      Size = new Size() { Name = "Medium" };
      Size = new Size() { Name = "Large" };
      Size = new Size() { Name = "X-Large" };
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void AddToppings()
    {
      Toppings = new List<Toppings>()
      {
        new Toppings() { Name = "Parmigiano" },
        new Toppings() { Name = "Margherita" },
        new Toppings() { Name = "Mozzarella" },
        new Toppings() { Name = "Marinara" },
        new Toppings() { Name = "Onion" },
        new Toppings() { Name = "Peppers" },
        new Toppings() { Name = "Mushrooms" },
        new Toppings() { Name = "Spinach" },
        new Toppings() { Name = "SunDriedTomatoes" },
      };
    }
  }
}