using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EventPropsClasses;
using EventDBClasses;

using System.Data;
using DBCommand = System.Data.SqlClient.SqlCommand;

namespace CustomerTestClasses
{
    [TestFixture]
    public class CustomerDBTest
    {
        CustomerProps props, testc;
        CustomerSQLDB db;
        List<CustomerProps> list;
        private string dataSource = "Data Source=LAPTOP-S3LF8NDH\\SQLEXPRESS;Initial Catalog=MMABooksUpdated;Integrated Security=True";

        [SetUp]
        public void Setup()
        {
            db = new CustomerSQLDB(dataSource);
            props = new CustomerProps();

            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);

            testc = new CustomerProps();
            testc.customerID = 1;
            testc.name = "Daisy Duck";
            testc.address = "12 Banana Dr";
            testc.city = "Islamorada";
            testc.state = "FL";
            testc.zipCode = "85762";
            testc.concurrencyID = 1;
        }

        [Test]
        public void TestRetrieve()
        {
            props = (CustomerProps)db.Retrieve(1);
            Assert.AreEqual("Molunguri, A", props.name);
            Assert.AreEqual("1108 Johanna Bay Drive", props.address);
            Assert.AreEqual("Birmingham", props.city);
            Assert.AreEqual("AL", props.state);
            Assert.AreEqual("35216-6909", props.zipCode);
        }

        [Test]
        public void CustomerTestRetrieveAll()
        {
            list = (List<CustomerProps>)db.RetrieveAll(props.GetType());
            Assert.AreEqual(list.Count, 696);
        }

        [Test]
        public void TestCreate()
        {
            CustomerProps c2 = (CustomerProps)db.Create(testc);
            Assert.AreEqual(c2.customerID, 700);
            Assert.AreEqual(c2.concurrencyID, 1);

            props = (CustomerProps)db.Retrieve(700);
            Assert.AreEqual("Daisy Duck", props.name);
        }

        [Test]
        public void TestDelete()
        {
            CustomerProps c2 = (CustomerProps)db.Retrieve(1);
            db.Delete(c2);

            Assert.Throws<Exception>( () => db.Retrieve(1) );
        }

        [Test]
        public void TestUpdate()
        {
            CustomerProps c = (CustomerProps)db.Retrieve(1);
            c.city = "Birminghamshire";
            db.Update(c);

            c = (CustomerProps)db.Retrieve(1);
            Assert.AreEqual("Birminghamshire", c.city);
        }

        [Test]
        public void TestResetDatabase()
        {
           // CustomerSQLDB db = new CustomerSQLDB(dataSource);
            DBCommand command = new DBCommand();
            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;
            db.RunNonQueryProcedure(command);
        }
    }
}
