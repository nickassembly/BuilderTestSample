using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class OrderServicePlaceOrder : BaseOrderServiceTests
   {

      [Fact]
      public void ThrowsException_GivenCustomerWithIdZero()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Customer(_customerBuilder.WithTestValues().Id(0).Build())
                         .Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithoutAddress()
      {
         Customer customer = _customerBuilder
            .WithTestValues()
            .Address(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithoutFullName()
      {
         Customer customer = _customerBuilder
            .WithTestValues()
            .FirstName(null).LastName(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void ThrowsException_GivenCustomerWithNegativeTotal()
      {
         Customer customer = _customerBuilder
            .WithTestValues()
            .TotalPurchases(-100m)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

   }
}
