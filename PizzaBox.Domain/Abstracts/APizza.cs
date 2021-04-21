using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Models.Pizza;

namespace PizzaBox.Domain.Abstracts
{
  /// <summary>
  /// 
  /// </summary>
  [XmlInclude(typeof(BuildYourOwn))]
  [XmlInclude(typeof(MeatLovers))]
  [XmlInclude(typeof(VeggiePizza))]

  public abstract class APizza : AModel
  {
    public Crust Crust { get; set; }
    public Size Size { get; set; }
    public List<Toppings> Toppings { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public APizza()
    {
      Factory();
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void Factory()
    {
      AddCrust();
      AddSize();
      AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddCrust();

    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddSize();

    /// <summary>
    /// 
    /// </summary>
    protected abstract void AddToppings();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      var stringBuilder = new StringBuilder();
      var separator = ", ";

      foreach (var item in Toppings)
      {
        stringBuilder.Append($"{item}{separator}");
      }

      return $"{Crust} - {Size} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}