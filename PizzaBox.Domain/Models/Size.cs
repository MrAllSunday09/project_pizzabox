using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Size : AComponent
  {
    public List<APizza> Pizzas { get; set; }
    public long PizzaEntityId { get; set; }
  }
}