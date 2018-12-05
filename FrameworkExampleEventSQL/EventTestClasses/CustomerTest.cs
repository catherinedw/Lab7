using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using EventClasses;
using EventPropsClasses;
using EventDBClasses;
using ToolsCSharp;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

using System.Data;
using System.Data.SqlClient;

using DBCommand = System.Data.SqlClient.SqlCommand;

using DBDataReader = System.Data.SqlClient.SqlDataReader;


namespace CustomerTestClasses
{
    [TestFixture]
    public class CustomerTest
    {
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRetrieveExistingCustomer()
        {
            Customer c = new Customer(1, dataSource);
            Assert.AreEqual(c.CustomerID, 1);
            Console.WriteLine(c.ToString());
        }

        [Test]
        public void TestCreateNewCustomer()
        {
            Customer c = new Customer(dataSource);

            c.CustomerName = "Daisy Duck";
            c.Address = "12 Banana Ave";
            c.City = "Islamorada";
            c.State = "FL";
            c.ZipCode = "87899";

            c.Save();

            Customer c2 = new Customer(c.CustomerID, dataSource);
            Assert.AreEqual(c.CustomerID, c2.CustomerID);
            Assert.AreEqual(c.Address, c2.Address);
            Assert.AreEqual(c.CustomerName, "Daisy Duck");

            Console.WriteLine(c.ToString());
            Assert.Greater(c.ToString().Length, 1);
        }


        [Test]
        public void TestUpdate()
        {
            Customer c = new Customer(1, dataSource);
            c.CustomerName = "Molunguri, B";
            c.Save();

            Customer cUpdated = new Customer(1, dataSource);

            Assert.AreEqual(cUpdated.CustomerName, "Molunguri, B");
            Console.WriteLine(c.ToString());
        }
        [Test]
        public void TestDelete()
        {
            Customer c = new Customer(697, dataSource);

            c.Delete();

            c.Save();

            Assert.Throws<Exception>(() => new Customer(697, dataSource));
        }

        [Test]
        public void TestStaticDelete()
        {
            /*
            Event.Delete(2, dataSource);
            Assert.Throws<Exception>(() => new Event(2, dataSource));
            */
        }
    }
}
