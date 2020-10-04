using Xunit;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public class PlaceOrderShould : BaseOrderServiceTests
   {
      [Fact]
      public void SetExpedited_GivenHighCreditAndHighTotalPurchase()
      {
         var order = _orderBuilder
                     .WithTestValues()
                     .OrderAmount(5000.01m)
                     .BuildCustomer(cb => cb.WithTestValues().CreditRating(501))
                     .Build();

         _orderService.PlaceOrder(order);

         Assert.True(order.IsExpedited);
      }

      [Theory]
      [InlineData(500)]
      [InlineData(300)]
      public void NotSetExpedited_GivenLowCredit(int rating)
      {
         var order = _orderBuilder
                      .WithTestValues()
                      .OrderAmount(5000.01m)
                      .BuildCustomer(cb => cb.WithTestValues().CreditRating(rating))
                      .Build();

         _orderService.PlaceOrder(order);

         Assert.False(order.IsExpedited);
      }

      [Theory]
      [InlineData(5000)]
      [InlineData(500)]
      public void NotSetExpedited_GivenLowTotalPurchase(decimal purchase)
      {
         var order = _orderBuilder
                      .WithTestValues()
                      .OrderAmount(purchase)
                      .BuildCustomer(cb => cb.WithTestValues().CreditRating(501))
                      .Build();

         _orderService.PlaceOrder(order);

         Assert.False(order.IsExpedited);
      }

      [Fact]
      public void AddOrderToOrderHistory()
      {
         var order = _orderBuilder
                      .WithTestValues()
                      .Build();

         _orderService.PlaceOrder(order);

         Assert.Contains(order, order.Customer.OrderHistory);

      }

      [Fact]
      public void AddOrderTotalToCustomerPurchases()
      {
         var orderAmount = 100m;
         var totalPurchases = 400m;
         var order = _orderBuilder
                         .WithTestValues()
                         .OrderAmount(orderAmount)
                         .BuildCustomer(cb => cb.WithTestValues().TotalPurchases(totalPurchases))
                         .Build();

         _orderService.PlaceOrder(order);

         Assert.Equal(orderAmount + totalPurchases, order.Customer.TotalPurchases);

      }
   }
}
