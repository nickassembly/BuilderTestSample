using BuilderTestSample.Exceptions;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
   public class OrderServicePlaceOrder
   {
      private readonly OrderService _orderService = new OrderService();
      private readonly OrderBuilder _orderBuilder = new OrderBuilder();

      [Fact]
      public void ThrowsException_GivenOrderWithExistingId()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Id(123)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenOrderAmountOfZero()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .OrderAmount(0)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenOrderWithoutCustomer()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Customer(null)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithIdZero()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Customer(new Model.Customer(0))
                         .Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

   }
}
