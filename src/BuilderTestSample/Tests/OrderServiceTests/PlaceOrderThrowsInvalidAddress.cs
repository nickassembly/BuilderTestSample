using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInvalidAddress : BaseOrderServiceTests
   {
      [Fact]
      public void GivenNoCity()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().City(null)))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenNoStreet1()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().Street1("")))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenNoState()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().State(null)))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenNoPostalCode()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().PostalCode(null)))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenNoCountry()
      {
         var order = _orderBuilder
                       .WithTestValues()
                       .BuildCustomer(cb => cb.WithTestValues().BuildAddress(ab => ab.WithTestValues().Country(null)))
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }
   }
}
