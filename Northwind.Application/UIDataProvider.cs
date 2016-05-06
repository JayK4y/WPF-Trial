using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application.CustomerService;

namespace Northwind.Application
{
	public class UIDataProvider : IUIDataProvider
	{
		private IList<Customer> _customers;
		private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();

		public IList<Customer> GetCustomers()
		{
			return _customers ?? (_customers = _customerServiceClient.GetCustomers());
		}

		public Customer GetCustomer(string customerID)
		{
			Customer customer = _customers.First(c => c.CustomerID == customerID);

			return customer.Update(_customerServiceClient.GetCustomer(customer.CustomerID));
		}
	}

	internal static class CustomerExtensions
	{
		public static Customer Update(this Customer customer, Customer existingCustomer)
		{
			customer.ContactName = existingCustomer.ContactName;
			customer.Address = existingCustomer.Address;
			customer.City = existingCustomer.City;
			customer.Region = existingCustomer.Region;
			customer.Country = existingCustomer.Country;
			customer.Phone = existingCustomer.Phone;
			return customer;
		}
	}
}
