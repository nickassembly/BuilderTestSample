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
                         .BuildCustomer(cb => cb.WithTestValues().Id(0))
                         .Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithoutAddress()
      {
         var order = _orderBuilder.WithTestValues().BuildCustomer(cb => cb.WithTestValues().Address(null)).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithoutFullName()
      {
         var order = _orderBuilder.WithTestValues().BuildCustomer(cb => cb.WithTestValues()
             .FirstName(null).LastName(null)).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenCustomerWithNegativeTotal()
      {
         var order = _orderBuilder.WithTestValues().BuildCustomer(cb => cb.WithTestValues().TotalPurchases(-100m)).Build();

         Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
      }

   }
}
