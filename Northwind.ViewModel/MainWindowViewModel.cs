using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Northwind.Model;
using Northwind.Application;


namespace Northwind.ViewModel
{
	public class MainWindowViewModel
	{
		private readonly IUIDataProvider _dataProvider;

		private IList<Customer> _customers;

		public string SelectedCustomerID { get; set; }
		public ObservableCollection<ToolViewModel> Tools { get; set; }
		public string Name { get { return "Northwind"; } }
		public string ControlPanelName { get { return "Control Panel"; } }

		public IList<Customer> Customers
		{
			get
			{
				if (_customers == null)
				{
					GetCustomers();
				}
				return _customers;
			}
		}

		public MainWindowViewModel(IUIDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
			Tools = new ObservableCollection<ToolViewModel>();
		}

		public void ShowCustomerDetails()
		{
			if (string.IsNullOrEmpty(SelectedCustomerID))
			{
				throw new InvalidOperationException("SelectedCustomerID can't be null");
			}

			CustomerDetailsViewModel customerDetailsViewModel = GetCustomerDetailsTool(SelectedCustomerID);

			if (customerDetailsViewModel == null)
			{
				customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
				Tools.Add(customerDetailsViewModel);
			}

			SetCurrentTool(customerDetailsViewModel);
		}

		private CustomerDetailsViewModel GetCustomerDetailsTool(string customerID)
		{
			return Tools.OfType<CustomerDetailsViewModel>().FirstOrDefault(c => c.Customer.CustomerID == customerID);
		}

		private void SetCurrentTool(ToolViewModel currentTool)
		{
			ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);

			if (collectionView != null)
			{
				if (collectionView.MoveCurrentTo(currentTool) != true)
				{
					throw new InvalidOperationException("Could not find the current tool.");
				}
			}

		}

		private void GetCustomers()
		{
			_customers = _dataProvider.GetCustomers();	
		}
	}
}
