using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStoreAPI.Models
{
    public partial class Customer
    {
        #region public members
        /// <summary>
        /// To get and set the property Cutomer id variable 
        /// </summary>
        public int customerId { get; set; }

        /// <summary>
        /// To get and set the property CustomerName variable 
        /// </summary>
        public string customerName { get; set; }

        #endregion
    }
    public partial class ReturnStatus
    {
        public string returnResult { get; set; }
    }
}
