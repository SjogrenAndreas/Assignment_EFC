using Infrastructur.Entities;
using Infrastructur.Repositories;

namespace Infrastructur.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressService _addressService;
        private readonly RoleService _roleService;
        private readonly PhoneNumberService _phoneNumberService;
        private readonly CompanyService _companyService;


        public CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService, PhoneNumberService phoneNumberService, CompanyService companyService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
            _roleService = roleService;
            _phoneNumberService = phoneNumberService;
            _companyService = companyService;
        }



        public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city, string workPhone, string mobilePhone, string companyName)
        {
            var roleEntity = _roleService.CreateRole(roleName);
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);
            var phoneNumberEntity = _phoneNumberService.CreatePhoneNumber(workPhone, mobilePhone);
            var companyEntity = _companyService.CreateCompany(companyName);

            var customerEntity = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleEntity.Id,
                AddressId = addressEntity.Id,
                PhoneNumberId = phoneNumberEntity.Id,
                CompanyId = companyEntity.Id,
            };

            customerEntity = _customerRepository.Create(customerEntity);

            return customerEntity;
        }




        public CustomerEntity GetCustomerByEmail(string email)
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            return customerEntity;
        }


        public CustomerEntity GetCustomerById(int id)
        {
            var customerEntity = _customerRepository.Get(x => x.Id == id);
            return customerEntity;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
        {
            var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            return updatedCustomerEntity;
        }


        public bool DeleteCustomer(int id)
        {
            try
            {
                _customerRepository.Delete(x => x.Id == id);
                return true; // Antag att raderingen lyckades
            }
            catch
            {
                return false; // Raderingen misslyckades
            }
        }
    }
}
