using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
   public class OrderService
   {
      public void PlaceOrder(Order order)
      {
         ValidateOrder(order);

         ExpediteOrder(order);

         AddOrderToCustomerHistory(order);
      }

      private void ValidateOrder(Order order)
      {

         if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");

         if (order.TotalAmount <= 0) throw new InvalidOrderException("Amount must be greater than 0");

         if (order.Customer == null) throw new InvalidOrderException("Order requires a customer");

         ValidateCustomer(order.Customer);
      }

      private void ValidateCustomer(Customer customer)
      {
         if (customer.Id <= 0) throw new InvalidCustomerException("Customer must have an ID greater than 0");

         if (customer.HomeAddress == null) throw new InvalidCustomerException("Customer must have an address");

         if (string.IsNullOrEmpty(customer.FirstName)
            || string.IsNullOrEmpty(customer.LastName)) throw new InvalidCustomerException("Customer must have first and last names");

         if (customer.CreditRating <= 200) throw new InsufficientCreditException("Customer must have credit above 200");

         if (customer.TotalPurchases <= 0) throw new InvalidCustomerException("Customer cannot have negative purchase total");

         ValidateAddress(customer.HomeAddress);
      }

      private void ValidateAddress(Address homeAddress)
      {
         if (string.IsNullOrEmpty(homeAddress.Street1)) throw new InvalidAddressException("Street 1 is required");

         if (string.IsNullOrEmpty(homeAddress.City)) throw new InvalidAddressException("City is required");

         if (string.IsNullOrEmpty(homeAddress.State)) throw new InvalidAddressException("State is required");

         if (string.IsNullOrEmpty(homeAddress.PostalCode)) throw new InvalidAddressException("Postal Code is required");

         if (string.IsNullOrEmpty(homeAddress.Country)) throw new InvalidAddressException("Country is required");
      }

      private void ExpediteOrder(Order order)
      {
         // TODO: if customer's total purchases > 5000 and credit rating > 500 set IsExpedited to true
      }

      private void AddOrderToCustomerHistory(Order order)
      {
         // TODO: add the order to the customer

         // TODO: update the customer's total purchases property
      }
   }
}
