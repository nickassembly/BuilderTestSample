using BuilderTestSample.Model;
using System;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class CustomerBuilder
   {
      private Customer _customer;

      public CustomerBuilder Address(Address address)
      {
         _customer.HomeAddress = address;
         return this;
      }

      public CustomerBuilder FirstName(string firstName)
      {
         _customer.FirstName = firstName;
         return this;
      }

      public CustomerBuilder LastName(string lastName)
      {
         _customer.LastName = lastName;
         return this;
      }

      public Customer Build()
      {
         Customer builtCustomer = _customer;
         _customer = new Customer(0);
         return builtCustomer;
      }

      public CustomerBuilder WithTestValues(int id)
      {
         _customer = new Customer(id)
         {
            HomeAddress = new Address(),
            FirstName = "Bob",
            LastName = "Smith"
         };
         return this;
      }
   }
}
