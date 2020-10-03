using BuilderTestSample.Model;
using System;
using System.Collections.Generic;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class CustomerBuilder
   {
      private AddressBuilder _addressBuilder = new AddressBuilder();
      private Customer _internalCustomer = new Customer(0);
      private int _id;

      public CustomerBuilder BuildAddress(Func<AddressBuilder, AddressBuilder> addressBuild)
      {
         _addressBuilder = addressBuild(_addressBuilder);
         _internalCustomer.HomeAddress = _addressBuilder.Build();
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

      public CustomerBuilder TotalPurchases(decimal totalPurchases)
      {
         _internalCustomer.TotalPurchases = totalPurchases;
         return this;
      }

      public CustomerBuilder Id(int id)
      {
         _id = id;
         return this;
      }

      public Customer Build()
      {
         Customer builtCustomer = _internalCustomer?.WithId(_id);
         _internalCustomer = new Customer(0);
         return builtCustomer;
      }

      public CustomerBuilder WithTestValues()
      {
         _id = 100;
         _internalCustomer = new Customer(100)
         {
            HomeAddress = _addressBuilder.WithTestValues().Build(),
            FirstName = "Bob",
            LastName = "Smith",
            CreditRating = 650,
            OrderHistory = new List<Order>(),
            TotalPurchases = 13.37m
         };
         return this;
      }

      public CustomerBuilder Address(Address address)
      {
         _internalCustomer.HomeAddress = address;
         return this;
      }

      public CustomerBuilder CreditRating(int creditRating)
      {
         _internalCustomer.CreditRating = creditRating;
         return this;
      }
   }
}
