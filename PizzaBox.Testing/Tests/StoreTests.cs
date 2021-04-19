using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Stores;
using Xunit;

namespace PizzaBox.Testing.Tests
{
  public class StoreTests
  {
    public static IEnumerable<object[]> values = new List<object[]>()
    {
      new object[] { new Dominos() },
      new object[] { new PizzaHut() }
    };

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_Dominos()
    {
      // arrange
      var sut = new Dominos();

      // act
      var actual = sut.Name;

      // assert
      Assert.True(actual == "Dominos");
      Assert.True(sut.ToString() == actual);
    }

    /// <summary>
    /// 
    /// </summary>
    [Fact]
    public void Test_PizzaHut()
    {
      var sut = new PizzaHut();

      Assert.True(sut.Name.Equals("PizzaHut"));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="store"></param>
    [Theory]
    [MemberData(nameof(values))]
    public void Test_StoreName(AStore store)
    {
      Assert.NotNull(store.name);
      Assert.Equal(store.name, store.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="storeName"></param>
    /// <param name="x"></param>
    [Theory]
    [InlineData("Dominos", 1)]
    [InlineData("PizzaHut", 1)]
    public void Test_StoreNameSimple(string storeName, int x)
    {
      Assert.NotNull(storeName);
    }
  }
}