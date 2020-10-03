using BuilderTestSample.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderThrowsInvalidOrder : BaseOrderServiceTests
   {
      [Fact]
      public void GivenOrderWithExistingId()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Id(123)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenOrderAmountOfZero()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .OrderAmount(0)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }

      [Fact]
      public void GivenOrderWithoutCustomer()
      {
         var order = _orderBuilder
                         .WithTestValues()
                         .Customer(null)
                         .Build();

         Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
      }
   }
}
