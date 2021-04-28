using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models.Pizza
{
  /// <summary>
  /// 
  /// </summary>
  public class BuildYourOwn : APizza
  {
    /// <summary>
    /// 
    /// </summary>
    public override void AddCrust(Crust crust = null)
    {
      Crust = crust;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddSize(Size size = null)
    {
      Size = size;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void AddToppings(List<Toppings> toppings)
    {
      Toppings = toppings;
    }
  }
}