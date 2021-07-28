using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryStoreAPI.IServices;

namespace GroceryStoreAPI.Services
{
    public class CustomersService : ICustomersService
    {
        #region "Private Variables"
        /// <summary>
        /// Private valriable declaration to invoke the datbase class when ever we need it
        /// </summary>
        private Prod_CustomersContext dbcontext;
        private Customer customer = new Customer();
        private ReturnStatus returnResult = new ReturnStatus();
        #endregion



        #region "Constructor"
        /// <summary>
        /// constructor class to initialize the database connection whenever invoked.
        /// </summary>
        /// <param name="_db"></param>
        public CustomersService(Prod_CustomersContext _db)
        {
            dbcontext = _db;
        }
        #endregion

        #region "Public Methods"

        /// <summary>
        /// retrive all the Customer details from the database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetCustomers()
        {
            try
            {
                var customerList = dbcontext.Customers.ToList();
                return customerList;
            }
            catch(Exception ex)
            {
                returnResult.returnResult = "Return status Error: " + ex.ToString();
            }
            return (IEnumerable<Customer>)returnResult;
        }

        /// <summary>
        /// Retrive specific customer details from the database.
        /// </summary>
        /// <param name="customerID">ID of the specific customer</param>
        /// <returns></returns>
        public Customer GetCustomerByID(int customerID)
        {
            if (customerID != 0)
            {
                try
                {
                    var customerDetails = dbcontext.Customers.FirstOrDefault(x => x.customerId == customerID);
                    return customerDetails;
                }
                catch (Exception ex)
                {
                    returnResult.returnResult = "Return status Error: " + ex.ToString();
                }
                return customer;
            }
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// Add specific customer details into the database.
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public Customer AddCustomer(Customer customerName)
        {
            if (customerName != null)
            {
                try
                {
                    dbcontext.Customers.Add(customerName);
                    dbcontext.SaveChanges();
                    return customerName;

                }
                catch(Exception ex)
                {
                    returnResult.returnResult = "Return status Error: " + ex.ToString();
                }
                return customer;
            }
            else
            {
                return null;
            }
            
        }

        /// <summary>
        /// Update specific customer details and save into the database.
        /// </summary>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public Customer UpdateCustomer(Customer customerName)
        {
            if (customerName != null)
            {
                try
                {
                    dbcontext.Entry(customerName).State = EntityState.Modified;
                    dbcontext.SaveChanges();
                    return customerName;
                }
                catch(Exception ex)
                {
                    returnResult.returnResult = "Return status Error: " + ex.ToString();
                }
                return customer;
            }
            else
            {
                return null;
            }
            
        }

        #endregion

    }
}
