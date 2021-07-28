using NUnit.Framework;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.IServices;
using Moq;
using GroceryStoreAPI.Services;
using System;

namespace CustomerControllerTests
{
    public class CustomerControllerTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetCustomers()
        {
            Prod_CustomersContext _db = new Prod_CustomersContext();
            var model = new CustomersService(_db);
            var controller = new CustomerController(model);
            var actualresult = controller.GetCustomers(); //model.GetCustomers();
            if (actualresult != null)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }

        }
        [Test]
        public void TestGetCustomersByID()
        {
            int cust_Id = 5; 
            Prod_CustomersContext _db = new Prod_CustomersContext();
            var model = new CustomersService(_db);
            var controller = new CustomerController(model);
            var actualresult = controller.GetCustomerByID(cust_Id); //model.GetCustomers();
            if (actualresult != null)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }

        }
        [Test]
        public void AddNewCustomer()
        {
            Customer objCustomer = new Customer();
            objCustomer.customerName = "Testing";
            Prod_CustomersContext _db = new Prod_CustomersContext();
            var model = new CustomersService(_db);
            var controller = new CustomerController(model);
            var actualresult = controller.AddCustomer(objCustomer); 
            if (actualresult != null)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }

        }
        [Test]
        public void UpdateCustomer()
        {
            Customer objCustomer = new Customer();
            objCustomer.customerId = 5;
            objCustomer.customerName = "Testing";
            Prod_CustomersContext _db = new Prod_CustomersContext();
            var model = new CustomersService(_db);
            var controller = new CustomerController(model);
            var actualresult = controller.UpdateCustomer(objCustomer);
            if (actualresult != null)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failure");
            }

        }
    }
}