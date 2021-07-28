using GroceryStoreAPI.Models;
using System.Collections.Generic;

namespace GroceryStoreAPI.IServices
{
    public interface ICustomersService
    {
        #region "Interface Members"

        /// <summary>
        /// This Interface method will retrive all the customer informations from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetCustomers();

        /// <summary>
        /// This Interface method will retrive a specific customer informations from database
        /// </summary>
        /// <param name="ID">ID value for the specific customer</param>
        /// <returns></returns>
        Customer GetCustomerByID(int ID);

        /// <summary>
        /// This Interface method will add specific customer information into database
        /// </summary>
        /// <param name="customer">Name value for the specific customer</param>
        /// <returns></returns>
        Customer AddCustomer(Customer customerName);

        /// <summary>
        /// This Interface method will add specific customer information into database
        /// </summary>
        /// <param name="customer">Name value for the specific customer</param>
        /// <returns></returns>
        Customer UpdateCustomer(Customer customerName);

        #endregion
    }

}
