using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using ToolsCSharp;

using DBDataReader = System.Data.SqlClient.SqlDataReader;
using System.Data.SqlClient;


namespace EventPropsClasses

{
    public class CustomerProps : IBaseProps
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
        public string state = "";

        /// <summary>
        /// 
        /// </summary>
        public string zipCode = "";

        /// <summary>
        /// ConcurrencyID. See main docs, don't manipulate directly
        /// </summary>
        public int concurrencyID = 0;
        #endregion

        #region constructor
        /// <summary>
        /// Constructor. 
        /// </summary>
        public CustomerProps()
        {
            
        }

        /// <summary>
        /// Clones this object.
        /// </summary>
        public object Clone()
        {
            CustomerProps c = new CustomerProps();
            c.customerID = this.customerID;
            c.name = this.name;
            c.address = this.address;
            c.city = this.city;
            c.state = this.state;
            c.zipCode = this.zipCode;
            c.concurrencyID = this.concurrencyID;
            return c;
        }

        public string GetState()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.GetStringBuilder().ToString();
        }

        public void SetState(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringReader reader = new StringReader(xml);
            CustomerProps c = (CustomerProps)serializer.Deserialize(reader);
            this.customerID = c.customerID;
            this.name = c.name;
            this.address = c.address;
            this.city= c.city;
            this.state= c.state;
            this.zipCode= c.zipCode;
            this.concurrencyID = c.concurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.customerID = (Int32)dr["CustomerID"];
            this.name = (string)dr["Name"];
            this.address = (string)dr["Address"];
            this.city = (string)dr["City"];
            this.state = (string)dr["State"];
            this.zipCode = ((string)dr["ZipCode"]).Trim();
            this.concurrencyID = (Int32)dr["ConcurrencyID"];
        }
    
        #endregion
    }
}
