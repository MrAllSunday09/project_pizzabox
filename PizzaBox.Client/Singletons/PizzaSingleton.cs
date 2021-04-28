using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Pizza;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();
    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";
    private readonly PizzaBoxContext _context;

    public List<APizza> Pizzas { get; set; }
    public static PizzaSingleton Instance(PizzaBoxContext context)
    {
      if (_instance == null)
      {
        _instance = new PizzaSingleton(context);
      }

      return _instance;

    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton(PizzaBoxContext context)
    {

      _context = context;
      Pizzas = _context.Pizzas.ToList();
      foreach (var pizza in Pizzas)
      {
        IQueryable<Size> sizes = _context.Sizes;
        var size = sizes.Where(s => s.EntityId == pizza.SizeEntityId).ToList();
        IQueryable<Crust> crusts = _context.Crusts;
        var crust = crusts.Where(s => s.EntityId == pizza.SizeEntityId).ToList();
        IQueryable<Toppings> toppings = _context.Toppings;
        var topping = toppings.Where(s => s.EntityId == pizza.SizeEntityId).ToList();
        foreach (var i in size)
        {
          pizza.Size = i;
        }
        foreach (var i in crust)
        {
          pizza.Crust = i;
        }
        pizza.AddToppings(topping);
      }
    }
  }
}
// public Size GetSize(APizza ap)
// {
//   var size = from r in _context.Sizes
//              join ro in _context.Pizzas on r.PizzaEntityId equals ro.EntityId
//              where ro.EntityId == ap.EntityId
//              select r;

//   return size;
// }
// public Size GetCrust(Crust crust)
// {
//   var crust = from c in _context.Crusts
//               join co in _context.Pizzas on c.PizzaEntityId equals co.EntityId
//               where co.EntityId == p.EntityId
//               select c;

//   return crust;
// }
// public Size GetToppings(APizza p)
// {
//   var size = from r in _context.Sizes
//              join ro in _context.Pizzas on r.PizzaEntityId equals ro.EntityId
//              where ro.EntityId == p.EntityId
//              select r;

//   return size;
// }