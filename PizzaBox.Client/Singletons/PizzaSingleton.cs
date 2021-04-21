using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;
using System.Linq;

namespace PizzaBox.Client.Singletons
{
  /// <summary>
  /// 
  /// </summary>
  public class PizzaSingleton
  {
    private readonly FileRepository _fileRepository = new FileRepository();

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    private static PizzaSingleton _instance;
    private const string _path = @"data/pizzas.xml";

    public List<APizza> Pizza { get; set; }
    public static PizzaSingleton Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new PizzaSingleton();
        }

        return _instance;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private PizzaSingleton()
    {
      _context.Pizzas.AddRange(_fileRepository.ReadFromFile<List<APizza>>(_path));
      _context.SaveChanges();

      Pizza = _context.Pizzas.ToList();
    }
  }
}