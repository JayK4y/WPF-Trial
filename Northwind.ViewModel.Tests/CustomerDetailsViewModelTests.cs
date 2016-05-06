using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Northwind.Application;
using Northwind.Application.CustomerService;

namespace Northwind.ViewModel.Tests
{
	[TestClass]
	public class CustomerDetailsViewModelTests
	{
		[TestMethod]
		public void Customer_Always_CallsGetCustomer()
		{
			//Arrange
			IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
			const string expectedID = "EXPECTEDID";
			uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(new Customer());

			//Act
			CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID);

			//Assert
			uiDataProviderMock.VerifyAllExpectations();
		}

		[TestMethod]
		public void Customer_Always_ReturnsCustomerFromGetCustomer()
		{
			//Arrange
			IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
			const string expectedID = "EXPECTEDID";
			Customer expectedCustomer = new Customer
			{
				CustomerID = expectedID
			};

			uiDataProviderMock.Stub(c => c.GetCustomer(expectedID)).Return(expectedCustomer);

			//Act
			CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID);

			//Assert
			Assert.AreSame(expectedCustomer, target.Customer);
		}

		[TestMethod]
		public void DisplayName_Always_ReturnsCompanyName()
		{
			//Arrange
			IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
			const string expectedID = "EXPECTEDID";
			const string expectedCompanyName = "EXPECTEDNAME";
			Customer expectedCustomer = new Customer
			{
				CustomerID = expectedID,
				CompanyName = expectedCompanyName
			};

			uiDataProviderMock.Stub(c => c.GetCustomer(expectedID)).Return(expectedCustomer);

			//Act
			CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID);

			// Assert
			Assert.AreEqual(expectedCompanyName, target.DisplayName);
		}
	}
}
