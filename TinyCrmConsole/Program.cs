using System;
using System.Linq;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace TinyCrmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TinyCrmDbContext())
            {
                //var customer = new Customer();
                //customer.Age = 25;
                //customer.Email = "anastasia.tab@gmail.com";
                //customer.Firstname = "Anastasia";

                //context.Add(customer);
                //context.SaveChanges();
                //---------GET CUSTOMER--------
                //var query = context.Set<Customer>().Where(c => c.Id ==1);

                //var customer = query.SingleOrDefault();
                ICustomerService customerService = new CustomerService(context);
                var results = customerService.SearchCustomer(
                    new SearchCustomerOptions()
                    {
                        Email = "anastasia.tab@gmail.com"
                    });
                Console.WriteLine($"Found {results.Count()} customers");

                ProductService productService = new ProductService(context);
                var newResults = productService.SearchProduct(
                    new SearchProductOptions()
                    {
                        MaxPrice=1000
                    });
                Console.WriteLine($"Found {newResults.Count()} products");

                var results2 = customerService.SearchCustomer(
                    new SearchCustomerOptions()
                    {
                        FirstName = "Anastasia"
                    }
                    );
                Console.WriteLine($"Found {results2.Count()} customers");

                var options = new AddProductOptions()
                {
                   
                    Name = "pc",
                    Price = 1000m,
                    ProductCategory= ProductCategory.Computers
                };
                var newProduct = productService.CreateProduct(options);
                var sum = productService.SumOfStocks();
                Console.WriteLine($"Found {sum} ");

                //var options = new AddCustomerOptions()
                //{
                //    FirstName = "Anastasia",
                //    VatNumber = "w123",
                //    Email = "anastasia@gmail.com"

                //};

                //var newCustomer = customerService.CreateCustomer(options);

            }
        }
           

    }
}

