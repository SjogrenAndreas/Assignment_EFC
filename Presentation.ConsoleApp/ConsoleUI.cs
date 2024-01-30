using Infrastructur.Entities;
using Infrastructur.Services;
using System;

namespace Presentation.ConsoleApp
{
    public class ConsoleUI
    {
        private readonly CustomerService _customerService;
        public ConsoleUI(CustomerService customerService)
        {
            _customerService = customerService;
        }
        // Huvudmetoden för att starta konsolapplikationen
        public void Start()
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Customer");
                Console.WriteLine("2. Product");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option (1-3): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CustomerMenu();
                        break;
                    case "2":
                        // Logic for 'Product' menu can be added here in the future.
                        Console.Clear();
                        Console.WriteLine("Product menu is not implemented yet.");
                        Console.ReadKey();
                        break;
                    case "3":
                        exitProgram = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice, please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void CustomerMenu()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Customer Menu");
                Console.WriteLine("1. Add New Customer");
                Console.WriteLine("2. Search Customer");
                Console.WriteLine("3. List All Customers");
                Console.WriteLine("4. Update Customer");
                Console.WriteLine("5. Delete Customer");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Choose an option (1-6): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewCustomer();
                        break;
                    case "2":
                        SearchCustomer();
                        break;
                    case "3":
                        ListAllCustomers();
                        break;
                    case "4":
                        UpdateCustomer();
                        break;
                    case "5":
                        DeleteCustomer();
                        break;
                    case "6":
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        private void AddNewCustomer()
        {
            Console.WriteLine("Add New Customer.");

            // Fråga användaren om kundens uppgifter
            Console.Write("First Name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Role Name: ");
            string roleName = Console.ReadLine()!;

            Console.Write("Street Name: ");
            string streetName = Console.ReadLine()!;

            Console.Write("Postal Code: ");
            string postalCode = Console.ReadLine()!;

            Console.Write("City: ");
            string city = Console.ReadLine()!;

            Console.Write("Work Phone: ");
            string workPhone = Console.ReadLine()!;

            Console.Write("Mobile Phone: ");
            string mobilePhone = Console.ReadLine()!;

            Console.Write("Company Name: ");
            string companyName = Console.ReadLine()!;

            try
            {
                // Anropa CustomerService för att skapa kunden
                var customer = _customerService.CreateCustomer(firstName, lastName, email, roleName, streetName, postalCode, city, workPhone, mobilePhone, companyName);
                Console.WriteLine("Customer created successfully!");
            }
            catch (Exception ex)
            {
                // Hantera eventuella fel
                Console.WriteLine($"Error creating customer: {ex.Message}");
            }
        }

        private void SearchCustomer()
        {
            Console.WriteLine("Search Customer.");
            Console.WriteLine("Choose search method:");
            Console.WriteLine("1. By Email");
            Console.WriteLine("2. By ID");
            Console.Write("Enter choice (1 or 2): ");

            var choice = Console.ReadLine();

            try
            {
                CustomerEntity customer = null;

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Email: ");
                        var email = Console.ReadLine();
                        customer = _customerService.GetCustomerByEmail(email);
                        break;
                    case "2":
                        Console.Write("Enter ID: ");
                        var idSuccess = int.TryParse(Console.ReadLine(), out int id);
                        if (!idSuccess)
                        {
                            Console.WriteLine("Invalid ID format.");
                            return;
                        }
                        customer = _customerService.GetCustomerById(id);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                if (customer != null)
                {
                    Console.WriteLine("Customer Found:");
                    Console.WriteLine($"First Name: {customer.FirstName}");
                    Console.WriteLine($"Last Name: {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Role Name: {customer.Role.Role}"); 
                    Console.WriteLine($"Street Name: {customer.Address.StreetName}"); 
                    Console.WriteLine($"Postal Code: {customer.Address.PostalCode}");
                    Console.WriteLine($"City: {customer.Address.City}");
                    Console.WriteLine($"Work Phone: {customer.PhoneNumber.WorkPhone}"); 
                    Console.WriteLine($"Mobile Phone: {customer.PhoneNumber.MobilePhone}");
                    Console.WriteLine($"Company Name: {customer.Company.CompanyName}"); 
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }


        private void ListAllCustomers()
        {
            Console.WriteLine("List All Customers.");

            try
            {
                var customers = _customerService.GetCustomers();

                foreach (var customer in customers)
                {
                    Console.WriteLine($"First Name: {customer.FirstName}");
                    Console.WriteLine($"Last Name: {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine("-------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Update Customer.");
            Console.WriteLine("Choose search method:");
            Console.WriteLine("1. By Email");
            Console.WriteLine("2. By ID");
            Console.Write("Enter choice (1 or 2): ");

            var choice = Console.ReadLine();
            CustomerEntity customer = null;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Email: ");
                        var email = Console.ReadLine();
                        customer = _customerService.GetCustomerByEmail(email);
                        break;
                    case "2":
                        Console.Write("Enter ID: ");
                        var idSuccess = int.TryParse(Console.ReadLine(), out int id);
                        if (!idSuccess)
                        {
                            Console.WriteLine("Invalid ID format.");
                            return;
                        }
                        customer = _customerService.GetCustomerById(id);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }

                if (customer != null)
                {
                    // Visa befintlig kundinformation
                    Console.WriteLine("Customer Found:");
                    Console.WriteLine($"First Name: {customer.FirstName}");
                    Console.WriteLine($"Last Name: {customer.LastName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Role Name: {customer.Role.Role}");
                    Console.WriteLine($"Street Name: {customer.Address.StreetName}");
                    Console.WriteLine($"Postal Code: {customer.Address.PostalCode}");
                    Console.WriteLine($"City: {customer.Address.City}");
                    Console.WriteLine($"Work Phone: {customer.PhoneNumber.WorkPhone}");
                    Console.WriteLine($"Mobile Phone: {customer.PhoneNumber.MobilePhone}");
                    Console.WriteLine($"Company Name: {customer.Company.CompanyName}");

                    // Fråga användaren om uppdateringar
                    Console.WriteLine("Enter new values (leave blank to keep current):");

                    Console.Write("New First Name: ");
                    var newFirstName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newFirstName)) customer.FirstName = newFirstName;

                    Console.Write("New Last Name: ");
                    var newLastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newLastName)) customer.LastName = newLastName;

                    Console.Write("New Email: ");
                    var newEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newEmail)) customer.Email = newEmail;

                    // Exempel på uppdatering av Address
                    Console.Write("New Street Name: ");
                    var newStreetName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newStreetName)) customer.Address.StreetName = newStreetName;

                    // Liknande logik för att uppdatera PostalCode, City, PhoneNumber, Company, etc.

                    // Antag att det finns en metod för att spara den uppdaterade Address:
                    

                    // Upprepa liknande process för PhoneNumber, Company, etc.

                    // Spara de uppdaterade kunduppgifterna
                    _customerService.UpdateCustomer(customer);
                    Console.WriteLine("Customer updated successfully!");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Delete Customer.");
            // Lägg till logik för att ta bort en kund här.
        }
    }
}
