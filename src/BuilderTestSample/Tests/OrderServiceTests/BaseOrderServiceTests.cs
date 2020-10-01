using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTestSample.Tests.OrderServiceTests
{
   public abstract class BaseOrderServiceTests
   {
      protected readonly OrderService _orderService = new OrderService();
      protected readonly OrderBuilder _orderBuilder = new OrderBuilder();
      protected readonly CustomerBuilder _customerBuilder = new CustomerBuilder();
      protected readonly AddressBuilder _addressBuilder = new AddressBuilder();
   }
}
