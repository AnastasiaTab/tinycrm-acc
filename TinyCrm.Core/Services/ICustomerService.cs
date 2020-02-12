using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        public List<Customer> SearchCustomer
            (SearchCustomerOptions searchCustomerOptions);
        public List<Customer> SearchCustomer1
            (SearchCustomerOptions searchCustomerOptions);
        //public List<Customer> SearchCustomerByName(
        //    SearchCustomerOptions searchCustomerOptions);

        public Customer CreateCustomer(AddCustomerOptions options);
        public Customer CreateCustomer2(AddCustomerOptions options);
        public Customer GetCustomerById(int id);
        
    }
   
}
