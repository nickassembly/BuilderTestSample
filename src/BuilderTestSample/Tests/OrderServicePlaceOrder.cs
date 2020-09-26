using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
   public class OrderServicePlaceOrder
   {
      private readonly OrderService _orderService = new OrderService();
      private readonly OrderBuilder _orderBuilder = new OrderBuilder();
      private readonly CustomerBuilder _customerBuilder = new CustomerBuilder();

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
                         .Customer(_customerBuilder.WithTestValues(0).Build())
                         .Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithoutAddress()
      {
         Customer customer = _customerBuilder
            .WithTestValues(10)
            .Address(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithoutFullName()
      {
         Customer customer = _customerBuilder
            .WithTestValues(10)
            .FirstName(null).LastName(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

   }
}
