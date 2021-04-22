using PizzaBox.Domain.Abstracts;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Size : AComponent
  {
    public ICollection<APizza> Pizza { get; set; }
  }
}