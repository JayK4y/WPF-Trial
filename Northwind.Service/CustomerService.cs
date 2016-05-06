using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;

namespace Northwind.Service
{
	public class CustomerService : ICustomerService
	{
		private readonly NorthwindEntities db = new NorthwindEntities();

		public IList<Northwind.Service.Customer> GetCustomers()
		{
			return db.Customers.Select(c => new Northwind.Service.Customer
			{
				CustomerID = c.CustomerID,
				CompanyName = c.CompanyName
			}).ToList();
		}

		public Northwind.Service.Customer GetCustomer(string customerID)
		{
			Northwind.Data.Customer customer = db.Customers.Single(c => c.CustomerID == customerID);

			return new Northwind.Service.Customer
			{
				CustomerID = customer.CustomerID,
				CompanyName = customer.CompanyName,
				ContactName = customer.ContactName,
				Address = customer.Address,
				City = customer.City,
				Country = customer.Country,
				Region = customer.Region,
				PostalCode = customer.PostalCode,
				Phone = customer.Phone
			};
		}
	}
}
