using BuilderTestSample.Model;
using System;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class OrderBuilder
   {
      private Order _order = new Order();

      public OrderBuilder Id(int id)
      {
         _order.Id = id;
         return this;
      }

      public Order Build()
      {
         var builtOrder = _order;
         _order = new Order();
         return builtOrder;
      }

      public OrderBuilder WithTestValues()
      {
         _order.TotalAmount = 100m;

         // TODO: replace next lines with a CustomerBuilder you create
         // _order.Customer = new Customer();
         // _order.Customer.HomeAddress = new Address();

         return this;
      }

      public OrderBuilder OrderAmount(decimal amount)
      {
         _order.TotalAmount = amount;
         return this;
      }

      public OrderBuilder Customer(Customer customer)
      {
         _order.Customer = customer;
         return this;
      }


   }
}
