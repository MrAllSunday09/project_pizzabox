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
    public long SizeEntityId { get; set; }
    public long CrustEntityId { get; set; }
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
      // AddToppings();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddCrust(Crust crust = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddSize(Size size = null);

    /// <summary>
    /// 
    /// </summary>
    public abstract void AddToppings(List<Toppings> toppings);

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
        stringBuilder.Append($"{item.Name}{separator}");
      }

      return $"{Crust.Name} - {Size.Name} - {stringBuilder.ToString().TrimEnd(separator.ToCharArray())}";
    }
  }
}