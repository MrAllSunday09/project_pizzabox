using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Stores;
using PizzaBox.Client.Singletons;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
{
  /// <summary>
  /// 
  /// </summary>
  public class Program
  {
    private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
    private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;

    private readonly PizzaBoxContext _context = new PizzaBoxContext();

    private static readonly OrderRepo _orderRepo = new OrderRepo();

    /// <summary>
    /// 
    /// </summary>
    private static void Main()
    {
      Run();
    }

    /// <summary>
    /// 
    /// </summary>
    private static void Run()
    {
      var order = new Order();

      Console.WriteLine("Welcome to PizzaBox");
      PrintStoreList();

      order.Customer = new Customer();
      order.Store = SelectStore();
      order.Pizza = SelectPizza();

      _orderRepo.Create(order);
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintOrder(APizza pizza)
    {
      Console.WriteLine($"Your order is: {pizza}");
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintPizzaList()
    {
      var index = 0;

      foreach (var item in _pizzaSingleton.Pizzas)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private static void PrintStoreList()
    {
      var index = 0;

      foreach (var item in _storeSingleton.Stores)
      {
        Console.WriteLine($"{++index} - {item}");
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static APizza SelectPizza()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      var pizza = _pizzaSingleton.Pizzas[input - 1];

      PrintOrder(pizza);

      return pizza;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static AStore SelectStore()
    {
      var valid = int.TryParse(Console.ReadLine(), out int input);

      if (!valid)
      {
        return null;
      }

      PrintPizzaList();

      return _storeSingleton.Stores[input - 1];
    }
  }
}