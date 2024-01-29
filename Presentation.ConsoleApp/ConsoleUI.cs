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
                    Console.WriteLine($"Customer Found: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
                    // Skriv ut mer information om kunden om det behövs
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
            // Lägg till logik för att lista alla kunder här.
        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Update Customer.");
            // Lägg till logik för att uppdatera en kund här.
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Delete Customer.");
            // Lägg till logik för att ta bort en kund här.
        }
    }
}
