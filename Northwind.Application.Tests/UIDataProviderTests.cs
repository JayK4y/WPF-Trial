using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Northwind.Application.CustomerService;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application.Tests
{
    [TestClass]
    public class UIDataProviderTests
    {
        [TestMethod()]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            //Arrange
            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();
            UIDataProvider target = new UIDataProvider(customerServiceMock);

            var customerDtos = new Service.Customer[] { new Service.Customer() };
            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);

            //Act
            target.GetCustomers();

            //Assert
            customerServiceMock.AssertWasCalled(c => c.GetCustomers());
        }

        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_DtoPassedToTranslator()
        {
            //Arrange
            ICustomerService customerServiceStub = MockRepository.GenerateMock<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceStub);
            var expected = new Service.Customer();
            var customerDtos = new Service.Customer[] { expected };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);

            //Act
            target.GetCustomers();

            //Assert
            CustomerTranslator.Instance.AssertWasCalled(c => c.CreateModel(expected));
        }

        [TestMethod()]
        public void GetCustomers_ServiceReturnsDto_ModelReturnedFromTranslator()
        {
            //Arrange
            ICustomerService customerServiceStub = MockRepository.GenerateMock<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer, Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceStub);
            var dto = new Service.Customer();
            var expected = new Model.Customer();
            var customerDtos = new Service.Customer[] { dto };
            customerServiceStub.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(expected);

            //Act
            var actual = target.GetCustomers();

            //Assert
            Assert.AreSame(expected, actual[0]);
        }

        [TestMethod()]
        public void GetCustomer_Always_CallsGetCustomer()
        {
            //Arrange
            const string expectedID = "expectedID";
            ICustomerService customerServiceMock = MockRepository.GenerateMock<ICustomerService>();
            CustomerTranslator.Instance = MockRepository.GenerateStub<IEntityTranslator<Model.Customer,Service.Customer>>();
            UIDataProvider target = new UIDataProvider(customerServiceMock);
            var dto = new Service.Customer { CustomerID = expectedID };
            var model = new Model.Customer { CustomerID = expectedID };
            var customerDtos = new Service.Customer[] { dto };
            customerServiceMock.Stub(c => c.GetCustomers()).Return(customerDtos);
            CustomerTranslator.Instance.Stub(c => c.CreateModel(dto)).Return(model);
            target.GetCustomers();

            //Act
            target.GetCustomer(expectedID);

            //Assert
            customerServiceMock.AssertWasCalled(c => c.GetCustomer(expectedID));
        }
    }
}
