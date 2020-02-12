using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private  TinyCrmDbContext dbContext = new TinyCrmDbContext();
        public CustomerService(TinyCrmDbContext context)
        {
            context = dbContext;
            
        }
        private List<Customer> CustomersList = new List<Customer>();
        public List<Customer> SearchCustomer(SearchCustomerOptions searchCustomerOptions)
        {
            if(searchCustomerOptions == null)
            {
                return null;
            }
            
                var query = dbContext.Set<Customer>().AsQueryable();

                if (searchCustomerOptions.Id != null)
                {
                    query = query.
                    Where(c => c.Id == searchCustomerOptions.Id);
                }
                if (searchCustomerOptions.VatBumber != null)
                {
                    query = query.
                    Where(c => c.VatNumber == searchCustomerOptions.VatBumber);
                }
                if (searchCustomerOptions.Email != null)
                {
                    query = query.
                    Where(c => c.Email == searchCustomerOptions.Email);
                }

                 if (searchCustomerOptions.FirstName != null &&
                    searchCustomerOptions.FirstName.Contains("a"))
                {
                    query = query.
                    Where(c => c.Firstname ==
                    searchCustomerOptions.FirstName);
                }
                if (searchCustomerOptions.LastName != null &&
                    searchCustomerOptions.LastName.Contains("s"))
                {
                    query = query.
                    Where(c => c.Lastname ==
                    searchCustomerOptions.LastName);
                }
                List<Customer> customers = query.ToList();
                return customers;

            
        }

        public List<Customer> SearchCustomer1
            (SearchCustomerOptions searchCustomerOptions)
        {
            if (searchCustomerOptions == null)
            {
                return null;
            }
            
                var query = dbContext.Set<Customer>().AsQueryable();

                var customer = GetCustomerById(searchCustomerOptions.Id);
                if (customer != null)
                {
                    query = query.
                    Where(c => c.Id == searchCustomerOptions.Id);
                }
                if (searchCustomerOptions.VatBumber != null)
                {
                    query = query.
                    Where(c => c.VatNumber == searchCustomerOptions.VatBumber);
                }
                if (searchCustomerOptions.Email != null)
                {
                    query = query.
                    Where(c => c.Email == searchCustomerOptions.Email);
                }
                List<Customer> customers = query.ToList();
                return customers;

            
        }



        //public List<Customer> SearchCustomerByName(
        //    SearchCustomerOptions searchCustomerOptions)
        //{
        //    if (searchCustomerOptions == null)
        //    {
        //        return null;
        //    }
            
        //        var query = dbContext.Set<Customer>().AsQueryable();

        //        if (searchCustomerOptions.FirstName != null &&
        //            searchCustomerOptions.FirstName.Contains("a"))
        //        {
        //            query = query.
        //            Where(c => c.Firstname ==
        //            searchCustomerOptions.FirstName);
        //        }
        //        if (searchCustomerOptions.LastName != null &&
        //            searchCustomerOptions.LastName.Contains("s"))
        //        {
        //            query = query.
        //            Where(c => c.Lastname ==
        //            searchCustomerOptions.LastName);
        //        }

        //        List<Customer> customers = query.ToList();
        //        return customers;

            
        //}

        public Customer CreateCustomer(AddCustomerOptions options)
        {
            
            if (options == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(options.Email)
                || string.IsNullOrWhiteSpace(options.VatNumber)
                ||!options.Email.Contains("@"))
            {
                return null;
            }

            var customer = new Customer();

            
                customer.VatNumber = options.VatNumber;
                customer.Email = options.Email;
                customer.Firstname = options.FirstName;

                dbContext.Set<Customer>().Add(customer);
                dbContext.SaveChanges();
                return customer;
            
        }

        public Customer CreateCustomer2(AddCustomerOptions options)
        {

            if (options == null)
            {
                return null;
            }

            if ((string.IsNullOrWhiteSpace(options.Email)
                || string.IsNullOrWhiteSpace(options.VatNumber)) &&
                (!options.Email.Contains("@")) &&
                (options.VatNumber.Length < 9) && (options.VatNumber.Length > 9))
            {
                return null;
            }

            var customer = new Customer();

            
                customer.VatNumber = options.VatNumber;
                customer.Email = options.Email;
                customer.Firstname = options.FirstName;

                dbContext.Set<Customer>().Add(customer);
                dbContext.SaveChanges();
                return customer;
            
        }
        public Customer GetCustomerById(int id)
        {
            if (id == default)
            {
                return null;
            }

            return CustomersList.
                SingleOrDefault(s => s.Id.Equals(id));
        }
    }
}
