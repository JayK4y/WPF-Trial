using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Northwind.Model;
using Northwind.Application;
using System.Windows.Data;
using System.Linq;

namespace Northwind.ViewModel.Tests
{
	[TestClass]
	public class MainWindowViewModelTests
	{
		[TestMethod]
		public void Customers_Always_CallsGetCustomers()
		{
			IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
			uiDataProviderMock.Expect(c => c.GetCustomers());

			//Inject stub
			MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);

			IList<Customer> customers = target.Customers;

			uiDataProviderMock.VerifyAllExpectations();
		}

		[ExpectedException(typeof (InvalidOperationException))]
		[TestMethod]
		public void ShowCustomerDetails_SelectedCustomerIDIsNull_ThrowsInvalidOperationException()
		{
			//Arrange
			MainWindowViewModel target = new MainWindowViewModel(null);

			//Act
			target.ShowCustomerDetails();
		}

		[TestMethod]
		public void ShowCustomerDetails_ToolNotFound_AddNewTool()
		{
			//Arrange
			const string expectedCustomerID = "EXPECTEDID";
			MainWindowViewModel target = GetShowCustomerDetailsTarget(new Customer { CustomerID = expectedCustomerID });

			//Act
			target.ShowCustomerDetails();

			//Assert
			CustomerDetailsViewModel actual = target.Tools.Cast<CustomerDetailsViewModel>().FirstOrDefault(viewModel => viewModel.Customer.CustomerID == expectedCustomerID);

			Assert.IsNotNull(actual);
		}

		[TestMethod]
		public void ShowCustomerDetails_Always_ToolIsSetToCurrent()
		{
			//Arrange
			Customer expected = new Customer
			{
				CustomerID = "EXPECTEDID"
			};

			MainWindowViewModel target = GetShowCustomerDetailsTarget(expected);

			//Act
			target.ShowCustomerDetails();

			//Assert
			CustomerDetailsViewModel actual = CollectionViewSource.GetDefaultView(target.Tools).CurrentItem as CustomerDetailsViewModel;

			Assert.AreSame(expected, actual.Customer);
		}

		private static MainWindowViewModel GetShowCustomerDetailsTarget(Customer customer)
		{
			IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();
			MainWindowViewModel target = new MainWindowViewModel(uiDataProviderStub);
			target.SelectedCustomerID = customer.CustomerID;

			uiDataProviderStub.Stub(d => d.GetCustomer(customer.CustomerID)).Return(customer);

			return target;
		}
	}
}
