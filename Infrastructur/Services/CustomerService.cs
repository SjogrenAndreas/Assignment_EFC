using Infrastructur.Entities;
using Infrastructur.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructur.Services
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerEntity CreateCustomer(string streetName, string postalCode, string city)
        {
            var customerEntity = _customerRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            customerEntity ??= _customerRepository.Create(new CustomerEntity { StreetName = streetName, PostalCode = postalCode, City = city });

            return customerEntity;
        }

        public CustomerEntity GetCustomer(string streetName, string postalCode, string city)
        {
            var customerEntity = _customerRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return customerEntity;
        }

        public CustomerEntity GetCustomerById(int id)
        {
            var customerEntity = _customerRepository.Get(x => x.Id == id);
            return customerEntity;
        }

        public IEnumerable<CustomerEntity> GetCustomeres()
        {
            var customeres = _customerRepository.GetAll();
            return customeres;
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
        {
            var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            return updatedCustomerEntity;
        }


        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(x => x.Id == id);
        }
    }
}
