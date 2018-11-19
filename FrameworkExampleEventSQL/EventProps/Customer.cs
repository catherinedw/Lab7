using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader;

namespace CustomerClasses
{
    public class Customer
    {
        #region instance variables
        /// <summary>
        /// 
        /// </summary>
        public int customerID = Int32.MinValue;

        /// <summary>
        /// 
        /// </summary>
        public string name = "";

        /// <summary>
        /// 
        /// </summary>
        public string address = "";

        /// <summary>
        /// 
        /// </summary>
        public string city = "";

        /// <summary>
        /// 
        /// </summary>
        public char state = '';

        /// <summary>
        /// 
        /// </summary>
        public char zipCode = '';

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int ConcurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor. 
        /// </summary>
        public Customer()
        {
            Customer c = new Customer();
            c.customerID = this.customerID;
            c.name = this.name;
            c.address = this.address;
            c.city = this.city;
            c.state = this.state;
            c.zipCode = this.zipCode;
            c.ConcurrencyID = this.ConcurrencyID;
        }

        #endregion

    
    }
}
