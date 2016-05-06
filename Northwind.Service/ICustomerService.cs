using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Northwind.Service
{
	[ServiceContract]
	public interface ICustomerService
	{
		[OperationContract]
		IList<Customer> GetCustomers();
		[OperationContract]
		Customer GetCustomer(string customerID);
	}
}
