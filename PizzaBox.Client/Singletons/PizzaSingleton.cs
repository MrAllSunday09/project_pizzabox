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
      // _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      // var cp = new BuildYourOwn();
      // cp.Sizes = _context.Sizes.FirstOrDefault(s => s.Name == "Medium");

      // _context.Add(cp);
      // _context.SaveChanges();

      // Pizzas = _context.Pizzas.ToList();

      // var cp9 = new MeatLovers();
      // cp9.Sizes = _context.Sizes.FirstOrDefault(s => s.Name == "Medium");

      // _context.Add(cp9);
      // _context.SaveChanges();

      // Pizzas = _context.Pizzas.ToList();

      // var cp0 = new VeggiePizza();
      // cp0.Sizes = _context.Sizes.FirstOrDefault(s => s.Name == "Medium");

      // _context.Add(cp0);
      // _context.SaveChanges();

      _context = context;
      Pizzas = _context.Pizzas.ToList();
    }
  }
}