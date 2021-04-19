using System.Collections.Generic;
using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
  public class Program
  {
    private static void Main()
    {
      List<string> storeList = new List<string> { "Store 1", "Store 2" };
      var stores = new List<AStore> { new Dominos(), new PizzaHut() };

      for (var x = 0; x < stores.Count; x += 1)
      {
        Console.WriteLine($" {x} {stores[x]}");
      }

      Console.WriteLine("Choose a Store!!!");
      string input = Console.ReadLine();
      int entry = int.Parse(input);

      Console.WriteLine(stores[entry]);
    }
  }
}