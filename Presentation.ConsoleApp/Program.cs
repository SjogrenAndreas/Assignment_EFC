using Infrastructur.Contexts;
using Infrastructur.Repositories;
using Infrastructur.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Skola\Assignment_EFC\Infrastructur\Data\local_database.mdf;Integrated Security=True"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CompanyRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<PhoneNumberRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CompanyService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<PhoneNumberService>();
    services.AddScoped<RoleService>();

    services.AddScoped<ConsoleUI>();

}).Build();

// Hämta och starta ConsoleUI
var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();
consoleUI.Start();
