using BuilderTestSample.Exceptions;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInsufficientCredit : BaseOrderServiceTests
   {
      [Fact]
      public void GivenCustomerWithLowCreditRating()
      {
         var order = _orderBuilder
                      .WithTestValues()
                      .BuildCustomer(cb => cb.WithTestValues().CreditRating(200))
                      .Build();

         Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
      }
   }
}
