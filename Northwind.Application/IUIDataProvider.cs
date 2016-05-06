using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Application.CustomerService;

namespace Northwind.Application
{
	public interface IUIDataProvider
	{
		IList<Customer> GetCustomers();

		Customer GetCustomer(string customerID);
	}
}
