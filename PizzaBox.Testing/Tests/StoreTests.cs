using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class StoreTests
    {
        [Fact]
        public void Test_ChicagoStore()
        {
            //Arrange
            var sut = new ChicagoStore();

            //Act
            var actual = sut.name;


            //Assert
            Assert.True(actual == "ChicagoStore");
            Assert.True(sut.ToString() == actual);
        }

        [Fact]
        public void Test_NewYorkStore()
        {
            //Arrange
            var sut = new NewYorkStore();

            //Assert
            Assert.True(sut.name.Equals("NewYorkStore"));
        }
    }
}