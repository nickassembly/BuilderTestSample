using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInvalidCustomer : BaseOrderServiceTests
   {

      [Fact]
      public void GivenCustomerWithIdZero()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Customer(_customerBuilder.WithTestValues().Id(0).Build())
                         .Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithoutAddress()
      {
         Customer customer = _customerBuilder
            .WithTestValues()
            .Address(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithoutFullName()
      {
         Customer customer = _customerBuilder
            .WithTestValues()
            .FirstName(null).LastName(null)
            .Build();
         var order = _orderBuilder.WithTestValues().Customer(customer).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithNegativeTotal()
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
