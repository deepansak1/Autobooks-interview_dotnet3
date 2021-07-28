using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.IServices;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region "Private Members"
            /// <summary>
            /// Private member to invoke the interface methods whenever its required
            /// </summary>
            private readonly ICustomersService customersService;
        
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor method to intialize the interface methods
        /// </summary>
        /// <param name="customer"></param>
        public CustomerController(ICustomersService customer)
            {
                customersService = customer;
            }


        #endregion

        #region "Public CRUD methods"

        /// <summary>
        /// Get all the customer information from the database
        /// </summary>
        /// <returns></returns>
                // [Authorize] -- if we have swagger config, we can authticate the request....
                [HttpGet]
                [Route("[action]")]
                [Route("api/Customer/GetCustomers")]
                public IEnumerable<Customer> GetCustomers()
                {
                    return customersService.GetCustomers();
                }

            /// <summary>
            /// Retrieve specific customer information based on the customer id
            /// </summary>
            /// <param name="customerid"></param>
            /// <returns></returns>
                [HttpGet]
                [Route("[action]")]
                [Route("api/Customer/GetCustomerByID")]
                public Customer GetCustomerByID(int customerid)
                {
                    return customersService.GetCustomerByID(customerid);
                }

            /// <summary>
            /// Retrieve specific customer information based on the customer details
            /// </summary>
            /// <param name="customerid"></param>
            /// <returns></returns>
                [HttpPost]
                [Route("[action]")]
                [Route("api/Customer/AddCustomer")]
                public Customer AddCustomer(Customer newcustomerdetails)
                {
                    return customersService.AddCustomer(newcustomerdetails);
                }

            /// <summary>
            /// Update specific customer information based on the customer details
            /// </summary>
            /// <param name="customerid"></param>
            /// <returns></returns>
                [HttpPost]
                [Route("[action]")]
                [Route("api/Customer/UpdateCustomer")]
                public Customer UpdateCustomer(Customer newcustomerdetails)
                {
                    return customersService.UpdateCustomer(newcustomerdetails);
                }

        #endregion
    }
}
