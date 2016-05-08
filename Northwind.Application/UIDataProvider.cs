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
		private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();

		public IList<Model.Customer> GetCustomers()
		{
            return _customerServiceClient.GetCustomers().Select(c => new Model.Customer().Update(c)).ToList();
		}

		public Model.Customer GetCustomer(string customerID)
		{
            return new Model.Customer().Update(_customerServiceClient.GetCustomer(customerID));
		}
	}
}
