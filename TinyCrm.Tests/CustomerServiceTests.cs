using System;
using Xunit;

using TinyCrm.Core.Data;
using TinyCrm.Core.Model;
using TinyCrm.Core.Model.Options;
using TinyCrm.Core.Services;
using System.Linq;

namespace TinyCrm.Tests
{
    public class CustomerServiceTests
    {
        private TinyCrmDbContext context_;
        public CustomerServiceTests()
        {
            context_ = new TinyCrmDbContext();
        }
        [Fact]
        public void CreateCustomer_Success()
        {
            ICustomerService customerService =
                new CustomerService(context_);
            //var query = customerService.SearchCustomer(options);

            var options = new AddCustomerOptions()
            {
                Email = "an@gmail",
                FirstName = "anastasua",
                VatNumber = "123456749"

            };
            
            var customer = customerService.CreateCustomer(options);

            Assert.NotNull(customer);
            Assert.Equal(options.Email, customer.Email);
            Assert.Equal(options.VatNumber, customer.VatNumber);
            Assert.Equal(options.FirstName, customer.Firstname);

            var options1 = new SearchCustomerOptions()
            {

                Email = "an@gmail",
                FirstName = "anastasua",
                VatBumber = "123456749"


            };
            var customers = customerService.SearchCustomer(options1);
            Assert.NotNull(customers);
            //Assert.Single(customers);
        }

        [Fact]
        public void CreateCustomer_Fail_Null_VatNumber()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var options = new AddCustomerOptions()
            {
                Email = "an@gmail",
                FirstName = "anna",
                VatNumber = null

            };
            var customer = customerService.CreateCustomer(options);

            Assert.Null(customer);


        }
        [Fact]
        public void CreateCustomer_Fail_Null_Email()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var options = new AddCustomerOptions()
            {
                Email = "ddddd",
                FirstName = "anna",
                VatNumber = "3546dgy5"

            };
            var customer = customerService.CreateCustomer(options);

            Assert.Null(customer);
            //Assert.Empty(customer);
           //Assert.DoesNotContain("@");
        }

        [Fact]
        public void SearchCustomer_Success()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var options = new SearchCustomerOptions()
            {
                Email = "an@gmail",
                FirstName = "anastasua",
                VatBumber = "123456749"
            };

            var customers = customerService.SearchCustomer(options);

            Assert.NotNull(customers);
        }

        [Fact]
        public void SearchCustomer_Fail()
        {

            ICustomerService customerService =
                new CustomerService(context_);

            var options = new SearchCustomerOptions();
            var customers = customerService.SearchCustomer(options);
            Assert.Empty(customers);
        }
        [Fact]
        public void SearchCustomer_FailByOption()
        {

            ICustomerService customerService =
                new CustomerService(context_);

            var options = new SearchCustomerOptions()
            {
                Email = "an@gmail",
                FirstName = "ana",
                VatBumber = "123456749"
            };
            var customers = customerService.SearchCustomer(options);
            Assert.Empty(customers);
        }

        [Fact]
        public void SearchCustomerById_Success()
        {
            ICustomerService customerService =
                new CustomerService(context_);

            var options = new SearchCustomerOptions()
            {
                Id =1
            };

            var customers = customerService.SearchCustomer1(options);

            Assert.NotEmpty(customers);
            //Assert.Equal(options.Id, 1);
        }

        
    }
}
