using BuilderTestSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTestSample.Tests.TestBuilders
{
   public class AddressBuilder
   {
      private Address _internalAddress = new Address();

      public Address Build()
      {
         var builtAddress = _internalAddress;
         _internalAddress = new Address();
         return builtAddress;
      }

      public AddressBuilder WithTestValues()
      {
         _internalAddress.Street1 = "123 Fake St.";
         _internalAddress.City = "Cleveland";
         _internalAddress.State = "Ohio";
         _internalAddress.PostalCode = "44111";
         _internalAddress.Country = "USA";
         return this;
      }

      public AddressBuilder Street1(string street1)
      {
         _internalAddress.Street1 = street1;
         return this;
      }

      public AddressBuilder City(string city)
      {
         _internalAddress.City = city;
         return this;
      }

      public AddressBuilder State(string state)
      {
         _internalAddress.State = state;
         return this;
      }

      public AddressBuilder PostalCode(string postalCode)
      {
         _internalAddress.PostalCode = postalCode;
         return this;
      }

      public AddressBuilder Country(string country)
      {
         _internalAddress.Country = country;
         return this;
      }
   }
}
