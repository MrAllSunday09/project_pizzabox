using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;

namespace PizzaBox.Client.Singletons
{
    public class PizzaSingleton
    {
        public static List<APizza> stores = new List<APizza>
        {
            new CustomPizza(),
            new MeatPizza(),
            new VeggiePizza()
        };
    }
}