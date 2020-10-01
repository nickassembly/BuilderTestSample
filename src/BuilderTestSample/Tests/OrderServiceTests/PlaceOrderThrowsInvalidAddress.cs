using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInvalidAddress : BaseOrderServiceTests
   {
      [Fact]
      public void GivenNoStreet1()
      {
         var address = _addressBuilder.WithTestValues().Street1("").Build();

         Customer customer = _customerBuilder.WithTestValues()
            .Address(new Address()).Build();

         var order = _orderBuilder
                       .WithTestValues()
                       .Customer(customer)
                       .Build();

         Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
      }
   }
}
