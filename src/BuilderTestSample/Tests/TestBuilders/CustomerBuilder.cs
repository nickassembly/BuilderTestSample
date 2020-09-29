using BuilderTestSample.Model;
using System;
using System.Collections.Generic;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class CustomerBuilder
   {

      private Customer _internalCustomer = new Customer(0);
      private int _id;

      public CustomerBuilder Address(Address address)
      {
         _internalCustomer.HomeAddress = address;
         return this;
      }

      public CustomerBuilder FirstName(string firstName)
      {
         _internalCustomer.FirstName = firstName;
         return this;
      }

      public CustomerBuilder LastName(string lastName)
      {
         _internalCustomer.LastName = lastName;
         return this;
      }

      public CustomerBuilder Id(int id)
      {
         _id = id;
         return this;
      }

      public Customer Build()
      {
         Customer builtCustomer = new Customer(_id)
         {
            CreditRating = _internalCustomer.CreditRating,
            HomeAddress = _internalCustomer.HomeAddress,
            FirstName = _internalCustomer.FirstName,
            LastName = _internalCustomer.LastName,
            OrderHistory = _internalCustomer.OrderHistory,
            TotalPurchases = _internalCustomer.TotalPurchases
         };

         _internalCustomer = new Customer(0);
         return builtCustomer;
      }

      public CustomerBuilder WithTestValues(int id)
      {
         _internalCustomer = new Customer(id)
         {
            HomeAddress = new Address(),
            FirstName = "Bob",
            LastName = "Smith",
            CreditRating = 650,
            OrderHistory = new List<Order>(),
            TotalPurchases = 13.37m
         };
         return this;
      }
   }
}
