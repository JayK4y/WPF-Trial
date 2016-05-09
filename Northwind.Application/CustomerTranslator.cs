using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service = Northwind.Application.CustomerService;

namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTranslator<Model.Customer, Service.Customer>
    {
        internal static IEntityTranslator<Model.Customer, Service.Customer> _instance;

        public static IEntityTranslator<Model.Customer, Service.Customer> Instance
        {
            get
            {
                return _instance ?? (_instance = new CustomerTranslator());
            }
            set { _instance = value; }
        }

        public Model.Customer CreateModel(CustomerService.Customer dto)
        {
            return UpdateModel(new Model.Customer(), dto);
        }

        public Model.Customer UpdateModel(Model.Customer model, CustomerService.Customer dto)
        {
            if (model.CustomerID != dto.CustomerID)
            {
                model.CustomerID = dto.CustomerID;
            }

            if (model.CompanyName != dto.CompanyName)
            {
                model.CompanyName = dto.CompanyName;
            }

            if (model.ContactName != dto.ContactName)
            {
                model.ContactName = dto.ContactName;
            }

            if (model.Address != dto.Address)
            {
                model.Address = dto.Address;
            }

            if (model.Region != dto.Region)
            {
                model.Region = dto.Region;
            }

            if (model.Country != dto.Country)
            {
                model.Country = dto.Country;
            }

            if (model.PostalCode != dto.PostalCode)
            {
                model.PostalCode = dto.PostalCode;
            }

            if (model.Phone != dto.Phone)
            {
                model.Phone = dto.Phone;
            }

            return model;
        }

        public CustomerService.Customer CreateDto(Model.Customer model)
        {
            return UpdateDto(new Service.Customer(), model);
        }

        public CustomerService.Customer UpdateDto(CustomerService.Customer dto, Model.Customer model)
        {
            if (dto.CustomerID != model.CustomerID)
            {
                dto.CustomerID = model.CustomerID;
            }

            if (dto.CompanyName != model.CompanyName)
            {
                dto.CompanyName = model.CompanyName;
            }

            if (dto.ContactName != model.ContactName)
            {
                dto.ContactName = model.ContactName;
            }

            if (dto.Address != model.Address)
            {
                dto.Address = model.Address;
            }

            if (dto.Region != model.Region)
            {
                dto.Region = model.Region;
            }

            if (dto.Country != model.Country)
            {
                dto.Country = model.Country;
            }

            if (dto.PostalCode != model.PostalCode)
            {
                dto.PostalCode = model.PostalCode;
            }

            if (dto.Phone != model.Phone)
            {
                dto.Phone = model.Phone;
            }

            return dto;
        }
    }
}
