using BuilderTestSample.Model;
using System;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class OrderBuilder
   {
      private Order _order = new Order();
      private CustomerBuilder _customerBuilder = new CustomerBuilder();

      public OrderBuilder Id(int id)
      {
         _order.Id = id;
         return this;
      }

      public OrderBuilder OrderAmount(decimal amount)
      {
         _order.TotalAmount = amount;
         return this;
      }

      public OrderBuilder BuildCustomer(Func<CustomerBuilder, CustomerBuilder> customerBuild)
      {
         _customerBuilder = customerBuild(_customerBuilder);
         _order.Customer = _customerBuilder.Build();
            return this;
      }

      public OrderBuilder Customer(Customer customer)
      {
         _order.Customer = customer;
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

         _order.Customer = _customerBuilder.WithTestValues()
            .Build();

         return this;
      }

   }
}
